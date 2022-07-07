using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AttackCtrl : MonoBehaviour
{
    public GameObject killPerfab; // 放入射出的秒殺物件
    Rigidbody rigidHas;  //抓取剛體
    public float xSpeed = 0.01f;
    public float ySpeed = 6.5f;  //跳躍高度
    public float downSpeed = 3.5f;  //下墜速度
    public float zSpeed = 0.01f;   //移動速度
    public Animator anime; //放入動畫
    bool groundCheck;  //確認是否觸地

    #region 跳躍方法
    void JumpOnGround()
    {
        if (groundCheck)
        {
            rigidHas.AddForce(new Vector2(0, ySpeed), ForceMode.Impulse);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            groundCheck = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            groundCheck = true;
        }
    }
    #endregion

    #region  碰觸到粒子 摧毀粒子+射出物件

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.A))
        {
            Destroy(other.gameObject);
            Instantiate(killPerfab, this.transform.position += new Vector3(0, 0, 0.01f), Quaternion.identity);
            anime.SetTrigger("Attack");
            
        }
    }

    #endregion

    void Start()
    {
        rigidHas = this.gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        //anime.SetInteger("AttackInt", 0);
        bool isMoving = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpOnGround();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Physics.gravity = new Vector3(0, 3.0F, 0);
            rigidHas.AddForce(new Vector2(0, -downSpeed), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(0, 0, zSpeed);
            isMoving = true;
            anime.SetInteger("MoveInt", 1);
            if (transform.eulerAngles.y >= 0 || transform.eulerAngles.y >= 179)
            {
                transform.Rotate(0, -180, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position += new Vector3(0, 0, -zSpeed);
            isMoving = true;
            anime.SetInteger("MoveInt", 1);
            if (transform.eulerAngles.y < 179)
            {
                transform.Rotate(0, 180, 0);
            }
        }
        //if (Input.GetKeyDown(KeyCode.X))          //普通射出物件
        //{
        //    Instantiate(killPerfab, this.transform.position, Quaternion.identity);
        //}

        #region 移動動畫

        if (isMoving)
        {
            if (anime.GetInteger("MoveInt") == 0)
                anime.SetInteger("MoveInt", 1);
        }
        else
        {
            if (anime.GetInteger("MoveInt") == 1)
                anime.SetInteger("MoveInt", 0);

        }

        #endregion
    }
}







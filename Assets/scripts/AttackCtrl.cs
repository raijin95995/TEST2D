using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AttackCtrl : MonoBehaviour
{
    public GameObject killPerfab; // 放入射出的秒殺物件
    public GameObject AttackPerfab;
    Rigidbody rigidHas;  //抓取剛體
    public float xSpeed = 0.01f;
    public float ySpeed = 7.5f;  //跳躍高度
    public float downSpeed = 3.5f;  //下墜速度
    public float zSpeed = 0.01f;   //移動速度
    public Animator animePlayer; //放入動畫
    bool groundCheck;  //確認是否觸地
    bool isJumpping;
    

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
            isJumpping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "ground")
        {
            groundCheck = true;
            isJumpping = false;
            animePlayer.SetInteger("JumpInt", 0);
        }
    }
    #endregion

    #region  碰觸到粒子 摧毀粒子+射出物件

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "hikari")
        {
            if (Input.GetKey(KeyCode.A))
            {
                Destroy(other.gameObject);
                Instantiate(killPerfab, this.transform.position += new Vector3(0, 0, 0.01f), Quaternion.identity);
                animePlayer.SetTrigger("Attack");
                print("攻擊一次");
            }
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
            animePlayer.SetInteger("JumpInt", 1);
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
            animePlayer.SetInteger("MoveInt", 1);
            if (transform.eulerAngles.y >= 0 || transform.eulerAngles.y >= 179)
            {
                transform.Rotate(0, -180, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position += new Vector3(0, 0, -zSpeed);
            isMoving = true;
            animePlayer.SetInteger("MoveInt", 1);
            if (transform.eulerAngles.y < 179)
            {
                transform.Rotate(0, 180, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))          //普通射出物件
        {
            animePlayer.SetTrigger("AttackNormal");
            Instantiate(AttackPerfab, this.transform.position, Quaternion.identity);
        }

        #region 移動動畫

        if (isMoving)
        {
            if (animePlayer.GetInteger("MoveInt") == 0)
                animePlayer.SetInteger("MoveInt", 1);
        }
        else
        {
            if (animePlayer.GetInteger("MoveInt") == 1)
                animePlayer.SetInteger("MoveInt", 0);

        }

        #endregion

    }
}







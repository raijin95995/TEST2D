using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AttackCtrl : MonoBehaviour
{
    public GameObject killPerfab;
    Rigidbody rigidHas;
    public float xSpeed = 0.01f;
    public float ySpeed = 6.5f;
    public float zSpeed = 0.01f;

    public Animator aniMove;
    

    void Start()
    {
        rigidHas = this.gameObject.GetComponent<Rigidbody>();

    }


    /// <summary>
    /// 碰觸到粒子  摧毀粒子+射出物件
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {

        if (Input.GetKey(KeyCode.A))
        {
            Destroy(other.gameObject);
            Instantiate(killPerfab, this.transform.position += new Vector3(0, 0, 0.01f), Quaternion.identity);
        }
    }

    void Update()
    {
        bool isMoving = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidHas.AddForce(new Vector2(0, ySpeed), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(0, 0, zSpeed);
             isMoving = true;
             aniMove.SetInteger("MoveInt", 1);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position += new Vector3(0, 0, -zSpeed);
        }
        //if (Input.GetKeyDown(KeyCode.X))          //普通射出物件
        //{
        //    Instantiate(killPerfab, this.transform.position, Quaternion.identity);
        //}

        if (isMoving)
        {
           if(aniMove.GetInteger("MoveInt") == 0)
              aniMove.SetInteger("MoveInt", 1);
        }
        else
        {
            if (aniMove.GetInteger("MoveInt") == 1)
                aniMove.SetInteger("MoveInt", 0);

        }






    }
}







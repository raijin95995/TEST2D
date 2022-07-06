using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AttackCtrl : MonoBehaviour
{
    public GameObject killPerfab; // �g�X�����
    Rigidbody rigidHas;  //�������
    public float xSpeed = 0.01f;
    public float ySpeed = 6.5f;
    public float zSpeed = 0.01f;
    public Animator aniMove; //��J�ʵe




    void Start()
    {
        rigidHas = this.gameObject.GetComponent<Rigidbody>();

    }

    #region  �IĲ��ɤl �R���ɤl+�g�X����

    void OnTriggerStay(Collider other)
    {

        if (Input.GetKey(KeyCode.A))
        {
            Destroy(other.gameObject);
            Instantiate(killPerfab, this.transform.position += new Vector3(0, 0, 0.01f), Quaternion.identity);
        }
    }

    #endregion

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

            if (transform.eulerAngles.y >= 0)
            {
                transform.Rotate(0, -10, 0);
            }


        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position += new Vector3(0, 0, -zSpeed);
            isMoving = true;
            aniMove.SetInteger("MoveInt", 1);


            if (transform.eulerAngles.y < 179)
            {
                transform.Rotate(0, 10, 0);

            }





        }
        //if (Input.GetKeyDown(KeyCode.X))          //���q�g�X����
        //{
        //    Instantiate(killPerfab, this.transform.position, Quaternion.identity);
        //}

        if (isMoving)
        {
            if (aniMove.GetInteger("MoveInt") == 0)
                aniMove.SetInteger("MoveInt", 1);
        }
        else
        {
            if (aniMove.GetInteger("MoveInt") == 1)
                aniMove.SetInteger("MoveInt", 0);

        }






    }
}







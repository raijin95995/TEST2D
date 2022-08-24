using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
[RequireComponent(typeof(Rigidbody))]

public class AttackCtrl : MonoBehaviour
{

    #region ���
    public GameObject killPerfab; // ��J�g�X���������
    public GameObject AttackPerfab;
    Rigidbody rigidHas;  //�������
    public float xSpeed = 0.01f;
    public float ySpeed = 7.5f;  //���D����
    public float downSpeed = 3.5f;  //�U�Y�t��
    public float zSpeed = 0.01f;   //���ʳt��
    public Animator animePlayer; //��J�ʵe
    bool groundCheck;  //�T�{�O�_Ĳ�a
    bool isJumpping;
    public bool faceRight = true;
    public Transform traPlayer;
    public float playerHp = 100;

    public GameObject playerUseHealth;
    public Image imgPlayerHp;
    public Image imgPlayerHpRed;
    //public Image imgPlayerCrazy;
    private float hp;
    private float playerCrazyCount;
    private int damage;

    #endregion



    #region �ƥ�
    void Start()
    {
        rigidHas = this.gameObject.GetComponent<Rigidbody>();
        hp = playerHp;
        imgPlayerHp.fillAmount = hp / playerHp;
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
            faceRight = true;
            this.gameObject.transform.position += new Vector3(0, 0, zSpeed);
            isMoving = true;
            animePlayer.SetInteger("MoveInt", 1);
            if (transform.eulerAngles.y >= 0 || transform.eulerAngles.y >= 179)  //�V�k��
            {
                transform.Rotate(0, -180, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            faceRight = false;
            this.gameObject.transform.position += new Vector3(0, 0, -zSpeed);
            isMoving = true;
            animePlayer.SetInteger("MoveInt", 1);
            if (transform.eulerAngles.y < 179)   //�V����
            {
                transform.Rotate(0, 180, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))          //���q�g�X����
        {
            animePlayer.SetTrigger("AttackNormal");
            Instantiate(AttackPerfab, this.transform.position, Quaternion.identity);
        }





        #region ���ʰʵe

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



        if (hp <= 0)
        {
            animePlayer.SetTrigger("Die");
            Invoke("Die" , 1.5f); //�]���ʵe�A�R��
        }


    }

    #region  �IĲ��ɤl �R���ɤl+�g�X����

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "hikari")
        {
            if (Input.GetKey(KeyCode.A))
            {
                Destroy(other.gameObject);
                if(faceRight)
                {
                    //Instantiate(killPerfab, this.transform.position += new Vector3(0, 0, 0.01f), Quaternion.identity);
                    Instantiate(killPerfab, this.transform.position, Quaternion.identity);
                    this.gameObject.transform.position += new Vector3(0, 0, 1.5f);
                    animePlayer.SetTrigger("Attack");
                    //print("���������@��");
                }
                else
                {
                    //Instantiate(killPerfab, this.transform.position -= new Vector3(0, 0, 0.01f), Quaternion.identity);
                    Instantiate(killPerfab, this.transform.position, Quaternion.identity);
                    this.gameObject.transform.position -= new Vector3(0, 0, 1.5f);
                    animePlayer.SetTrigger("Attack");
                    //print("���������@��");
                }

            }
        }
    }

    #endregion


    #endregion

    #region ��k

    #region ���D��k
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
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "monsterAtk")
        {
            GetHit();
            print(hp);
        }
    }

    void GetHit()
    {
        damage = 10;
        hp -= 10;
        imgPlayerHp.fillAmount = hp / playerHp;
        imgPlayerHpRed.fillAmount = hp / playerHp;

    }

    void Die()
    {
        Destroy(this.gameObject);

    }

}







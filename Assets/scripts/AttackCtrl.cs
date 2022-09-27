using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]

public class AttackCtrl : MonoBehaviour
{

    #region 資料
    public GameObject killPerfab; // 放入射出的秒殺物件
    public GameObject AttackPerfab;
    Rigidbody rigidHas;  //抓取剛體
    public float xSpeed = 0.01f;
    public float ySpeed = 7.5f;  //跳躍高度
    public float downSpeed = 1.5f;  //下墜速度
    public float zSpeed = 0.01f;   //移動速度
    public Animator animePlayer; //放入動畫
    bool groundCheck;  //確認是否觸地
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
    public bool isCrazy = false;
    private SystemCrazy systemCrazy;
    public enum Status { normal, crazy };
    public Status status;
    public bool isDead = false;

    private MonsterCtrl monsterCtrl;

    public MultipleKill multipleKill;
    public GameObject multipleKillPerfab; // 放入大型射出的秒殺物件
    public Image multiKillGirl;
    public Image multiKillBack;

    //[SerializeField, Header("Z普攻音效")]
    //private AudioClip soundZ;

    private SEPack sePcak;

    #endregion



    #region 事件
    void Start()
    {
        rigidHas = this.gameObject.GetComponent<Rigidbody>();
        hp = playerHp;
        imgPlayerHp.fillAmount = hp / playerHp;
        systemCrazy = GameObject.Find("畫面UI").GetComponent<SystemCrazy>();

        multipleKill = GameObject.Find("MuKill").GetComponent<MultipleKill>();
        sePcak = GameObject.Find("SE包").GetComponent<SEPack>();
    }


    void Update()
    {

        switch (status)
        {
            case Status.crazy:
                ySpeed = 12f;  //跳躍高度
                downSpeed = 3.5f;  //下墜速度
                zSpeed = 7f;   //移動速度
                break;
            case Status.normal:
                ySpeed = 7.5f;  //跳躍高度
                downSpeed = 3.5f;  //下墜速度
                zSpeed = 5f;   //移動速度
                break;

        }
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
            this.gameObject.transform.position += new Vector3(0, 0, zSpeed * Time.deltaTime);
            isMoving = true;
            animePlayer.SetInteger("MoveInt", 1);
            if (transform.eulerAngles.y >= 0 || transform.eulerAngles.y >= 179)  //向右走
            {
                transform.Rotate(0, -180, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            faceRight = false;
            this.gameObject.transform.position += new Vector3(0, 0, -zSpeed * Time.deltaTime);
            isMoving = true;
            animePlayer.SetInteger("MoveInt", 1);
            if (transform.eulerAngles.y < 179)   //向左走
            {
                transform.Rotate(0, 180, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))          //普通射出物件
        {
            
            animePlayer.SetTrigger("AttackNormal");
            Instantiate(AttackPerfab, this.transform.position, Quaternion.identity);
        }


        if (multipleKill.countHikari >= 3)
        {


            if (Input.GetKeyDown(KeyCode.U))
            {

                ShowGirl();

                SystemSound.instance.PlaySound(sePcak.soundU, new Vector2(0.7f, 1.5f));
                if (faceRight)
                {
                    //Instantiate(killPerfab, this.transform.position += new Vector3(0, 0, 0.01f), Quaternion.identity);
                    Instantiate(multipleKillPerfab, this.transform.position, Quaternion.identity);
                    this.gameObject.transform.position += new Vector3(0, 0, 1.5f);
                    animePlayer.SetTrigger("Attack");
                    //print("必死攻擊一次");
                }
                else
                {
                    //Instantiate(killPerfab, this.transform.position -= new Vector3(0, 0, 0.01f), Quaternion.identity);
                    Instantiate(multipleKillPerfab, this.transform.position, Quaternion.identity);
                    this.gameObject.transform.position -= new Vector3(0, 0, 1.5f);
                    animePlayer.SetTrigger("Attack");
                    //print("必死攻擊一次");
                }




            }




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



        if (hp <= 0)
        {
            imgPlayerHpRed.gameObject.SetActive(false);
            animePlayer.SetTrigger("Die");
            Invoke("Die", 1.5f);            //跑完動畫再刪除
        }




        IsCrazy();
        //StartCoroutine(CrazyHpLoss());

    }

    #region  碰觸到粒子 摧毀粒子+射出物件

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "hikari")
        {
            if (Input.GetKey(KeyCode.A))
            {
                Destroy(other.gameObject);
                if (faceRight)
                {
                    //Instantiate(killPerfab, this.transform.position += new Vector3(0, 0, 0.01f), Quaternion.identity);
                    Instantiate(killPerfab, this.transform.position, Quaternion.identity);
                    this.gameObject.transform.position += new Vector3(0, 0, 1.5f);
                    animePlayer.SetTrigger("Attack");
                    //print("必死攻擊一次");
                }
                else
                {
                    //Instantiate(killPerfab, this.transform.position -= new Vector3(0, 0, 0.01f), Quaternion.identity);
                    Instantiate(killPerfab, this.transform.position, Quaternion.identity);
                    this.gameObject.transform.position -= new Vector3(0, 0, 1.5f);
                    animePlayer.SetTrigger("Attack");
                    //print("必死攻擊一次");
                }

            }
        }
    }

    #endregion


    #endregion

    #region 方法

    void ShowGirl()
    {
        multiKillBack.gameObject.SetActive(true);
        StartCoroutine(MoveGirl());
       
    }

    private IEnumerator MoveGirl()
    {

        multiKillGirl.gameObject.SetActive(true);
        //Transform traGirlOri = multiKillGirl.transform;
        RectTransform traGirl = multiKillGirl.GetComponent<RectTransform>();
        for (int i = 0; i < 3; i++)
        {
            traGirl.position += new Vector3(60, 0, 0);

            yield return new WaitForSeconds(0.01f);
        }
        for (int j = 0; j < 20; j++)
        {
            traGirl.position += new Vector3(6, 0, 0);

            yield return new WaitForSeconds(0.03f);
        }
        for (int k = 0; k < 30; k++)
        {
            traGirl.position += new Vector3(50, 0, 0);

            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.12f);
        //multiKillGirl.transform.position = new Vector3(-680, 0, 0);
        multiKillGirl.gameObject.SetActive(false);
        multiKillBack.gameObject.SetActive(false);

    }


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
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monsterAtk")
        {
            SystemSound.instance.PlaySound(sePcak.soundPlayerHited, new Vector2(0.7f, 1.5f));
            GetHit();
            print(hp);
        }
        if (other.gameObject.tag == "portal")
        {
            SceneManager.LoadScene("02");
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
        isDead = true;

    }

    //update 放入 IsCrazy()  但是每次都光速流血  如何等待?

    private void IsCrazy()   //判斷是否暴走
    {


        if (imgPlayerHpRed.gameObject.activeSelf && isCrazy == true)    //UI上的暴走被啟用
        {
            status = Status.crazy;
            isCrazy = false;
            StartCoroutine(CrazyHpLoss());

        }


    }
    private IEnumerator CrazyHpLoss()
    {

        for (int i = 0; i < 10; i++)
        {
            hp -= 2;
            imgPlayerHp.fillAmount = hp / playerHp;         //原始血條
            imgPlayerHpRed.fillAmount = hp / playerHp;      //紅色血條
            Debug.Log("暴走流血" + hp);
            yield return new WaitForSeconds(0.5f);             //
        }

        systemCrazy.playerCrazyCount -= 50;
        imgPlayerHpRed.gameObject.SetActive(false);
        print("我關的拉");
        status = Status.normal;



    }
}







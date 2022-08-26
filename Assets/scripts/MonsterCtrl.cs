using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using TMPro;

public class MonsterCtrl : MonoBehaviour
{

    #region 資料
    public float delayTime = 2.0f;
    public int monsterHp = 10;
    public Animator animeMonster;
    public Transform hikariTarget;
    public Transform monsterTarget;
    public GameObject BornKill;
    public float hikariBornTime;
    public bool startTime;
    public GameObject useHealth;
    public Image imgHp;
    //public TextMeshProUGUI killCountText;
    int ten = 10;
    float hp;
    float damage;
    public bool faceL = true;
    public float walkSpeed = 0.5f;
    public Transform monTra;
    public Transform playerTra;

    public enum Status { idle,walk,atk };
    public Status status;
    private bool canAtk = false;
    private bool canWalk = true; 
    public GameObject monAtkPerfab;
    public float atkSpeed = 3f;

    public bool isDead = false ;

    private AttackCtrl attackCtrl;

    public UnityEvent onNormalAtk;
    public UnityEvent onDead;



    #endregion

    void Start()
    {
        status = Status.idle;
        attackCtrl = GameObject.Find("玩家").GetComponent<AttackCtrl>();
        monTra = this.transform;
        playerTra = GameObject.Find("玩家").transform;
        hp = monsterHp;
        //Instantiate(BornKill, hikariTarget.position, Quaternion.identity);
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;



        if (Mathf.Abs(monTra.position.z - playerTra.position.z) < 5f && canWalk == true)
        {
            canAtk = false;
            status = Status.walk;
        }
            

        if (Mathf.Abs(monTra.position.z - playerTra.position.z) >= 5f)
            status = Status.idle;

        if (Mathf.Abs(monTra.position.z - playerTra.position.z) < 1f && canAtk == true)
        {
            canWalk = false;
            status = Status.atk;
        }
            



        switch (status)
        {
            case Status.idle:
                animeMonster.SetTrigger("Stop");
                break;
            case Status.walk:
                if(monTra.position.z >= playerTra.position.z && isDead == false)
                {
                    //monTra.LookAt(playerTra);

                    faceL = true;
                    monTra.position -= new Vector3(0, 0, walkSpeed * deltaTime);
                    animeMonster.SetTrigger("Walk");

                    if (transform.eulerAngles.y < 179)   //向左旋轉
                    {
                        transform.Rotate(0, 180, 0);
                    }
                }
                else if(isDead == false)
                {
                    //monTra.LookAt(playerTra);
                    faceL = false;
                    monTra.position += new Vector3(0, 0, walkSpeed * deltaTime);
                    animeMonster.SetTrigger("Walk");

                    if (transform.eulerAngles.y >= 0 || transform.eulerAngles.y >= 179)  //向右旋轉
                    {
                        transform.Rotate(0, -180, 0);
                    }
                }

                break;

            case Status.atk:

                animeMonster.SetTrigger("Atk");

                if (canAtk)
                {
                    canAtk = false;
                    Invoke("atktest", atkSpeed);  //攻速
                }
                
              
                break;
        }

        
        if (hp <= 0)
        {
            status = Status.idle;
            imgHp.fillAmount = 0f ;
            isDead = true; 
            canAtk = false;
            canWalk = false;
            animeMonster.SetTrigger("Die");
            onDead.Invoke();
            Invoke("MonsterDie", 1.8f);  //延遲死亡給動畫
        }

        if (startTime)
        {
            float ran = Random.Range(2.5f, 10.0f);
            hikariBornTime += Time.deltaTime;

            if (hikariBornTime >= ran)//
            {
                HikariBornB();   //
                hikariBornTime = 0f;//
            }
        }
        //Invoke("HikariBorn", 3.0f);



    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kill")
        {
            GetDie();
            status = Status.idle;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "atk")
        {
            GetHit();
            Destroy(other.gameObject);
            onNormalAtk.Invoke();
        
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player" && hp >0)
        {
            canWalk = false;
            canAtk = true;
            print(Mathf.Abs(monTra.position.z - playerTra.position.z));
            //status = Status.atk;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "player" && hp > 0)
        {
            canAtk = false;
            canWalk = true;
        }
    }

    void GetHit()
    {
        
        damage = 1;
        hp -= damage;
        imgHp.fillAmount = hp / monsterHp;
        animeMonster.SetTrigger("Hit");
        Debug.Log("碰到atk");
        //monsterHp -= 1;
    }

    void GetDie()
    {
        Debug.Log("碰到KILL");
        hp -= 10;
    }

    void MonsterDie()   //跑死亡動畫用
    {
        Destroy(this.gameObject);
    }

    void HikariDie()
    {
        Destroy(BornKill);
    }

    void HikariBorn()
    {

        Invoke("HikariBornB", 1.0f);

        //Instantiate(BornKill, hikariTarget.position, Quaternion.identity);


        //Invoke("HikariDie", 0.5f);

    }

    void HikariBornB()
    {

        Instantiate(BornKill, hikariTarget.position, Quaternion.identity);

    }


    private IEnumerator Atk()
    {
        
        for (int i = 0; i < 1; i++)
        {
            animeMonster.SetTrigger("Atk");
            Instantiate(monAtkPerfab, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(atkSpeed);
        }
        

    }

    void atktest()
    {
        
            animeMonster.SetTrigger("Atk");
            canAtk = true;
            Instantiate(monAtkPerfab, this.transform.position, Quaternion.identity);
        
    }

    
}




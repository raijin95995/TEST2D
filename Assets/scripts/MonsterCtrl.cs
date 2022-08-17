using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterCtrl : MonoBehaviour
{

    #region 資料
    public float delayTime = 1.0f;
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
    #endregion

    void Start()
    {
        hp = monsterHp;
        //Instantiate(BornKill, hikariTarget.position, Quaternion.identity);
    }

    void Update()
    {

        //imgHp.fillAmount = monsterHp / ten ;
        if (hp <= 0)
        {
            animeMonster.SetTrigger("Die");
            Invoke("MonsterDie", delayTime);
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
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "atk")
        {
            GetHit();
            Destroy(other.gameObject);
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

    void MonsterDie()
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

}




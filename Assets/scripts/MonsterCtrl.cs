using UnityEngine;

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
    #endregion

    void Start()
    {
        //Instantiate(BornKill, hikariTarget.position, Quaternion.identity);
    }

    void Update()
    {
        if (monsterHp <= 0)
        {
            animeMonster.SetTrigger("Die");
            Invoke("MonsterDie", delayTime);
        }

        if (startTime)
        {
            hikariBornTime += Time.deltaTime;
            if (hikariBornTime >= 2.0f)//
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
            Debug.Log("碰到KILL");
            monsterHp -= 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "atk")
        {
            animeMonster.SetTrigger("Hit");
            Debug.Log("碰到atk");
            monsterHp -= 1;
            Destroy(other.gameObject);
        }
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




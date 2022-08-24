using UnityEngine;

public class HikariCtrl : MonoBehaviour
{
    //public Transform monsterTarget;
    //public Transform hikariTarget;

    //private MonsterCtrl monsterCtrl;

    // Start is called before the first frame update
    void Start()
    {
        //monsterCtrl = GameObject.Find("Slime 2").GetComponent<MonsterCtrl>();
        //MoveHikari();
        Invoke("HikariDie", 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("HikariFollow",1.0f);
        //HikariFollow();
        //Invoke("HikariDie", 1.0f);
    }

    void MoveHikari()
    {
       // Transform tra;
        //tra = monsterCtrl.hikariTarget;
        //if (this.transform != tra)
        //{
        //    this.transform.position = tra.position ;  //設定出身位置
        //}
        
        //this.gameObject.transform.position += new Vector3(0, 0.5f , -1);  //設定出身位置
    }

    void HikariFollow()
    {
        //this.gameObject.transform.position = hikariTarget.position;
      //MoveHikari();

    }

    void HikariDie()
    {
        Destroy(this.gameObject);
      
    }

}

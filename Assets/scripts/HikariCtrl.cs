using UnityEngine;

public class HikariCtrl : MonoBehaviour
{
    //public Transform monsterTarget;
    //public Transform hikariTarget;

    // Start is called before the first frame update
    void Start()
    {
        //MoveHikari();
        Invoke("HikariDie", 1.9f);
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
        this.gameObject.transform.position += new Vector3(0, 0.5f , -1);  //設定出身位置
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

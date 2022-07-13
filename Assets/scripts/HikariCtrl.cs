using UnityEngine;

public class HikariCtrl : MonoBehaviour
{
    public Transform monsterTarget;
    public Transform hikariTarget;

    // Start is called before the first frame update
    void Start()
    {
        MoveHikari();
    }

    // Update is called once per frame
    void Update()
    {
        HikariFollow();
    }

    void MoveHikari()
    {
        this.gameObject.transform.position += new Vector3(0, 0.5f , -1);  //設定出身位置
    }

    void HikariFollow()
    {
       this.gameObject.transform.position = monsterTarget.position;
        MoveHikari();

    }

}

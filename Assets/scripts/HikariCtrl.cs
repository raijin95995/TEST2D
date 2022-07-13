using UnityEngine;

public class HikariCtrl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        MoveHikari();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveHikari()
    {
        this.gameObject.transform.position += new Vector3(0, 0.5f , -1);  //設定出身位置
    }

   
}

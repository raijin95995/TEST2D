using UnityEngine;

public class QTEkillBIG : MonoBehaviour
{
    public float killSpeed = 0.1f;
    private AttackCtrl attackCtrl;
    private bool faceR = true;


    void Start()
    {
        attackCtrl = GameObject.Find("ª±®a").GetComponent<AttackCtrl>();
    }

    void Update()
    {
        faceR = attackCtrl.faceRight;
        if (faceR)
        {
            this.gameObject.transform.position += new Vector3(0, 0, killSpeed * Time.deltaTime * 60);
            Invoke("DestroyObject", 10f);

        }
        else
        {
            this.gameObject.transform.position -= new Vector3(0, 0, killSpeed * Time.deltaTime * 60);
            Invoke("DestroyObject", 10f);

        }

    }
    
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }












    //void Update()
    //{
        //this.gameObject.transform.position += new Vector3(0, 0, killSpeed * Time.deltaTime * 60);
        //timer -= Time.deltaTime;
        //if (timer <= 0) 
        //{
        //    Destroy(this.gameObject);
        //}



    //}
}

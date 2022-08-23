using UnityEngine;

public class AtkUse : MonoBehaviour
{
    //public float timer;
    public float atkSpeed = 0.5f;
    private AttackCtrl attackCtrl;
    private bool faceR = true;



    void Start()
    {
        attackCtrl = GameObject.Find("ª±®a").GetComponent<AttackCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        faceR = attackCtrl.faceRight;
        if (faceR)
        {
            this.gameObject.transform.position += new Vector3(0, 0, atkSpeed * Time.deltaTime * 60);
            //timer -= Time.deltaTime;
            //if (timer <= 0) 
            //{
            //    Destroy(this.gameObject);
            //}
            Invoke("DestroyObject", 0.4f);

        }
        else
        {
            this.gameObject.transform.position -= new Vector3(0, 0, atkSpeed * Time.deltaTime * 60);
            //timer -= Time.deltaTime;
            //if (timer <= 0) 
            //{
            //    Destroy(this.gameObject);
            //}
            Invoke("DestroyObject", 0.4f);

        }
       

    }
    void ShootObject()
    {
        this.gameObject.transform.position += new Vector3(0, 0, atkSpeed * Time.deltaTime * 60);
    }
   void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}

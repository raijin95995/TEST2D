using UnityEngine;

public class AtkUse : MonoBehaviour
{
    public float atkSpeed = 0.5f;
    private AttackCtrl attackCtrl;
    private bool faceR = true;



    void Start()
    {
        attackCtrl = GameObject.Find("���a").GetComponent<AttackCtrl>();
    }


    void Update()
    {
        faceR = attackCtrl.faceRight;
        if (faceR)
        {
            this.gameObject.transform.position += new Vector3(0, 0, atkSpeed * Time.deltaTime * 60);

            Invoke("DestroyObject", 0.4f);

        }
        else
        {
            this.gameObject.transform.position -= new Vector3(0, 0, atkSpeed * Time.deltaTime * 60);

            Invoke("DestroyObject", 0.4f);

        }


    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}

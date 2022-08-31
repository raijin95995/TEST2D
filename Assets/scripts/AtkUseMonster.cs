using UnityEngine;

public class AtkUseMonster : MonoBehaviour
{
    public float atkSpeed = 0.5f;
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
            this.gameObject.transform.position -= new Vector3(0, 0, atkSpeed * Time.deltaTime * 60);

            Invoke("DestroyObject", 0.5f);

        }
        else
        {
            this.gameObject.transform.position += new Vector3(0, 0, atkSpeed * Time.deltaTime * 60);

            Invoke("DestroyObject", 0.5f);

        }


    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}

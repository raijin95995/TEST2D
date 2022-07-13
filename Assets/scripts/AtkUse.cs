using UnityEngine;

public class AtkUse : MonoBehaviour
{
    //public float timer;
    public float atkSpeed = 0.5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(0, 0, atkSpeed * Time.deltaTime * 60);
        //timer -= Time.deltaTime;
        //if (timer <= 0) 
        //{
        //    Destroy(this.gameObject);
        //}
        Invoke("DestroyObject", 0.2f);

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

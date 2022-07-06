using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AttackCtrl : MonoBehaviour
{
    public GameObject  killPerfab ;
    Rigidbody rigidHas;
    public float xSpeed = 0.01f;
    public float ySpeed = 6.5f;
    public float zSpeed = 0.01f;


    void Start()
    {
        rigidHas = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidHas.AddForce(new Vector2(0, ySpeed), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(0, 0, zSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position += new Vector3(0, 0, -zSpeed);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(killPerfab, this.transform.position , Quaternion.identity);
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{



    // if (collision.gameObject.tag == "hikari")
    //  {
    //   print(collision.gameObject.tag);
    //    collision.gameObject.SendMessage("ApplyDamage", 10);
    //  }
    // }
    //Detect collisions between the GameObjects with Colliders attached
    //void OnCollisionEnter(Collision collision)
    //{
    //Check for a match with the specified name on any GameObject that collides with your GameObject
    // if (collision.gameObject.name == "Particle System")
    // {
    //If the GameObject's name matches the one you suggest, output this message in the console
    //  Debug.Log("碰到光了");
    // }

    //Check for a match with the specific tag on any GameObject that collides with your GameObject
    //if (collision.gameObject.tag == "hikari")
    //{
    //If the GameObject has the same tag as specified, output this message in the console
    //   Debug.Log("我是碰到TAG");
    //}
    //}
    void OnTriggerStay(Collider other)
    {
        // Destroy everything that leaves the trigger
        if (Input.GetKey(KeyCode.A))
        {
            Destroy(other.gameObject);
            Instantiate(killPerfab, this.transform.position += new Vector3(0,0,0.01f), Quaternion.identity);

        }
    }
}







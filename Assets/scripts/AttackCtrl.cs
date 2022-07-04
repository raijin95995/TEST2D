using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AttackCtrl : MonoBehaviour
{
    Rigidbody rigidHas ;
    public float xSpeed = 0.01f;
    public float ySpeed = 10.5f;
    public float zSpeed = 0.01f;

         //if (Input.GetKey(KeyCode.RightArrow))
        //{
         //   this.gameObject.transform.rotation += new Vector3(0, 180, 0);
        // }

    // Start is called before the first frame update
    void Start()
    {
        rigidHas = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            rigidHas.AddForce(new Vector2(0, ySpeed), ForceMode.Impulse);
        }

            if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3 (0, 0, zSpeed);
        }

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position += new Vector3(0, 0, -zSpeed);
            
        }



    }
}

using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public int monsterHp = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(monsterHp <= 0)
        {
            Destroy(this.gameObject);
            
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
  
        
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "kill")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("我是碰到TAG");
            monsterHp -= 10;
            

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kill")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("我是碰到TAG");
            monsterHp -= 10;
            Destroy(other.gameObject);

        }
    }

}




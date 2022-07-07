using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public int monsterHp = 10;


    void Start()
    {

    }

    void Update()
    {
        if (monsterHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kill")
        {
            Debug.Log("¸I¨ìKILL");
            monsterHp -= 10;
            Destroy(other.gameObject);
        }
    }

}




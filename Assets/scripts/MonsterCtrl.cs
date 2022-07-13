using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public float delayTime = 1.0f;
    public int monsterHp = 10;
    public Animator animeMonster;

    void Start()
    {
        
    }

    void Update()
    {
        if (monsterHp <= 0)
        {
            animeMonster.SetTrigger("Die");
            Invoke("MonsterDie", delayTime);
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

    void MonsterDie()
    {
        Destroy(this.gameObject);
    }

}




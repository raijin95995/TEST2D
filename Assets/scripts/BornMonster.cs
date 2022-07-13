using UnityEngine;

public class BornMonster : MonoBehaviour
{
    public GameObject MonsterPrefab ;
    public float bornTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BornMon", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BornMon()
    {
        Instantiate(MonsterPrefab, this.transform.position,transform.rotation = new Quaternion(0, 180, 0, 0));
    }
}

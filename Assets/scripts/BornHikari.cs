using UnityEngine;

public class BornHikari : MonoBehaviour
{
    public GameObject BornKill ;
    public Transform monsterTarget;
    public Transform hikariTarget;

    // Start is called before the first frame update
    void Start()
    {

        Instantiate(BornKill, this.transform.position += new Vector3(0, 0, 0), Quaternion.identity); //�]�w�X��������

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

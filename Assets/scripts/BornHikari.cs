using UnityEngine;

public class BornHikari : MonoBehaviour
{
    public GameObject BornKill ;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(BornKill, this.transform.position += new Vector3(0, 0, 0), Quaternion.identity); //設定出身必殺光

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

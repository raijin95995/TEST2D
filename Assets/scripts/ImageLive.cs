using UnityEngine;

public class ImageLive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Display", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Display()
    {
        Destroy(this);

    }
}

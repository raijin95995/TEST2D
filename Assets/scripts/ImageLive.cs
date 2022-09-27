using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageLive : MonoBehaviour
{
    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Display", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        img.color -= new Color(0, 0, 0, 0.01f);
    }


    void Display()
    {
        Destroy(this);

    }
}

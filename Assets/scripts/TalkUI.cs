using UnityEngine;


/// <summary>
/// ¹ï¸Ü®Ø¼u¥X
/// </summary>
public class TalkUI : MonoBehaviour
{
    public GameObject talkMessage;
    public GameObject talkUI;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (talkMessage.activeSelf && Input.GetKeyDown(KeyCode.Q))
        {
            talkUI.SetActive(true);
            Invoke("DisplayUI", 15.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            talkMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            talkMessage.SetActive(false);
        }
    }

    void DisplayUI()
    {
        talkUI.SetActive(false);
    }    
}

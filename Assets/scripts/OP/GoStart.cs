using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoStart : MonoBehaviour
{

    public TextMeshProUGUI testStart;
    public Scene goNext;


    void Start()
    {
        StartCoroutine(ColorAlpha());

    }

    
    void Update()
    {

        
        if (Input.anyKey)
        {
            //Debug.Log("A key or mouse click has been detected");
            SceneManager.LoadScene("01");

        }

    }


   

    private IEnumerator ColorAlpha()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                testStart.color -= new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.02f);
                //print(testStart.color.ToString());

            }

            for (int k = 0; k < 20; k++)
            {
                testStart.color += new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.02f);
                //print(testStart.color.ToString());
            }
        }
        
        
     

    }

}

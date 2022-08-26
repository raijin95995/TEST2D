using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    private MonsterCtrl monsterCtrl;
    public Image arrow;
    public GameObject monster;

    
    void Start()
    {
        monsterCtrl = GameObject.Find("Å]ª«").GetComponent<MonsterCtrl>();
        monsterCtrl.onDead.AddListener(ShowArrow);
    }

    
    void Update()
    {
        
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            SceneManager.LoadScene("02");
        }
    }

    void ShowArrow()
    {
        arrow.gameObject.SetActive(true);
        //StartCoroutine(ArrowAlpha());
    }

    private IEnumerator ArrowAlpha()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                arrow.color -= new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.02f);
                // print(redScene.color.ToString());

            }

            for (int k = 0; k < 20; k++)
            {
                arrow.color += new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.02f);
                // print(redScene.color.ToString());
            }
        }


    }
}

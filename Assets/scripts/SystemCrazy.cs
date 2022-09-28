using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SystemCrazy : MonoBehaviour
{

    public GameObject playerUI;
    //public Image imgPlayerHp;
    public Image imgPlayerCrazy;
    //private float hp;
    public float playerCrazyCount = 0;
    public float playerCrazyTotal = 100;
    private MonsterCtrl monsterCtrl;
    private AttackCtrl attackCtrl;
    public Image redScene;
    public GameObject redHair1;
    public GameObject redHair2;


    void Start()
    {
        monsterCtrl = GameObject.Find("�]��").GetComponent<MonsterCtrl>();
        attackCtrl = GameObject.Find("���a").GetComponent<AttackCtrl>();
        monsterCtrl.onNormalAtk.AddListener(CrazyAdd);

    }

    
    void Update()
    {
        imgPlayerCrazy.fillAmount = playerCrazyCount / playerCrazyTotal;
        GoCrazy();
        //DownCrazy();
    }


    private void CrazyAdd()
    {
        playerCrazyCount += 10;
        //imgPlayerCrazy.fillAmount = playerCrazyCount / playerCrazyTotal;

    }

    
    void GoCrazy()
    {

        if (playerCrazyCount == playerCrazyTotal && attackCtrl.isCrazy)
        {
            attackCtrl.imgPlayerHpRed.gameObject.SetActive(true);
            print("�ڥ��}��");
            redScene.gameObject.SetActive(true);
            redHair1.gameObject.SetActive(true);
            redHair2.gameObject.SetActive(true);
            StartCoroutine(CrazySceneAlpha());
            //attackCtrl.isCrazy = true;
        }
        if (playerCrazyCount != playerCrazyTotal)
        {
            
            redScene.gameObject.SetActive(false);
            redHair1.gameObject.SetActive(false);
            redHair2.gameObject.SetActive(false);

        }

    }

    //void DownCrazy()
    //{
    // if (playerCrazyCount != playerCrazyTotal )
    // {
    //    attackCtrl.imgPlayerHpRed.gameObject.SetActive(false);
    //     print("��������");
    // }
    //}


    private IEnumerator CrazySceneAlpha()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                redScene.color -= new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.02f);
               // print(redScene.color.ToString());

            }

            for (int k = 0; k < 20; k++)
            {
                redScene.color += new Color(0, 0, 0, 0.05f);
                yield return new WaitForSeconds(0.02f);
               // print(redScene.color.ToString());
            }
        }




    }


}

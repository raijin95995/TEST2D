using UnityEngine;
using UnityEngine.UI;

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
            //attackCtrl.isCrazy = true;
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



}

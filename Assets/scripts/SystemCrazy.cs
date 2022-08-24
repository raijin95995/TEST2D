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
        monsterCtrl = GameObject.Find("Å]ª«").GetComponent<MonsterCtrl>();
        attackCtrl = GameObject.Find("ª±®a").GetComponent<AttackCtrl>();
        monsterCtrl.onNormalAtk.AddListener(CrazyAdd);
    }

    
    void Update()
    {
        GoCrazy();
    }


    private void CrazyAdd()
    {
        playerCrazyCount += 10;
        imgPlayerCrazy.fillAmount = playerCrazyCount / playerCrazyTotal;

    }

    
    void GoCrazy()
    {

        if (playerCrazyCount == playerCrazyTotal)
        {
            attackCtrl.imgPlayerHpRed.gameObject.SetActive(true);
        }
    }



}

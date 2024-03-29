using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
	private MonsterCtrl monsterCtrl;
	public Image arrow;
	//public GameObject monster;
	private bool canGo = false;


	void Start()
	{
		monsterCtrl = GameObject.Find("�]��").GetComponent<MonsterCtrl>();
		//monsterCtrl.onDead.AddListener(ShowArrow);
	}


	void Update()
	{

		if (!monsterCtrl.gameObject.activeSelf)
		{
			canGo = true;
			arrow.gameObject.SetActive(true);
		}
	}


	private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "player" && canGo)
		{
			int nowSceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(nowSceneIndex + 1);
		}



	}

	void ShowArrow()
	{
		arrow.gameObject.SetActive(true);
		canGo = true;

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

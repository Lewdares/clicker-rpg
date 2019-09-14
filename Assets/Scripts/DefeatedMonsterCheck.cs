using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatedMonsterCheck : MonoBehaviour
{
	public int totalLife = 10;
	public static bool neverDone = true;
	public GameObject statusText;
	public GameObject enemyGraphic;
	
	public CreateEnemy createEnemy;
	
    // Update is called once per frame
    void Update()
    {
		int totalLife = GlobalCookies.HPCount[0] + GlobalCookies.HPCount[1] + GlobalCookies.HPCount[2] + GlobalCookies.HPCount[3] + GlobalCookies.HPCount[4];
		
		if (totalLife <= 0) {
			if (neverDone)
				{
					StartCoroutine ( TextAppear());
					statusText.GetComponent<Text>().text = "Monster has been defeated!";
					statusText.GetComponent<Animation>().Play("TextFade");
					createEnemy.CreateAnEnemy();
					neverDone = false;
				}
		}
    }
	
	IEnumerator TextAppear()
	{
		statusText.GetComponent<Text>().text = "Monster has been defeated!";
		yield return new WaitForSeconds (1.0f);
		statusText.GetComponent<Animation>().Play("TextFade");
	}
}

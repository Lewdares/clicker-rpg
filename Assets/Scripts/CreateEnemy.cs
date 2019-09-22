using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEnemy : MonoBehaviour
{
	private SpriteRenderer rend;
	public List<Sprite> SpriteSelection;
	public List<int> oldHitPoints;
	public GameObject chest;
	public GameObject crotch;
	public GameObject hand;
	public GameObject head;
	public GameObject leg;
	public GameObject statusText;
	public string EnemyName = "unknown enemy";
	
	public GameObject dungeonText;
	public static int DungeonFloor = 1;
	public static int DungeonLevel = 1;
	public static int DungeonBestScore = 1;
	
    // Start is called before the first frame update
    void Start()
    {
		// change to an unity list l8r
        chest = GameObject.Find("Chest");
		crotch = GameObject.Find("Crotch");
		hand = GameObject.Find("Hand");
		head = GameObject.Find("Head");
		leg = GameObject.Find("Leg");
		
		
		oldHitPoints = new List<int>{100,100,100,100,100};
		
		dungeonText.GetComponent<Text>().text = "Dungeon " + DungeonLevel + " - " + DungeonFloor;
		dungeonText.GetComponent<Animation>().Play("FadeInAndOutDungeon");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void CreateAnEnemy()
	{
		this.gameObject.GetComponent<Animation>().Play("EnemyRunAway");
		StartCoroutine ( SpawnNew());
		
	}
	
	IEnumerator SpawnNew()
	{
		yield return new WaitForSeconds (1.5f);
		
		var randomNum = Random.Range(0,SpriteSelection.Count);
		this.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteSelection[randomNum];
		
		if(randomNum == 0) {
			EnemyName = "red placeholder guy";
		}
		else if(randomNum == 1) {
			EnemyName = "blue placeholder guy";
		}
		else if(randomNum == 2) {
			EnemyName = "green placeholder guy";
		}
		else {
			EnemyName = "unknown enemy";
		}
		
		this.gameObject.GetComponent<Animation>().Play("NewEnemyAppears");
		
		var crotchLikeness = Random.Range(0,10);
		var handLikeness = Random.Range(0,10);
		var headLikeness = Random.Range(0,10);
		var legLikeness = Random.Range(0,10);
		var chestLikeness = Random.Range(0,10);
		bool atLeastOne = false;
		
		/*This part sets the likeness of the clothespieces in the following character.
		Handpieces, for example, have a chance of appearing 6/10 times.
		In the case no clothespiece has been picked out, the character will only wear a chestpiece,
		with 50% extra hit points.*/
		
		if (crotchLikeness >= 3) {
			crotch.gameObject.SetActive(true);
			GlobalCookies.HPCount[1] = oldHitPoints[1] + Random.Range(22,37);
			oldHitPoints[1] = GlobalCookies.HPCount[1];
			atLeastOne = true;
		}
		if (handLikeness >= 4) {
			hand.gameObject.SetActive(true);
			GlobalCookies.HPCount[2] = oldHitPoints[2] + Random.Range(22,37);
			oldHitPoints[2] = GlobalCookies.HPCount[2];
			atLeastOne = true;
		}
		if (headLikeness >= 6) {
			head.gameObject.SetActive(true);
			GlobalCookies.HPCount[3] = oldHitPoints[3] + Random.Range(22,37);
			oldHitPoints[3] = GlobalCookies.HPCount[3];
			atLeastOne = true;
		}
		if (legLikeness >= 5) {
			leg.gameObject.SetActive(true);
			GlobalCookies.HPCount[4] = oldHitPoints[4] + Random.Range(22,37);
			oldHitPoints[4] = GlobalCookies.HPCount[4];
			atLeastOne = true;
		}
		if (chestLikeness >= 2 && atLeastOne == true) {
			chest.gameObject.SetActive(true);
			GlobalCookies.HPCount[0] = oldHitPoints[0] + Random.Range(22,37);
			oldHitPoints[0] = GlobalCookies.HPCount[0];
			atLeastOne = true;
		}
		else if (atLeastOne == false){
			chest.gameObject.SetActive(true);
			GlobalCookies.HPCount[0] = oldHitPoints[0] + Random.Range(22,37) + 50;
			oldHitPoints[0] = GlobalCookies.HPCount[0];
		}
		
		DungeonFloor = DungeonFloor + 1;
		//this shit aint working and i dont know why
		if (DungeonBestScore >= 1) {
			DungeonBestScore = DungeonBestScore + 1;
		}
		
		dungeonText.GetComponent<Text>().text = "Dungeon " + DungeonLevel + " - " + DungeonFloor;
		dungeonText.GetComponent<Animation>().Play("FadeInAndOutDungeon");
		statusText.GetComponent<Text>().text = "A random " + EnemyName + " appears!";
		statusText.GetComponent<Animation>().Play("TextFade");
		DefeatedMonsterCheck.neverDone = true;
	}
}

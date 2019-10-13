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
	
	public List<Enemies> EnemyListD1;
	public Enemies enemy;
	
	private GameObject OldSprites;
	private GameObject NewSprite;
	
	
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
		var enemyspriteset = GameObject.Find("Enemy");
		
		enemyspriteset.gameObject.GetComponent<Animation>().Play("Runaway");
		this.gameObject.GetComponent<Animation>().Play("EnemyRunAway");
		StartCoroutine ( SpawnNew());
		
	}
	
	IEnumerator SpawnNew()
	{
		yield return new WaitForSeconds (1.5f);
		
		var randomSelection = Random.Range(0,EnemyListD1.Count);
		enemy = EnemyListD1[randomSelection];
		
		var randomNum = Random.Range(0,SpriteSelection.Count);
		this.gameObject.GetComponent<SpriteRenderer>().sprite = enemy.body;
		
		OldSprites = GameObject.Find("Enemy/testingSprite");
		NewSprite = GameObject.Find("Enemy/testingSprite/" + enemy.name);
		
		for(int i=0; i< OldSprites.transform.childCount; i++)
		{
			var child = OldSprites.transform.GetChild(i).gameObject;
			if(child != null)
				child.SetActive(false);
		}
		
		NewSprite.SetActive(true);
		for(int i=0; i< NewSprite.transform.childCount; i++)
		{
			var child = NewSprite.transform.GetChild(i).gameObject;
			if(child != null)
				child.SetActive(true);
		}
		
		if (chest != null) { DestroyClothes chestcode = chest.GetComponent<DestroyClothes>(); }
		if (crotch != null) { DestroyCrotch crotchcode = crotch.GetComponent<DestroyCrotch>(); }
		if (hand != null) { DestroyHand armcode = hand.GetComponent<DestroyHand>(); }
		if (leg != null) { DestroyLeg legcode = leg.GetComponent<DestroyLeg>(); }
		if (head != null) { DestroyHead headcode = head.GetComponent<DestroyHead>(); }
		
        chest = GameObject.Find("Enemy/testingSprite/" + enemy.name + "/Chest");
		crotch = GameObject.Find("Enemy/testingSprite/" + enemy.name + "/Crotch");
		hand = GameObject.Find("Enemy/testingSprite/" + enemy.name + "/Hand");
		head = GameObject.Find("Enemy/testingSprite/" + enemy.name + "/Head");
		leg = GameObject.Find("Enemy/testingSprite/" + enemy.name + "/Leg");
		
		var enemyspriteset = GameObject.Find("Enemy");
		this.gameObject.transform.localScale = new Vector3(enemy.scale,enemy.scale,enemy.scale);
		enemyspriteset.gameObject.transform.position = new Vector3(0,0,0);
		this.gameObject.transform.position = enemy.pos;
		
		/*
		if (enemy.chest.Count > 0) {
		chest.GetComponent<SpriteRenderer>().sprite = enemy.chest[0];
		
		chestcode.completeSprite = enemy.chest[0];
		chestcode.halfSprite = enemy.chest[1];
		chestcode.almostSprite = enemy.chest[2];
		}
		if (enemy.crotch.Count > 0) {
		crotch.GetComponent<SpriteRenderer>().sprite = enemy.crotch[0];
		
		crotchcode.completeSprite = enemy.crotch[0];
		crotchcode.halfSprite = enemy.crotch[1];
		crotchcode.almostSprite = enemy.crotch[2];
		}
		if (enemy.arm.Count > 0) {
		hand.GetComponent<SpriteRenderer>().sprite = enemy.arm[0];
		
		armcode.completeSprite = enemy.arm[0];
		armcode.halfSprite = enemy.arm[1];
		armcode.almostSprite = enemy.arm[2];
		}
		if (enemy.leg.Count > 0) {
		leg.GetComponent<SpriteRenderer>().sprite = enemy.leg[0];
		
		legcode.completeSprite = enemy.leg[0];
		legcode.halfSprite = enemy.leg[1];
		legcode.almostSprite = enemy.leg[2];
		}
		if (enemy.head.Count > 0) {
		head.GetComponent<SpriteRenderer>().sprite = enemy.head[0];
		
		headcode.completeSprite = enemy.head[0];
		headcode.halfSprite = enemy.head[1];
		headcode.almostSprite = enemy.head[2];
		}
		*/
		
		if(randomNum == 0) {
			EnemyName = "sexy spider assasain";
		}
		else if(randomNum == 1) {
			EnemyName = "cool spider assasain";
		}
		else if(randomNum == 2) {
			EnemyName = "loving spider assasain";
		}
		else {
			EnemyName = "unknown enemy";
		}
		
		enemyspriteset.gameObject.GetComponent<Animation>().Play("NewEnemyAppears");
		this.gameObject.GetComponent<Animation>().Play("NewEnemyFadesIn");
		
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
		
		if (crotchLikeness >= 3 && (crotch != null)) {
			crotch.SetActive(true);
			GlobalCookies.HPCount[1] = oldHitPoints[1] + Random.Range(22,37);
			oldHitPoints[1] = GlobalCookies.HPCount[1];
			atLeastOne = true;
		}
		if (handLikeness >= 4  && (hand != null)) {
			hand.SetActive(true);
			GlobalCookies.HPCount[2] = oldHitPoints[2] + Random.Range(22,37);
			oldHitPoints[2] = GlobalCookies.HPCount[2];
			atLeastOne = true;
		}
		if (headLikeness >= 6  && (head != null)) {
			head.SetActive(true);
			GlobalCookies.HPCount[3] = oldHitPoints[3] + Random.Range(22,37);
			oldHitPoints[3] = GlobalCookies.HPCount[3];
			atLeastOne = true;
		}
		if (legLikeness >= 5  && (leg != null)) {
			leg.SetActive(true);
			GlobalCookies.HPCount[4] = oldHitPoints[4] + Random.Range(22,37);
			oldHitPoints[4] = GlobalCookies.HPCount[4];
			atLeastOne = true;
		}
		if (chestLikeness >= 2 && atLeastOne == true  && (chest != null)) {
			chest.SetActive(true);
			GlobalCookies.HPCount[0] = oldHitPoints[0] + Random.Range(22,37);
			oldHitPoints[0] = GlobalCookies.HPCount[0];
			atLeastOne = true;
		}
		else if (atLeastOne == false  && (chest != null)){
			chest.SetActive(true);
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
		statusText.GetComponent<Text>().text = "A " + EnemyName + " appears!";
		statusText.GetComponent<Animation>().Play("TextFade");
		DefeatedMonsterCheck.neverDone = true;
	}
}

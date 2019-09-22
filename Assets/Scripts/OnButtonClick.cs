﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnButtonClick : MonoBehaviour
{
	public GameObject statusText;
	public GameObject hpText;
	public GameObject spriteEnemy;
	public GameObject youFainted;
	public GameObject enemyHitYou;
	
	//values used in the rest of the code
	public static int AttackPower = 1;
	public static int CritPower = 10;
	public static int RandomChance = 15;
	public Slider ExpBar;
	public Slider AttackBar;
	public Slider HPBar;
	
	void Start() {
		hpText.SetActive(false);
		enemyHitYou = GameObject.Find("EnemyHurtYou");
	}
	
	void Update() {
		if (GlobalCookies.HPCount[0] < 0) {
			GlobalCookies.HPCount[0] = 0;
		}
		if (GlobalCookies.HPCount[1] < 0) {
			GlobalCookies.HPCount[1] = 0;
		}
		if (GlobalCookies.HPCount[2] < 0) {
			GlobalCookies.HPCount[2] = 0;
		}
		if (GlobalCookies.HPCount[3] < 0) {
			GlobalCookies.HPCount[3] = 0;
		}
		if (GlobalCookies.HPCount[4] < 0) {
			GlobalCookies.HPCount[4] = 0;
		}
		
		int TotalHP = GlobalCookies.HPCount[0] + GlobalCookies.HPCount[1] + GlobalCookies.HPCount[2] + GlobalCookies.HPCount[3] + GlobalCookies.HPCount[4];
		if (TotalHP != 0 && AttackBar.value != 1) {
			AttackBar.value = AttackBar.value + 0.008f;
			
		}
		else if (AttackBar.value == 1) {
			AttackBar.value = 0;
			float enemyForce = Random.Range(1.80f, 5.14f);
			HPBar.value = HPBar.value - enemyForce;
			enemyHitYou.GetComponent<Text>().text = "-" + System.Math.Round(enemyForce, 2) + " HP";
			enemyHitYou.GetComponent<Animation>().Play("EnemyHurtYou-A");
			
		}
		
		if (HPBar.value <= 0) {
			Debug.Log("youre dead lmao");
			youFainted.SetActive(true);
		}
	}
}
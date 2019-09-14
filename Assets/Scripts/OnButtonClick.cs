using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnButtonClick : MonoBehaviour
{
	public GameObject statusText;
	public GameObject hpText;
	public GameObject spriteEnemy;
	
	//values used in the rest of the code
	public static int AttackPower = 1;
	public static int CritPower = 10;
	public int RandomChance = 15;
	public Slider ExpBar;
	public Slider AttackBar;
	public Slider HPBar;
	
	void Start() {
		hpText.SetActive(false);
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
			HPBar.value = HPBar.value - Random.Range(1.80f, 5.14f);
		}
	}
	
	// This code happens when an user hits a piece of clothing
	public void MinusHP() {
		hpText.SetActive(true);
		hpText.GetComponent<Text>().text = "-" + AttackPower + " HP";
		hpText.GetComponent<Animation>().Play("PunchedFade");
		hpText.GetComponent<Text>().color = Color.white;
		GlobalCookies.expNumber = GlobalCookies.expNumber + 1;
		spriteEnemy.GetComponent<Animation>().Play("GetHit");
	}

	// This code happens when an user hits a piece of clothing and it happens to be a critical hit
	public void CriticalMinusHP() {
		hpText.SetActive(true);
		statusText.GetComponent<Text>().text = "Critical Hit!";
		statusText.GetComponent<Animation>().Play("TextFade");
		hpText.GetComponent<Text>().text = "-" + (CritPower) + " HP";
		hpText.GetComponent<Animation>().Play("PunchedFade");
		hpText.GetComponent<Text>().color = Color.red;
		GlobalCookies.expNumber = GlobalCookies.expNumber + 5;
		spriteEnemy.GetComponent<Animation>().Play("GetHit");
	}
	
	public void ClickTheChest () {
		
		int critChance = Random.Range(0, RandomChance);
		if (EventSystem.current.currentSelectedGameObject.name == "ChestBtn") {
			if (GlobalCookies.HPCount[0] != 0) {
				if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[0] >= CritPower) {
					GlobalCookies.HPCount[0] -= CritPower;
					CriticalMinusHP();
				}
				else {
					GlobalCookies.HPCount[0] -= AttackPower;
					MinusHP();
				}
			}
		}
		else if (EventSystem.current.currentSelectedGameObject.name == "CrotchBtn") {
			if (GlobalCookies.HPCount[1] != 0) {
				if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[1] >= CritPower) {
					GlobalCookies.HPCount[1] -= CritPower;
					CriticalMinusHP();
				}
				else {
					GlobalCookies.HPCount[1] -= AttackPower;
					MinusHP();
				}
			}
		}
		else if (EventSystem.current.currentSelectedGameObject.name == "HandBtn" || EventSystem.current.currentSelectedGameObject.name == "HandBtn2") {
			if (GlobalCookies.HPCount[2] != 0) {
				if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[2] >= CritPower) {
					GlobalCookies.HPCount[2] -= CritPower;
					CriticalMinusHP();
				}
				else {
					GlobalCookies.HPCount[2] -= AttackPower;
					MinusHP();
				}
			}
		}
		else if (EventSystem.current.currentSelectedGameObject.name == "HeadBtn") {
			if (GlobalCookies.HPCount[3] != 0) {
				if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[3] >= CritPower) {
					GlobalCookies.HPCount[3] -= CritPower;
					CriticalMinusHP();
				}
				else {
					GlobalCookies.HPCount[3] -= AttackPower;
					MinusHP();
				}
			}
		}
		else if (EventSystem.current.currentSelectedGameObject.name == "LegBtn" || EventSystem.current.currentSelectedGameObject.name == "LegBtn2") {
			if (GlobalCookies.HPCount[4] != 0) {
				if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[4] >= CritPower) {
					GlobalCookies.HPCount[4] -= CritPower;
					CriticalMinusHP();
				}
				else {
					GlobalCookies.HPCount[4] -= AttackPower;
					MinusHP();
				}
			}
		}
	}
}
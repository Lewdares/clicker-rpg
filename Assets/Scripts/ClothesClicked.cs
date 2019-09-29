using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesClicked : MonoBehaviour
{
	public GameObject statusText;
	public GameObject hpText;
	public GameObject spriteEnemy;
	public GameObject pulsatingBox;
	public GameObject cgWindow;
	public int RandomChance = 15;
	public Slider ExpBar;
	public Slider AttackBar;
	public Slider HPBar;
	public Slider MPBar;
	public GameObject shieldBlocked;
	public static bool protectingWithShield = false;
	
    // Start is called before the first frame update
    void Start()
    {
        shieldBlocked = GameObject.Find("shieldBlocked");
    }
	
	// This code happens when an user hits a piece of clothing
	public void MinusHP() {
		hpText.SetActive(true);
		hpText.GetComponent<Text>().text = "-" + OnButtonClick.AttackPower + " HP";
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
		hpText.GetComponent<Text>().text = "-" + (OnButtonClick.CritPower) + " HP";
		hpText.GetComponent<Animation>().Play("PunchedFade");
		hpText.GetComponent<Text>().color = Color.red;
		GlobalCookies.expNumber = GlobalCookies.expNumber + 5;
		spriteEnemy.GetComponent<Animation>().Play("GetHit");
	}
	
	// This code happens when an user hits a piece of clothing with fire
	public void FireHP(int damageDealtByFireTwo) {
		hpText.SetActive(true);
		hpText.GetComponent<Text>().text = "-" + damageDealtByFireTwo + " HP";
		hpText.GetComponent<Animation>().Play("PunchedFade");
		hpText.GetComponent<Text>().color = new Color(1.0f, 0.64f, 0.0f);
		GlobalCookies.expNumber = GlobalCookies.expNumber + 1;
		spriteEnemy.GetComponent<Animation>().Play("GetHit");
	}

    // Update is called once per frame
    void OnMouseDown()
    {
		if (MouseCursor.isSwordActive == true) {
			int critChance = Random.Range(0, RandomChance);
			if (this.gameObject.name == "Chest") {
				if (GlobalCookies.HPCount[0] != 0) {
					if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[0] >= OnButtonClick.CritPower) {
						GlobalCookies.HPCount[0] -= OnButtonClick.CritPower;
						CriticalMinusHP();
					}
					else {
						GlobalCookies.HPCount[0] -= OnButtonClick.AttackPower;
						MinusHP();
					}
				}
			}
			else if (this.gameObject.name == "Crotch") {
				if (GlobalCookies.HPCount[1] != 0) {
					if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[1] >= OnButtonClick.CritPower) {
						GlobalCookies.HPCount[1] -= OnButtonClick.CritPower;
						CriticalMinusHP();
					}
					else {
						GlobalCookies.HPCount[1] -= OnButtonClick.AttackPower;
						MinusHP();
					}
				}
			}
			else if (this.gameObject.name == "Hand") {
				if (GlobalCookies.HPCount[2] != 0) {
					if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[2] >= OnButtonClick.CritPower) {
						GlobalCookies.HPCount[2] -= OnButtonClick.CritPower;
						CriticalMinusHP();
					}
					else {
						GlobalCookies.HPCount[2] -= OnButtonClick.AttackPower;
						MinusHP();
					}
				}
			}
			else if (this.gameObject.name == "Head") {
				if (GlobalCookies.HPCount[3] != 0) {
					if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[3] >= OnButtonClick.CritPower) {
						GlobalCookies.HPCount[3] -= OnButtonClick.CritPower;
						CriticalMinusHP();
					}
					else {
						GlobalCookies.HPCount[3] -= OnButtonClick.AttackPower;
						MinusHP();
					}
				}
			}
			else if (this.gameObject.name == "Leg") {
				if (GlobalCookies.HPCount[4] != 0) {
					if (critChance == (RandomChance - 1) && GlobalCookies.HPCount[4] >= OnButtonClick.CritPower) {
						GlobalCookies.HPCount[4] -= OnButtonClick.CritPower;
						CriticalMinusHP();
					}
					else {
						GlobalCookies.HPCount[4] -= OnButtonClick.AttackPower;
						MinusHP();
					}
				}
			}
		}
		else if (MouseCursor.isCharmActive == true) {
			if (MPBar.value >= 0.25f) {
				int TotalHP = GlobalCookies.HPCount[0] + GlobalCookies.HPCount[1] + GlobalCookies.HPCount[2] + GlobalCookies.HPCount[3] + GlobalCookies.HPCount[4];
				if (TotalHP <= 35) {
					//make cursor appear again
					MouseCursor.isSwordActive = false;
					MouseCursor.isCharmActive = false;
					Cursor.visible = true;
					//TO-DO: bring cursor prev active to original place
					EnableSwordCursor.mouseCharm.transform.position = new Vector3(EnableSwordCursor.charmHolder.transform.position.x, this.transform.position.y, this.transform.position.z);
					EnableSwordCursor.mouseSword.transform.position = new Vector3(EnableSwordCursor.swordHolder.transform.position.x, this.transform.position.y, this.transform.position.z);
					
					hpText.SetActive(true);
					MPBar.value = MPBar.value - 0.30f;
					hpText.GetComponent<Text>().text = "CHARMED!";
					hpText.GetComponent<Animation>().Play("PunchedFade");
					hpText.GetComponent<Text>().color = Color.magenta;
					statusText.GetComponent<Text>().text = "You charmed the enemy!";
					statusText.GetComponent<Animation>().Play("TextFade");
					cgWindow.GetComponent<Animation>().Play("CGStart");
				}
				else {
					hpText.SetActive(true);
					MPBar.value = MPBar.value - 0.30f;
					hpText.GetComponent<Text>().text = "MISS!";
					hpText.GetComponent<Animation>().Play("PunchedFade");
					hpText.GetComponent<Text>().color = Color.yellow;
					statusText.GetComponent<Text>().text = "Her HP is not low enough to charm her!";
					statusText.GetComponent<Animation>().Play("TextFade");
				}
			}
		}
		else if (MouseCursor.isShieldActive == true) {
			if (MPBar.value >= 0.15f && protectingWithShield == false) {	
				Debug.Log("test for shield");
				protectingWithShield = true;
				shieldBlocked.GetComponent<Animation>().Play("shieldBlocked");
				MPBar.value = MPBar.value - 0.15f;
			}
		}
		else if (MouseCursor.isFireActive == true) {
			if (MPBar.value >= 0.20f) {
				MPBar.value = MPBar.value - 0.20f;
				int damageDealtByFire = Random.Range(8,15) + OnButtonClick.AttackPower;
				if (this.gameObject.name == "Chest") {
					if (GlobalCookies.HPCount[0] != 0) {
						GlobalCookies.HPCount[0] -= damageDealtByFire;
					}
				}
				else if (this.gameObject.name == "Crotch") {
					if (GlobalCookies.HPCount[1] != 0) {
						GlobalCookies.HPCount[1] -= damageDealtByFire;
					}
				}
				else if (this.gameObject.name == "Hand") {
					if (GlobalCookies.HPCount[2] != 0) {
						GlobalCookies.HPCount[2] -= damageDealtByFire;
					}
				}
				else if (this.gameObject.name == "Head") {
					if (GlobalCookies.HPCount[3] != 0) {
						GlobalCookies.HPCount[3] -= damageDealtByFire;
					}
				}
				else if (this.gameObject.name == "Leg") {
					if (GlobalCookies.HPCount[4] != 0) {
						GlobalCookies.HPCount[4] -= damageDealtByFire;
					}
				}
			FireHP(damageDealtByFire);
			}
		}
		else {
			pulsatingBox.GetComponent<Animation>().Play("UseYourTools");
		}
    }
}

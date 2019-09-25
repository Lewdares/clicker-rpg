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
	public int RandomChance = 15;
	public Slider ExpBar;
	public Slider AttackBar;
	public Slider HPBar;
	
    // Start is called before the first frame update
    void Start()
    {
        
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
			Debug.Log("TODO: charms");
		}
		else {
			pulsatingBox.GetComponent<Animation>().Play("UseYourTools");
		}
    }
}

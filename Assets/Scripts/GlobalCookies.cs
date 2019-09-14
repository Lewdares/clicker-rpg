using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCookies : MonoBehaviour
{
	int i = 0;
	
	List<GameObject> HPDisplay;
	public static List<int> HPCount;
	
	public GameObject ChestDisplay;
	public GameObject CrotchDisplay;
	public GameObject HandDisplay;
	public GameObject HeadDisplay;
	public GameObject LegDisplay;
	
	public static int levelNumber = 0;
	public static float expNumber = 0.0f;
	
	public Slider ExpBar;
	public GameObject LvDisplay;
	public GameObject statusText;
	
	void Start() {
		ChestDisplay = GameObject.Find("ChestHP");
		CrotchDisplay = GameObject.Find("CrotchHP");
		HandDisplay = GameObject.Find("HandHP");
		HeadDisplay = GameObject.Find("HeadHP");
		LegDisplay = GameObject.Find("LegHP");
		HPDisplay = new List<GameObject>{ChestDisplay,CrotchDisplay,HandDisplay,HeadDisplay,LegDisplay};
		// If anyone else from Slimekitten sees this code: I'm sorry for the spaghetti code. I'm mashing shit together until it hopefully works right now
		HPCount = new List<int>{100,80,0,0,0};
	}
	
	void Update() {
		for(i = 0; i < HPCount.Count; i++)
		{
			HPDisplay[i].GetComponent<Text>().text = HPCount[i] + "hp";
		}
		
		if (expNumber >= ExpBar.maxValue) {
			levelNumber = levelNumber + 1;
			expNumber = 0;
			ExpBar.maxValue = ExpBar.maxValue + 25;
			
			LvDisplay.GetComponent<Text>().text = "LV " + levelNumber;
			
			statusText.GetComponent<Text>().text = "Level up!";
			statusText.GetComponent<Animation>().Play("TextFade");
			
			OnButtonClick.AttackPower = OnButtonClick.AttackPower + 1;
			OnButtonClick.CritPower = OnButtonClick.CritPower + 1;
		}
		else {
			ExpBar.value = expNumber;
		}
	}
}

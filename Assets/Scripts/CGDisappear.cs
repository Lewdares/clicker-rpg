using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGDisappear : MonoBehaviour
{
	public GameObject statusText;
	public Slider MPBar;
	public GameObject cgWindow;
	public GameObject swordHolder;
	public GameObject charmHolder;
	
    // Start is called before the first frame update
    void OnMouseDown()
    {
		Debug.Log("end!!");
        cgWindow.GetComponent<Animation>().Play("CGEnd");
		
		StartCoroutine ( RemoveEnemy());
    }
	
	IEnumerator RemoveEnemy()
	{
		yield return new WaitForSeconds (0.5f);
		
		//make enemy ded
		GlobalCookies.HPCount[0] = 0;
		GlobalCookies.HPCount[1] = 0;
		GlobalCookies.HPCount[2] = 0;
		GlobalCookies.HPCount[3] = 0;
		GlobalCookies.HPCount[4] = 0;
		
		//recover mana
		MPBar.value = MPBar.value + 0.50f;
		
		//message
		statusText.GetComponent<Text>().text = "The enemy ran away! You recovered some Mana!";
		statusText.GetComponent<Animation>().Play("TextFade");
		GlobalCookies.IsPaused = false;
	}
}

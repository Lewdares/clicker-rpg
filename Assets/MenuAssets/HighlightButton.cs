using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighlightButton : MonoBehaviour
{
	public GameObject transBar; //transition bar, you silly fuck
	void Start()
	{
		transBar = GameObject.Find("TransitionBars");
	}
	void OnMouseEnter()
	{
		Debug.Log("hi friend!");
    }
    void OnMouseExit()
    {
        Debug.Log("bye :0");
    }
	
	// this happens when you click on the "play game" btn
	IEnumerator PlayGame()
	{
		transBar.GetComponent<Animation>().Play("transitionmenu");
		yield return new WaitForSeconds (0.8f);
		SceneManager.LoadScene("SampleScene");
	}
	void OnMouseDown()
	{
		if (this.gameObject.name == "StartButton") {
			StartCoroutine (PlayGame()); 
		}
		else if (this.gameObject.name == "PatreonButton") {
			//i want to elaborate more on this but whatever
			Application.OpenURL("https://www.patreon.com/SlimeKitten");
		}
		else if (this.gameObject.name == "DiscordButton") {
			Application.OpenURL("https://discord.gg/c6sTVZX");
		}
	}
}

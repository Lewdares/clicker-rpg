using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightButton : MonoBehaviour
{
	private Color startcolor;
	void OnMouseEnter()
	{
		this.GetComponent<Animation>().Play("highlightbutton");
		Debug.Log("hi friend!");
    }
    void OnMouseExit()
    {
        Debug.Log("bye :0");
    }
}

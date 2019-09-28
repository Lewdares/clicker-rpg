using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
	public static bool isSwordActive = false;
	public static bool isCharmActive = false;
	public static bool isShieldActive = false;
	public static bool isFireActive = false;
	
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (isSwordActive == true){
			if (this.gameObject.name == "sword") {
				Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.position = cursorPos;
				Cursor.visible = false;
			}
		}
		else if (isCharmActive == true) {
			if (this.gameObject.name == "charm") {
				Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.position = cursorPos;
				Cursor.visible = false;
			}
		}
		else if (isShieldActive == true) {
			if (this.gameObject.name == "shield") {
				Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.position = cursorPos;
				Cursor.visible = false;
			}
		}
		else if (isFireActive == true) {
			if (this.gameObject.name == "fire") {
				Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.position = cursorPos;
				Cursor.visible = false;
			}
		}
		else {
			Cursor.visible = true;
		}
    }
}

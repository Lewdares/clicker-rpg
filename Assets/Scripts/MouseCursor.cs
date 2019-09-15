using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
	public static bool isSwordActive = false;
	
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (isSwordActive == true){
			Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = cursorPos;
			Cursor.visible = false;
		}
		else {
			Cursor.visible = true;
		}
    }
}

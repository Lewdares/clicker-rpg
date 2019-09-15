using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSwordCursor : MonoBehaviour
{
	public GameObject mouseSword;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseDown()
    {
		if (MouseCursor.isSwordActive == false) {
			MouseCursor.isSwordActive = true;
		}
		else {
			MouseCursor.isSwordActive = false;
			mouseSword.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		}
    }
}

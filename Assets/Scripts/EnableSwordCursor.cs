using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSwordCursor : MonoBehaviour
{
	public GameObject mouseSword;
	public GameObject mouseCharm;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseDown()
    {
		if (this.gameObject.name == "swordHolder") {
			if (MouseCursor.isSwordActive == false) {
				MouseCursor.isSwordActive = true;
				
				//stop holding other items
				if (MouseCursor.isCharmActive == true) {
					MouseCursor.isCharmActive = false;
					mouseCharm.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z); //TO-DO: it shouldn't be this.transform.position
				}
				Debug.Log("now holding sword");
			}
			else {
				MouseCursor.isSwordActive = false;
				mouseSword.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
				Debug.Log("now not holding sword");
			}
		}
		else if (this.gameObject.name == "charmHolder") {
			if (MouseCursor.isCharmActive == false) {
				MouseCursor.isCharmActive = true;
				
				//stop holding other items
				if (MouseCursor.isSwordActive == true) {
					MouseCursor.isSwordActive = false;
					mouseSword.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z); //TO-DO: it shouldn't be this.transform.position
				}
				Debug.Log("now holding charm");
			}
			else {
				MouseCursor.isCharmActive = false;
				mouseCharm.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
				Debug.Log("now not holding charm");
			}
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSwordCursor : MonoBehaviour
{
	
	public static GameObject mouseSword;
	public static GameObject mouseCharm;
	public static GameObject mouseShield;
	public static GameObject mouseFire;
	public static GameObject swordHolder;
	public static GameObject charmHolder;
	public static GameObject shieldHolder;
	public static GameObject fireHolder;
	
    // Start is called before the first frame update
    void Start()
    {
        mouseSword = GameObject.Find("sword");
		mouseCharm = GameObject.Find("charm");
		mouseShield = GameObject.Find("shield");
		mouseFire = GameObject.Find("fire");
		swordHolder = GameObject.Find("swordHolder");
		charmHolder = GameObject.Find("charmHolder");
		shieldHolder = GameObject.Find("shieldHolder");
		fireHolder = GameObject.Find("fireHolder");
    }

    // Update is called once per frame
    void OnMouseDown()
    {
		if (this.gameObject.name == "swordHolder") {
			if (MouseCursor.isSwordActive == false) {
				MouseCursor.isSwordActive = true;
				
				//** stop holding other items **
				if (MouseCursor.isCharmActive == true) {
					MouseCursor.isCharmActive = false;
					mouseCharm.transform.position = new Vector3(charmHolder.transform.position.x, charmHolder.transform.position.y, this.transform.position.z); 
				}
				
				if (MouseCursor.isShieldActive == true) {
					MouseCursor.isShieldActive = false;
					mouseShield.transform.position = new Vector3(shieldHolder.transform.position.x, shieldHolder.transform.position.y, this.transform.position.z); 
				}
				
				if (MouseCursor.isFireActive == true) {
					MouseCursor.isFireActive = false;
					mouseFire.transform.position = new Vector3(fireHolder.transform.position.x, fireHolder.transform.position.y, this.transform.position.z); 
				}
				Debug.Log("now holding sword");
			}
			else {
				MouseCursor.isSwordActive = false;
				mouseSword.transform.position = new Vector3(swordHolder.transform.position.x, swordHolder.transform.position.y, this.transform.position.z);
				Debug.Log("now not holding sword");
			}
		}
		else if (this.gameObject.name == "charmHolder") {
			if (MouseCursor.isCharmActive == false) {
				MouseCursor.isCharmActive = true;
				
				//** stop holding other items **
				if (MouseCursor.isSwordActive == true) {
					MouseCursor.isSwordActive = false;
					mouseSword.transform.position = new Vector3(swordHolder.transform.position.x, swordHolder.transform.position.y, this.transform.position.z); 
				}
				
				if (MouseCursor.isShieldActive == true) {
					MouseCursor.isShieldActive = false;
					mouseShield.transform.position = new Vector3(shieldHolder.transform.position.x, shieldHolder.transform.position.y, this.transform.position.z); 
				}
				
				if (MouseCursor.isFireActive == true) {
					MouseCursor.isFireActive = false;
					mouseFire.transform.position = new Vector3(fireHolder.transform.position.x, fireHolder.transform.position.y, this.transform.position.z); 
				}
				Debug.Log("now holding charm");
			}
			else {
				MouseCursor.isCharmActive = false;
				mouseCharm.transform.position = new Vector3(charmHolder.transform.position.x, charmHolder.transform.position.y, this.transform.position.z);
				Debug.Log("now not holding charm");
			}
		}
		else if (this.gameObject.name == "shieldHolder") {
			if (MouseCursor.isShieldActive == false) {
				MouseCursor.isShieldActive = true;
				
				//** stop holding other items **
				if (MouseCursor.isSwordActive == true) {
					MouseCursor.isSwordActive = false;
					mouseSword.transform.position = new Vector3(swordHolder.transform.position.x, swordHolder.transform.position.y, this.transform.position.z); 
				}
				
				if (MouseCursor.isCharmActive == true) {
					MouseCursor.isCharmActive = false;
					mouseCharm.transform.position = new Vector3(charmHolder.transform.position.x, charmHolder.transform.position.y, this.transform.position.z); 
				}
				
				if (MouseCursor.isFireActive == true) {
					MouseCursor.isFireActive = false;
					mouseFire.transform.position = new Vector3(fireHolder.transform.position.x, fireHolder.transform.position.y, this.transform.position.z); 
				}
				Debug.Log("now holding shield");
			}
			else {
				MouseCursor.isShieldActive = false;
				mouseShield.transform.position = new Vector3(shieldHolder.transform.position.x, shieldHolder.transform.position.y, this.transform.position.z);
				Debug.Log("now not holding shield");
			}
		}
		else if (this.gameObject.name == "fireHolder") {
			if (MouseCursor.isFireActive == false) {
				MouseCursor.isFireActive = true;
				
				//** stop holding other items **
				if (MouseCursor.isSwordActive == true) {
					MouseCursor.isSwordActive = false;
					mouseSword.transform.position = new Vector3(swordHolder.transform.position.x, swordHolder.transform.position.y, this.transform.position.z); 
				}
				
				if (MouseCursor.isShieldActive == true) {
					MouseCursor.isShieldActive = false;
					mouseShield.transform.position = new Vector3(shieldHolder.transform.position.x, shieldHolder.transform.position.y, this.transform.position.z); 
				}
				
				if (MouseCursor.isCharmActive == true) {
					MouseCursor.isCharmActive = false;
					mouseCharm.transform.position = new Vector3(charmHolder.transform.position.x, charmHolder.transform.position.y, this.transform.position.z); 
				}
				Debug.Log("now holding fire");
			}
			else {
				MouseCursor.isFireActive = false;
				mouseFire.transform.position = new Vector3(fireHolder.transform.position.x, fireHolder.transform.position.y, this.transform.position.z);
				Debug.Log("now not holding fire");
			}
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyHand : MonoBehaviour
{
	private SpriteRenderer rend;
	public Sprite completeSprite, halfSprite, almostSprite;
	
	public int handHalfBreakingPoint;
	public int handAlmostBreakingPoint;
	
    // Start is called before the first frame update
    void Start()
    {
		rend = GetComponent<SpriteRenderer>();
		handHalfBreakingPoint = 66;
		handAlmostBreakingPoint = 33;
    }

    // Update is called once per frame
    void Update()
    {
		
        if (GlobalCookies.HPCount[2] <= handHalfBreakingPoint) {
			rend.sprite = halfSprite;
		}
        if (GlobalCookies.HPCount[2] <= handAlmostBreakingPoint) {
			rend.sprite = almostSprite;
		}
        if (GlobalCookies.HPCount[2] <= 0) {
			this.gameObject.SetActive(false);
			rend.sprite = completeSprite;
		}
    }
}

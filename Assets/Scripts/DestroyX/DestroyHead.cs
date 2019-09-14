using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHead : MonoBehaviour
{
	private SpriteRenderer rend;
	public Sprite completeSprite, halfSprite, almostSprite;
	
	public int halfBreakingPoint;
	public int almostBreakingPoint;
	
    // Start is called before the first frame update
    void Start()
    {
		rend = GetComponent<SpriteRenderer>();
		halfBreakingPoint = 66;
		almostBreakingPoint = 33;
    }

    // Update is called once per frame
    void Update()
    {
		
        if (GlobalCookies.HPCount[3] <= halfBreakingPoint) {
			rend.sprite = halfSprite;
		}
        if (GlobalCookies.HPCount[3] <= almostBreakingPoint) {
			rend.sprite = almostSprite;
		}
        if (GlobalCookies.HPCount[3] <= 0) {
			this.gameObject.SetActive(false);
			rend.sprite = completeSprite;
		}
    }
}

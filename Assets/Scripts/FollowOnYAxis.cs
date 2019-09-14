using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnYAxis : MonoBehaviour
{
     Transform bar;
  
     void Start() {
        bar = GameObject.Find("testingSprite").transform;
     }
  
     void Update() {
        transform.position = new Vector3(bar.position.x, transform.position.y, transform.position.z);
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies")]
public class Enemies : ScriptableObject {
	
	public new string name;
	public Sprite body;
	public float scale;
	public float Ypos;
	public Vector3 pos;
	
	/* LEGACY CODE! REMOVE WHEN AVAILABLE*/
	public List<Sprite> chest;
	public List<Sprite> arm;
	public List<Sprite> leg;
	public List<Sprite> head;
	public List<Sprite> crotch;
	
}

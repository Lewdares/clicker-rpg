using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies")]
public class Enemies : ScriptableObject {
	
	public new string name;
	public Sprite body;
	
	public List<Sprite> chest;
	public List<Sprite> arm;
	public List<Sprite> leg;
	public List<Sprite> head;
	public List<Sprite> crotch;
	
}

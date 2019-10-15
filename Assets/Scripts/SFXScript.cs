using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
	public AudioClip SFXCharm;
	public AudioClip SFXAttack;
	public AudioClip SFXShield;
	public AudioClip SFXFire;
	public AudioClip SFXMiss;
	public AudioSource SFXSource;
	
	public void PlayAttack()
	{
		SFXSource.clip = SFXAttack;
		SFXSource.Play();
	}
   
	public void PlayShield()
	{
		SFXSource.clip = SFXShield;
		SFXSource.Play();
	}
   
    public void PlayFire()
	{
		SFXSource.clip = SFXFire;
		SFXSource.Play();
	}
   
    public void PlayCharm()
	{
		SFXSource.clip = SFXCharm;
		SFXSource.Play();
	}
	
	public void PlayMiss()
	{
		SFXSource.clip = SFXMiss;
		SFXSource.Play();
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
	
	public AudioClip MusicIntro;
	public AudioClip MusicNext;
	public AudioClip SFXCharm;
	public AudioClip SFXAttack;
	public AudioSource MusicSource;
	public AudioSource SFXSource;
	
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicIntro;
		MusicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!MusicSource.isPlaying) {
			MusicSource.clip = MusicNext;
			MusicSource.Play();
		}
    }
	
	public void PlayAttack()
	{
		MusicSource.clip = SFXAttack;
		MusicSource.Play();
	}
   
	public void PlayShield()
	{
		Debug.Log("Hi there");
	}
   
    public void PlayFire()
	{
		Debug.Log("Hi there");
	}
   
    public void PlayCharm()
	{
		MusicSource.clip = SFXCharm;
		MusicSource.Play();
	}
}

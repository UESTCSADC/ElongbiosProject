using UnityEngine;
using System.Collections;

public class soundmaker : MonoBehaviour {
	public AudioClip stonehited,hitedlow,hitedmiddle,hitedsuper,boom,defence,nova;
	AudioSource stonehitedSound,hitedlowSound,hitedmiddleSound,hitedsuperSound,boomSound,defenceSound,novaSound;
	// Use this for initialization
	void Start () {
		stonehitedSound = gameObject.AddComponent<AudioSource> ();
        hitedlowSound = gameObject.AddComponent<AudioSource>();
        hitedlowSound.volume = 0.5f;
        hitedmiddleSound = gameObject.AddComponent<AudioSource>();
        hitedsuperSound = gameObject.AddComponent<AudioSource>();
        boomSound = gameObject.AddComponent<AudioSource>();
        defenceSound = gameObject.AddComponent<AudioSource>();
        novaSound = gameObject.AddComponent<AudioSource>();
        novaSound.clip = nova;
        defenceSound.clip = defence;
        boomSound.clip = boom;
        hitedlowSound.clip = hitedlow;
        hitedmiddleSound.clip = hitedmiddle;
        hitedsuperSound.clip = hitedsuper;
		stonehitedSound.clip = stonehited;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void playstonehited()
	{
		stonehitedSound.Play ();
	}
    public void playhitedlow()
    {
        hitedlowSound.Play();
    }
    public void playhitedmiddle()
    {
        hitedmiddleSound.Play();
    }
    public void playhitedsuper()
    {
        hitedsuperSound.Play();
    }
    public void playboom()
    {
        boomSound.Play();
    }
    public void playdefence()
    {
        defenceSound.Play();
    }
    public void playnova()
    {
        novaSound.Play();
    }
}

using UnityEngine;
using System.Collections;

public class nova : MonoBehaviour {
    public AudioSource[] audioSources;
	// Use this for initialization
	void Start () {
        audioSources = GameObject.Find("State").GetComponents<AudioSource>();
        audioSources[6].volume = 0.6f;
        audioSources[6].Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

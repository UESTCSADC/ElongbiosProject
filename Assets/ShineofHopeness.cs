using UnityEngine;
using System.Collections;

public class ShineofHopeness : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform checkpoint = GameObject.Find("checkpoint").transform;
		this.transform.position = new Vector3(checkpoint.position.x,checkpoint.position.y + GameObject.Find ("Elongbios").GetComponent<Elongbios> ().Radius+GameObject.Find ("Elongbios").GetComponent<Elongbios> ().HopenessFlyHeight/2,0);
	}
}

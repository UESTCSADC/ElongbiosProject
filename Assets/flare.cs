using UnityEngine;
using System.Collections;

public class flare : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject elongbios = GameObject.Find ("Elongbios");
		this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y,  ( elongbios.GetComponent<Elongbios> ().Radius + 41)/16.7f);
	}
}

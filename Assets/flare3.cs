﻿using UnityEngine;
using System.Collections;

public class flare3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject elongbios = GameObject.Find ("Elongbios");
		this.transform.localPosition = new Vector3 (( elongbios.GetComponent<Elongbios> ().Radius + 41)/16.7f, this.transform.localPosition.y, this.transform.localPosition.z);
	}
}

using UnityEngine;
using System.Collections;

public class flare3_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject elongbios = GameObject.Find ("Elongbios1");
		this.transform.localPosition = new Vector3 (( elongbios.GetComponent<Elongbios1> ().Radius + 41)/17.8f, this.transform.localPosition.y, this.transform.localPosition.z);
	}
}

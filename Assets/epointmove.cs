using UnityEngine;
using System.Collections;

public class epointmove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition = GameObject.Find ("checkpoint").transform.localPosition + new Vector3 (0, 34, 10.0f);
	}
}

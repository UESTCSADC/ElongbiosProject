using UnityEngine;
using System.Collections;

public class damageM : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("State").GetComponent<soundmaker>().playhitedmiddle();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

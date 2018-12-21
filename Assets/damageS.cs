using UnityEngine;
using System.Collections;

public class damageS : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("State").GetComponent<soundmaker>().playhitedlow();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

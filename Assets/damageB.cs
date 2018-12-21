using UnityEngine;
using System.Collections;

public class damageB : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("State").GetComponent<soundmaker>().playhitedsuper();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}

using UnityEngine;
using System.Collections;

public class goodbye : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!this.transform.Find("Explosion 13"))
            GameObject.DestroyImmediate(this.gameObject);

	}
}

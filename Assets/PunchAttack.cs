using UnityEngine;
using System.Collections;

public class PunchAttack : MonoBehaviour {

	public GameObject terrar;
	bool hited = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!terrar.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attach1"))
			hited = true;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (hited == true) {
			GameObject elongbios = GameObject.Find ("Elongbios");
			if (collider == elongbios.GetComponent<BoxCollider2D> () || collider == elongbios.GetComponent<CircleCollider2D> ()) 
			if (terrar.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.attach1")) {
				GameObject.Find ("Elongbios").GetComponent<Elongbios> ().BeAttack (500);
				hited = false;
			}
		}
	}
}

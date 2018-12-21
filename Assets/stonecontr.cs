using UnityEngine;
using System.Collections;

public class stonecontr : MonoBehaviour {

	public bool isrotate = false;
	public GameObject stonebreak;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(isrotate == true)
			this.transform.Rotate (new Vector3 (0, 0, 5));
		if (this.transform.position.x < 0)
			GameObject.Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject elongbios = GameObject.Find ("Elongbios");
		if (collider == elongbios.GetComponent<BoxCollider2D> () || collider == elongbios.GetComponent<CircleCollider2D> ()) {
			GameObject stonebreak1 = (GameObject)Instantiate(stonebreak,GameObject.Find("checkpoint").transform.position,Quaternion.identity);
			GameObject.Find("Elongbios").GetComponent<Elongbios>().BeAttack(300);
			GameObject.Find("State").GetComponent<soundmaker>().playstonehited();
			GameObject.Destroy (this.gameObject);
		}
	}
}

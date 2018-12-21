using UnityEngine;
using System.Collections;

public class FireControl1 : MonoBehaviour {
	public GameObject boom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < 0)
			GameObject.Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject elongbios = GameObject.Find ("Elongbios1");
		if (collider == elongbios.GetComponent<BoxCollider2D> () || collider == elongbios.GetComponent<CircleCollider2D> ()) {
			GameObject stonebreak1 = (GameObject)Instantiate(boom,GameObject.Find("checkpoint").transform.position,Quaternion.identity);
			GameObject.Find ("Elongbios1").GetComponent<Elongbios1> ().BeAttack (400);
			GameObject.Destroy (this.gameObject);
		}
	}
}

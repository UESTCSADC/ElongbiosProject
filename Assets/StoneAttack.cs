using UnityEngine;
using System.Collections;

public class StoneAttack : MonoBehaviour {

	static float speed = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void visible()
	{
		GameObject.Find ("Stone").SetActive (true);
	}

	public void shotstone()
	{
		Transform target = GameObject.Find ("checkpoint").transform;
		Transform stone = GameObject.Find ("Stone").transform;
		float arrivetime = (stone.transform.position.x - target.position.x) / speed;
		float deltay = stone.transform.position.y - target.position.y;
		float speedy = (deltay - 1 / 2 * 10 * arrivetime * arrivetime) / arrivetime;
		GameObject.Find ("Stone").GetComponent<Rigidbody2D> ().isKinematic = false;
		GameObject.Find ("Stone").GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, speedy);
	}
}

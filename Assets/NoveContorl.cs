using UnityEngine;
using System.Collections;

public class NoveContorl : MonoBehaviour {
	public GameObject NovaA,NovaD,NovaN,NovaM,MoveE;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Elongbios").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.ToSing") || GameObject.Find ("Elongbios").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.InSing")) {
			if (!GameObject.Find ("NovaNormal(Clone)")) {
				GameObject.DestroyImmediate (GameObject.Find ("NovaNormal(Clone)"));
				GameObject novan0 = (GameObject)Instantiate (NovaN, this.transform.position, Quaternion.identity);
				novan0.transform.Rotate (270, 0, 0);
				novan0.transform.parent = this.transform;
			} else {
				if (!GameObject.Find ("NovaNormal(Clone)").transform.Find ("NovaNormal"))
					GameObject.DestroyImmediate (GameObject.Find ("NovaNormal(Clone)"));
			}
		}
		else
			GameObject.DestroyImmediate (GameObject.Find ("NovaNormal(Clone)"));

		if (GameObject.Find ("Elongbios").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.ToDefence") || GameObject.Find ("Elongbios").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.InDefence")) {
			if (!GameObject.Find ("NovaDefence(Clone)")) {
				GameObject.DestroyImmediate (GameObject.Find ("NovaDefence(Clone)"));
				GameObject novan0 = (GameObject)Instantiate (NovaD, this.transform.position, Quaternion.identity);
				novan0.transform.Rotate (270, 0, 0);
				novan0.transform.parent = this.transform;
			}
		}
		else
			GameObject.DestroyImmediate (GameObject.Find ("NovaDefence(Clone)"));

		if (GameObject.Find ("Elongbios").GetComponent<Elongbios> ().avoid == true) {
			if (!GameObject.Find ("BMove(Clone)")) {
				GameObject.DestroyImmediate (GameObject.Find ("BMove(Clone)"));
				GameObject novan0 = (GameObject)Instantiate (MoveE, this.transform.position + new Vector3(0,-20,0), Quaternion.identity);
				novan0.transform.parent = this.transform;
			} else {
				if (!GameObject.Find ("BMove(Clone)").transform.Find ("BMove"))
					GameObject.DestroyImmediate (GameObject.Find ("BMove(Clone)"));
			}
		}
		else
			GameObject.DestroyImmediate (GameObject.Find ("BMove(Clone)"));


		if (GameObject.Find ("Elongbios").GetComponent<Elongbios> ().avoid == true) {
			if (!GameObject.Find ("NoveMove(Clone)")) {
				GameObject.DestroyImmediate (GameObject.Find ("NoveMove(Clone)"));
				Vector3 moveposition = new Vector3 (0, 0, 0);
				if (GameObject.Find ("Elongbios").GetComponent<Elongbios> ().count == -1)
					moveposition = GameObject.Find ("Elongbios").GetComponent<Elongbios> ().PositionA;
				if (GameObject.Find ("Elongbios").GetComponent<Elongbios> ().count == 0)
					moveposition = GameObject.Find ("Elongbios").GetComponent<Elongbios> ().PositionB;
				if (GameObject.Find ("Elongbios").GetComponent<Elongbios> ().count == 1)
					moveposition = GameObject.Find ("Elongbios").GetComponent<Elongbios> ().PositionC;
				GameObject novan0 = (GameObject)Instantiate (NovaM, moveposition, Quaternion.identity);
				novan0.transform.Rotate (270, 0, 0);
				novan0.transform.parent = this.transform;
			}
			else
			{
				Vector3 moveposition = new Vector3 (0, 0, 0);
				if (GameObject.Find ("Elongbios").GetComponent<Elongbios> ().count == -1)
					moveposition = GameObject.Find ("Elongbios").GetComponent<Elongbios> ().PositionA;
				if (GameObject.Find ("Elongbios").GetComponent<Elongbios> ().count == 0)
					moveposition = GameObject.Find ("Elongbios").GetComponent<Elongbios> ().PositionB;
				if (GameObject.Find ("Elongbios").GetComponent<Elongbios> ().count == 1)
					moveposition = GameObject.Find ("Elongbios").GetComponent<Elongbios> ().PositionC;
				GameObject.Find ("NoveMove(Clone)").transform.position = moveposition;
			}
		} 
	}

	public void novaA()
	{
		GameObject novan0 = (GameObject)Instantiate (NovaA, this.transform.position, Quaternion.identity);
		novan0.transform.Rotate (270, 0, 0);
		novan0.transform.parent = this.transform;
	}
}

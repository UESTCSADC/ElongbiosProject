using UnityEngine;
using System.Collections;

public class MoviePlayer : MonoBehaviour {
	public MovieTexture op;
	// Use this for initialization
	void Start () {
		op.Play();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			op.Stop ();
		if(!op.isPlaying)
			Application.LoadLevel("1start");
	}
	
	void OnGUI()
	{	
		GUI.DrawTexture(new Rect (0,0,Screen.width,Screen.height),op,ScaleMode.StretchToFill);		
		if (!op.isPlaying)
		{			
			op.Play();		
		}		
	}
}

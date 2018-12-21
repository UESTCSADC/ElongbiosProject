using UnityEngine;
using System.Collections;

public class flyback : MonoBehaviour {
	public GameObject elongbios;
	// Use this for initialization
	void Start () {
		elongbios =GameObject .Find ("Elongbios");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Flyback()
	{
		if (elongbios.transform.position==
		    elongbios.GetComponent<Elongbios>().PositionA)
		{
			this.transform.position=
				new Vector3(elongbios.GetComponent<Elongbios>().PositionAx,
				            elongbios.GetComponent<Elongbios>().PositionAy+
				            elongbios.GetComponent<Elongbios>().HopenessFlyHeight,-3);
		}else if (elongbios.transform.position==elongbios.GetComponent<Elongbios>().PositionB)
		{
			this.transform.position=
				new Vector3(elongbios.GetComponent<Elongbios>().PositionBx,
				            elongbios.GetComponent<Elongbios>().PositionBy+
				            elongbios.GetComponent<Elongbios>().HopenessFlyHeight,-3);
		}else if (elongbios.transform.position==elongbios.GetComponent<Elongbios>().PositionC)
		{
			this.transform.position=
				new Vector3(elongbios.GetComponent<Elongbios>().PositionCx,
				            elongbios.GetComponent<Elongbios>().PositionCy+
				            elongbios.GetComponent<Elongbios>().HopenessFlyHeight,-3);
		}
	}
}

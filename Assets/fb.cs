using UnityEngine;
using System.Collections;

public class fb : MonoBehaviour {

    public GameObject elongbios;
    // Use this for initialization
    void Start()
    {
        elongbios = GameObject.Find("Elongbios1");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Flyback()
    {
        if (elongbios.transform.position ==
            elongbios.GetComponent<Elongbios1>().PositionA)
        {
            this.transform.position =
                new Vector3(elongbios.GetComponent<Elongbios1>().PositionAx,
                            elongbios.GetComponent<Elongbios1>().PositionAy +
                            elongbios.GetComponent<Elongbios1>().HopenessFlyHeight, -3);
        }
        else if (elongbios.transform.position == elongbios.GetComponent<Elongbios1>().PositionB)
        {
            this.transform.position =
                new Vector3(elongbios.GetComponent<Elongbios1>().PositionBx,
                            elongbios.GetComponent<Elongbios1>().PositionBy +
                            elongbios.GetComponent<Elongbios1>().HopenessFlyHeight, -3);
        }
        else if (elongbios.transform.position == elongbios.GetComponent<Elongbios1>().PositionC)
        {
            this.transform.position =
                new Vector3(elongbios.GetComponent<Elongbios1>().PositionCx,
                            elongbios.GetComponent<Elongbios1>().PositionCy +
                            elongbios.GetComponent<Elongbios1>().HopenessFlyHeight, -3);
        }
    }
}

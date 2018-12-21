using UnityEngine;
using System.Collections;

public class sop : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform checkpoint = GameObject.Find("checkpoint").transform;
        this.transform.position = new Vector3(checkpoint.position.x, checkpoint.position.y + GameObject.Find("Elongbios1").GetComponent<Elongbios1>().Radius + GameObject.Find("Elongbios1").GetComponent<Elongbios1>().HopenessFlyHeight / 2, 0);
    }
}

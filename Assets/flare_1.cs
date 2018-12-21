using UnityEngine;
using System.Collections;

public class flare_1 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject elongbios = GameObject.Find("Elongbios1");
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, (elongbios.GetComponent<Elongbios1>().Radius + 41) / 17.8f);
    }
}

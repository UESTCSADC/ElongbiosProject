using UnityEngine;
using System.Collections;

public class lp1 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float radius = GameObject.Find("Elongbios1").GetComponent<Elongbios1>().Radius;
        this.transform.localScale = new Vector3(246.64f, (radius + 41.0f) / 41.0f * 270.0f, 2.0f);
    }
}

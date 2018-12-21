using UnityEngine;
using System.Collections;

public class stc : MonoBehaviour {

    public GameObject sp1;
    public GameObject sp2;
    public GameObject sp3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Find("HP").transform.localScale = new Vector3((1000 - GameObject.Find("Elongbios1").GetComponent<Elongbios1>().HP) / 1000, 1, 1);
        this.transform.Find("SP").transform.localScale = new Vector3((300 - GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp) / 300, 1, 1);
        if (GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp >= 100)
            sp1.SetActive(true);
        else
            sp1.SetActive(false);
        if (GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp >= 200)
            sp2.SetActive(true);
        else
            sp2.SetActive(false);
        if (GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp >= 300)
            sp3.SetActive(true);
        else
            sp3.SetActive(false);
    }
}

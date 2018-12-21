using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {

    public GameObject mouseshine;
    private Vector3 msPos;

    void Start()
    {
    }

    void OnGUI()
    {

        msPos = Input.mousePosition;
        mouseshine.transform.position = msPos + new Vector3(0,0,-2);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMousePositionOnMaterial : MonoBehaviour {

    Material material;
	// Use this for initialization
	void Start () {
        material = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Input.mousePosition);
        material.SetVector("_mouse", Input.mousePosition);
	}
}

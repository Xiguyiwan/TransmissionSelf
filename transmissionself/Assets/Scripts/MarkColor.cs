using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkColor : MonoBehaviour {
    public MeshRenderer[] Renderers;
	// Use this for initialization
	void Start () {
        var color = GetComponent<Player>().Info.AccentColor;
        GetComponent<MeshRenderer>().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

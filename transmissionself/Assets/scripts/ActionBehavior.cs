using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ActionBehavior : MonoBehaviour {
    public abstract Action GetClickAction();
    public Sprite ButtonPic;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

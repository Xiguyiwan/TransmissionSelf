using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ActionManager : MonoBehaviour {
    public static ActionManager Current;

    private List<Action> actionCalls = new List<Action>();

    public ActionManager()
    {
        Current = this;
    }
    public void OnButtonClick(int index)
    {
        actionCalls[index]();
    }
    public void ClearButtons()
    {
        actionCalls.Clear();
    }
	// Use this for initialization
	void Start () {
        ClearButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

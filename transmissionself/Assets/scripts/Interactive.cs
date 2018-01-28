using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour {
    private bool _Selected = false; //对象是否已被选中
    public bool Selected { get { return _Selected; } }
    public bool Swap = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Swap)
        {
            Swap = false;
            if (_Selected)
            {
                Deselect();
            }
            else
            {
                Select();
            }
        }
	}
    public void Select()
    {
        _Selected = true;
        foreach (var selection in GetComponents<Interaction>())
        {
            selection.Select();
        }
    }
    public void Deselect()
    {
        _Selected = false;
        foreach (var selection in GetComponents<Interaction>())
        {
            selection.Deselect();
        }
    }
}

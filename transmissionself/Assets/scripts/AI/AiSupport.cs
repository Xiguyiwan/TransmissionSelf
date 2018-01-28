using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSupport : MonoBehaviour {
    public List<GameObject> Drones = new List<GameObject>();//信仰者

    public PlayerSetupDefinition Player = null;

    public static AiSupport GetSupport(GameObject go)
    {
        return go.GetComponent<AiSupport>();
    }
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

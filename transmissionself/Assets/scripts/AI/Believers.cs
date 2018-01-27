using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using DG.Tweening;
public class Believers : MonoBehaviour {
    [SerializeField]
    private float Scale;
    [SerializeField]
    private float WalkSpeed;
    public string Faith;
    [SerializeField]
    private float Communication;
    [SerializeField]
    private float HP;
    // Use this for initialization
    [SerializeField]
    private Vector3 SliderScaleValue = new Vector3(1,1,1);
    
    
    private void Awake()
    {
        Scale = 1 * Random.Range(0.5f, 3);
    }
    void Start () {
        
        
        Debug.Log(SliderScaleValue);
        SliderScaleValue *= Scale;
        this.transform.localScale = SliderScaleValue;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            this.transform.localScale = new Vector3(1, 1, 1) * Scale;
            SliderScaleValue *= 0.5f;
            Debug.Log(SliderScaleValue + "this is scalevalue");
        }
	}
}

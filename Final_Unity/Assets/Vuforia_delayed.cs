using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Vuforia_delayed : MonoBehaviour {

	// Use this for initialization
	void Start () {
        VuforiaRuntime.Instance.InitVuforia();
        VuforiaBehaviour.Instance.enabled = true;
        Debug.Log("Should have vuforia!");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

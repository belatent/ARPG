using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockCanvas2d : MonoBehaviour {
	private float offset;
	// Use this for initialization
	void Start () {
		offset = transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Camera.main.transform.rotation;
		if(Input.GetKey(KeyCode.A)){
			transform.localPosition = new Vector3 (-offset, transform.localPosition.y, transform.localPosition.z);
		}

		if(Input.GetKey(KeyCode.D)){
			transform.localPosition = new Vector3 (offset, transform.localPosition.y, transform.localPosition.z);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUnit : MonoBehaviour {
	public bool enable { get; private set;}

	protected float horizontal;
	protected float vertical;

	void Start () {
		UnitInit ();
	}

	void Update () {
		UnitCtrl ();
	}

	protected virtual void UnitCtrl(){

	}

	protected virtual void UnitInit(){

	}

	public void setState(bool state){
		enable = state;
	}

	public void getActionInfo(){
		//get keyboard input info
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
	}
}

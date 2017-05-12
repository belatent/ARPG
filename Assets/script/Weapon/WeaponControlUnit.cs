using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControlUnit : ControlUnit {
	protected Animator anim;
	protected bool atkable;
	protected CharacterInfo info;

	protected override void UnitInit(){
		anim = GetComponent<Animator>();
		info = GetComponentInParent<CharacterInfo> ();
	}

	protected virtual void attack(){}


}

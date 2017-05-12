using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnit : PlayerControlUnit {
	public float speed = 80f;

	protected override void UnitCtrl(){
		if (enable) {
			move ();
		}
	}

	private void move(){
		//get info
		getActionInfo();

		//move
		if (rb.velocity.x * horizontal < speed) {
			if (horizontal < 0.1f && horizontal > -0.1f) {
				horizontal = 0;
			}
			rb.velocity = new Vector2 ( speed*horizontal, rb.velocity.y);
		}

		//filp
		if (horizontal < 0) {
			body.transform.rotation = new Quaternion (0, 180, 0, 0);
		}else {
			body.transform.rotation = new Quaternion (0, 0, 0, 0);
		}
	}
}

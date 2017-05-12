using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUnit : PlayerControlUnit {
	public bool EnableSecondJump = true;
	public float BasicJumpForce = 70f;
	public float uppingFactor = 3f; 
	public float fallingFactor = 0.2f; 
	public float maximumReachableVerticalVelocity = 300f;

	private bool jumping; 
	private bool secondJump; 

	protected override void UnitCtrl(){
		if (enable) {
			jump ();
		}
	}

	private void jump(){
		if (isOnGround ()) {
			jumping = false;
			secondJump = false;

			if (Input.GetButton ("Jump")) {
				rb.velocity = new Vector2 (horizontal, uppingFactor* BasicJumpForce);
				secondJump = true;
			}
		} 
		else {
			jumping = true;
			//Limit Jump Heights 
			if (rb.velocity.y <= maximumReachableVerticalVelocity && rb.velocity.y > 0) {
				rb.velocity = new Vector2 (horizontal, (-BasicJumpForce*fallingFactor)+rb.velocity.y);
			}

			if (rb.velocity.y <= 0 ) {
				rb.velocity = new Vector2 (horizontal, (-BasicJumpForce*fallingFactor)+rb.velocity.y);
			}
			//second jump
			if (EnableSecondJump && secondJump && Input.GetButtonDown ("Jump")) {
				rb.velocity = new Vector2 (horizontal, BasicJumpForce*uppingFactor);
				secondJump = false;
			}
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;

		Collider2D collider = GetComponent<Collider2D> ();

		if(groundChecker != null){
			Vector3 checkerLeftBound = groundChecker.transform.position;
			Vector3 playerLeftBound = transform.position;
			Vector3 checkerRightBound = groundChecker.transform.position;
			Vector3 playerRightBound = transform.position;

			playerLeftBound.x = checkerLeftBound.x = collider.bounds.min.x;
			playerRightBound.x = checkerRightBound.x = collider.bounds.max.x;

			Gizmos.DrawLine (checkerLeftBound, playerLeftBound);
			Gizmos.DrawLine (checkerRightBound, playerRightBound);
		}
	}
}

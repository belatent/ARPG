using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlUnit : ControlUnit {
	protected Rigidbody2D rb;
	protected GameObject body;
	protected GameObject groundChecker;
	protected SpriteRenderer sr;

	protected override void UnitInit(){
		setState (true);
		//get body && groundChecker obj
		foreach (Transform child in transform) {
			if (child.gameObject.name == "Body") {
				body = child.gameObject;
			}
			if (child.gameObject.name == "GroundChecker") {
				groundChecker = child.gameObject;
			}
		}
		//get 
		rb = GetComponent<Rigidbody2D>();
		sr = body.GetComponent<SpriteRenderer> ();
	}

	public bool isOnGround(){
		Collider2D collider = GetComponent<Collider2D> ();

		Vector3 checkerLeftBound = groundChecker.transform.position;
		Vector3 playerLeftBound = transform.position;
		Vector3 checkerRightBound = groundChecker.transform.position;
		Vector3 playerRightBound = transform.position;

		playerLeftBound.x = checkerLeftBound.x = collider.bounds.min.x;
		playerRightBound.x = checkerRightBound.x = collider.bounds.max.x;

		bool groundLeft =  Physics2D.Linecast (playerLeftBound, checkerLeftBound, LayerMask.GetMask ("Ground"));
		bool groundRight =  Physics2D.Linecast (playerRightBound, checkerRightBound, LayerMask.GetMask ("Ground"));

		if (groundLeft || groundRight)
			return true;
		else
			return false;
	}
}

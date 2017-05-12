using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourUnit : PlayerControlUnit {
	public float knockBackForceHorizontal = 5000f;
	public float knockBackForceVertical = 5000f;
	public int freezeFrame = 40;
	public int invincibleFrame = 60;
	public int framePerFlash = 5;
	public Sprite playerImg;

	private MoveUnit mu;
	private int invincibleTime = 0;
	// Use this for initialization
	void Start (){
		UnitInit ();
		mu = GetComponent<MoveUnit> ();
	}

	protected override void UnitCtrl(){
		if (enable) {
			invincible ();
		}
	}

	private void invincible(){
		if (invincibleTime > freezeFrame) {
			mu.setState (false);
		} else if(invincibleTime <= freezeFrame && invincibleTime >= 1){
			mu.setState(true);
		}
		if (invincibleTime > 0) {
			invincibleTime--;
			if (invincibleTime % framePerFlash < 1) {
				sr.sprite = playerImg;
			} else {
				sr.sprite = null;
			}
		}
	}

	private void injure(float damage){
		if (invincibleTime <= 0) {
			CharacterInfo info = GetComponent<CharacterInfo> ();
			info.damaged (damage);
			invincibleTime = invincibleFrame;
			rb.AddForce (new Vector2 (-knockBackForceHorizontal * horizontal ,knockBackForceVertical));
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		//print ("HIT!1");
		if (other.gameObject.tag == "enemy") {
			//print ("HIT!2");
			CharacterInfo info = other.gameObject.GetComponent<CharacterInfo>();
			float damage = info.atk;
			injure (damage);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_StrightAttact : MonoBehaviour {
	AI_checkEmeny checkEmy;
	GameObject target;
	Rigidbody2D selfbd;
	Collider2D self;
	float term;
	// Use this for initialization
	void Start () {
		checkEmy = GetComponent<AI_checkEmeny> ();
		selfbd = GetComponent<Rigidbody2D> ();
		self = GetComponent<Collider2D> ();
		term = self.bounds.max.x - self.bounds.min.x;
	}
	
	// Update is called once per frame
	void Update () {
		self = GetComponent<Collider2D> ();

//		print (selfbd.velocity);
		if ((target = checkEmy.checkEmy()) && target.name == "Player") {
//			print (target.name);
			//Start doing strategy

			//Move to player

			Vector3 player = target.transform.position;

			Vector2 direction = (transform.position - player); 
//			print (direction);
			if (Mathf.Abs(direction.x) > term / 2) {
//				print (Mathf.Abs (direction.x) * (direction.x > 0f ? Vector2.left : Vector2.right));
				selfbd.AddForce (55 * Mathf.Abs (direction.x) * (direction.x > 0f ? Vector2.left : Vector2.right));

				print (term/2);
			} 
			print ("inside");
			print (direction.x);


		}
		else {
			//Not in sight
//			selfbd.AddForce (4000  * (Mathf.Sign(selfbd.velocity.x) >0f ? Vector2.left : Vector2.right));
////			print (Mathf.Sign(selfbd.velocity.x) > 0f ? Vector2.left : Vector2.right);
//			print(Mathf.Sign(selfbd.velocity.x) >0f ? Vector2.left : Vector2.right);
			//				
		}


	}
}

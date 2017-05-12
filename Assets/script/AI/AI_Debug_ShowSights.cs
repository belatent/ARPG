using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Debug_ShowSights : MonoBehaviour {
	
	Vector3 orig;
	Vector3 RStartTop;
	Vector3 RStartMid;
	Vector3 RStartBot;
	Vector3 LStartTop;
	Vector3 LStartMid;
	Vector3 LStartBot;
	Collider2D self;
	Rigidbody2D selfbd;
	// Use this for initialization
	void Start () {
		self = GetComponent<Collider2D> ();
		selfbd = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnDrawGizmos(){
		self = GetComponent<Collider2D> ();
		selfbd = GetComponent<Rigidbody2D> ();
		Vector3 RendPointT = orig;
		Vector3 RendPointM = orig;
		Vector3 RendPointE = orig;
		Vector3 LendPointT = orig;
		Vector3 LendPointM = orig;
		Vector3 LendPointE = orig;

		float term = self.bounds.max.x - self.bounds.min.x;
		orig = transform.position;
	
		RStartTop = RStartMid = RStartBot = orig;
		RStartTop.x += term*0.5f+0.1f;
		RStartMid.x += term*0.5f+0.1f;
		RStartBot.x += term*0.5f+0.1f;
		RStartTop.y += term*0.5f;
		RStartBot.y -= term*0.5f-0.1f;


		LStartTop = LStartMid = LStartBot = orig;
		LStartTop.x -= term*0.5f+0.1f;
		LStartMid.x -= term*0.5f+0.1f;
		LStartBot.x -= term*0.5f+0.1f;
		LStartTop.y += term*0.5f;
		LStartBot.y -= term*0.5f-0.1f;


		Gizmos.color = Color.green;

		RendPointT.x += 100+term*0.5f+0.1f;
		RendPointM.x += 100+term*0.5f+0.1f;
		RendPointE.x += 100+term*0.5f+0.1f;
		RendPointT.y += term*0.5f;
		RendPointE.y -= term*0.5f-0.1f;

		LendPointT.x -= 100+term*0.5f+0.1f;
		LendPointM.x -= 100+term*0.5f+0.1f;
		LendPointE.x -= 100+term*0.5f+0.1f;
		LendPointT.y += term*0.5f;
		LendPointE.y -= term*0.5f-0.1f;

		Gizmos.DrawLine (RStartTop, RendPointT);
		Gizmos.DrawLine (RStartMid, RendPointM);
		Gizmos.DrawLine (RStartBot, RendPointE);

	
		Gizmos.DrawLine (LStartTop, LendPointT);
		Gizmos.DrawLine (LStartMid, LendPointM);
		Gizmos.DrawLine (LStartBot, LendPointE);
	}
}


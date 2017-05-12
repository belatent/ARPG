using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_checkEmeny : MonoBehaviour {
	RaycastHit2D frontTop,backTop,frontMid,backMid,frontBot,backBot;
	Vector3 orig;
	Vector3 RStartTop;
	Vector3 RStartMid;
	Vector3 RStartBot;
	Vector3 LStartTop;
	Vector3 LStartMid;
	Vector3 LStartBot;
	Collider2D self;


//	public GameObject ply;
	// Use this for initialization
	void Start () {
		self = GetComponent<Collider2D> ();

	}

	// Update is called once per frame
	void Update () {

	}

	public GameObject checkEmy()
	{
		self = GetComponent<Collider2D> ();


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


		frontTop = Physics2D.Raycast (RStartTop, Vector2.right, 100);
		backTop = Physics2D.Raycast (LStartTop, Vector2.left, 100);

		frontMid = Physics2D.Raycast (RStartMid, Vector2.right, 100);
		backMid = Physics2D.Raycast (LStartMid, Vector2.left, 100);

		frontBot = Physics2D.Raycast (RStartBot, Vector2.right, 100);
		backBot = Physics2D.Raycast (LStartBot, Vector2.left, 100);
		GameObject res = null;


		try{
//			res = frontBot.collider.gameObject;	

			if(frontTop.collider!= null && frontTop.collider.gameObject != null)
			{
				res = frontTop.collider.gameObject;	
			}
			else if(frontMid.collider!= null && frontMid.collider.gameObject != null)
			{
				res = frontMid.collider.gameObject;	
			}
			else if(frontBot.collider!= null && frontBot.collider.gameObject != null)
			{
				res = frontBot.collider.gameObject;	
//				
			}
			else if(backTop.collider!= null && backTop.collider.gameObject != null)
			{
				res = backTop.collider.gameObject;	
//				print("2222222222");
			}
			else if(backMid.collider!= null && backMid.collider.gameObject != null)
			{
				res = backMid.collider.gameObject;	
			}
			else if(backBot.collider!= null && backBot.collider.gameObject != null)
			{
				res = backBot.collider.gameObject;	
			}
//			print (res.name);
		}
		catch(System.Exception e) {
			print (e);
		}
			
		return res;
//		
	}

	//Send raycast per several unit 
	RaycastHit2D[][] hits;
	public GameObject checkEmyAllSize(float percentage)
	{
		self = GetComponent<Collider2D> ();


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


		frontTop = Physics2D.Raycast (RStartTop, Vector2.right, 100);
		backTop = Physics2D.Raycast (LStartTop, Vector2.left, 100);

		frontMid = Physics2D.Raycast (RStartMid, Vector2.right, 100);
		backMid = Physics2D.Raycast (LStartMid, Vector2.left, 100);

		frontBot = Physics2D.Raycast (RStartBot, Vector2.right, 100);
		backBot = Physics2D.Raycast (LStartBot, Vector2.left, 100);
		GameObject res = null;


		try{
			//			res = frontBot.collider.gameObject;	

			if(frontTop.collider!= null && frontTop.collider.gameObject != null)
			{
				res = frontTop.collider.gameObject;	
			}
			else if(frontMid.collider!= null && frontMid.collider.gameObject != null)
			{
				//				res = frontMid.collider.gameObject;	
			}
			else if(frontBot.collider!= null && frontBot.collider.gameObject != null)
			{
				//				res = frontBot.collider.gameObject;	
				//				
			}
			else if(backTop.collider!= null && backTop.collider.gameObject != null)
			{
				//				res = backTop.collider.gameObject;	
				//				print("2222222222");
			}
			else if(backMid.collider!= null && backMid.collider.gameObject != null)
			{
				res = backMid.collider.gameObject;	
			}
			else if(backBot.collider!= null && backBot.collider.gameObject != null)
			{
				//				res = backBot.collider.gameObject;	
			}
			//			print (res.name);
		}
		catch(System.Exception e) {
			print (e);
		}

		return res;
		//		
	}
}

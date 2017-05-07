using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl2d : MonoBehaviour {
    private Animator anim;
    private bool atkable;
	private CharacterInfo info;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
		info = GetComponentInParent<CharacterInfo> ();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        attack();
    }
		
    private void attack()
    {
		AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo (0);
		BoxCollider2D bc = GetComponent<BoxCollider2D> ();
		if (!info.IsName("weapon_idle"))
        {
			
			//if (info.IsName ("weapon_atk")) {
				transform.tag = "weapon_atk";
//			} else
//			{
//				transform.tag = "weapon_idle";
//			}
            atkable = false;
			bc.enabled = true;
        }
        else
        {
			transform.tag = "weapon_idle";
			bc.enabled = false;
            atkable = true;
        }

        if (atkable && Input.GetMouseButton(0))
        {
            anim.Play("weapon_pose", -1, 0f);
        }
    }

	void OnCollisionEnter2D(Collision2D other){
		print ("HIT!1");
		if (transform.tag == "weapon_atk" && other.gameObject.tag == "enemy") {
			print ("HIT!2");
			CharacterInfo otherInfo = other.gameObject.GetComponent<CharacterInfo> ();
			print (otherInfo.atk);
			otherInfo.damaged (info.atk);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour {
	public float atk = 1;
	public float hp = 3;

	private float hp_curr;
	private Slider healUI;

	// Use this for initialization
	void Start () {
		hp_curr = hp;
		healUI = GetComponentInChildren<Slider> ();
		healUI.value = hp_curr / hp;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp_curr <= 0) {
			Destroy (gameObject);
		}
	}

	public void damaged(float damage){
		hp_curr -= damage;
		healUI.value = hp_curr / hp;
	}
}

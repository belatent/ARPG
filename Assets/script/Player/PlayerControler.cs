using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {
	public bool Move = true;
	public bool Jump = true;
	public bool Behaviour = true;

	private MoveUnit mu;
	private JumpUnit ju;
	private BehaviourUnit bu;
	// Use this for initialization
	void Start () {
		mu = GetComponent<MoveUnit> ();
		ju = GetComponent<JumpUnit> ();
		bu = GetComponent<BehaviourUnit> ();
	}
	
	// Update is called once per frame
	void Update () {
		mu.setState (Move);
		ju.setState (Jump);
		bu.setState (Behaviour);
	}
}

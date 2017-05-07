using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour {
	public int createTime = 5;
	public GameObject enemyPerfab;
	private GameObject enemy;
	private int lastTime = 0;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//print ((int)Time.time+"   "+lastTime);
		if ((int)Time.time >= lastTime && (int)Time.time % createTime == 0) {
			enemy = Instantiate (enemyPerfab) as GameObject;
			enemy.transform.position = transform.position;
			lastTime += createTime;
		}
	}
}

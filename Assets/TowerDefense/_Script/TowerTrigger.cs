using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour {

	public Tower twr;
	public bool lockE;
	public GameObject curTarget;


	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("enemyBug") && !lockE) {
			twr.target = other.gameObject.transform;
			curTarget = other.gameObject;
			lockE = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag("enemyBug") && other.gameObject == curTarget) {
			lockE = false;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!curTarget) {
			lockE = false;
		}
	}
}

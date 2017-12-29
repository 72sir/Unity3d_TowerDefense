using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTower : MonoBehaviour {

	public float Speed;
	public Transform target;
	public Tower twr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target)
		transform.position = Vector3.MoveTowards (transform.position, target.position, Time.deltaTime * Speed);

		if (!target) {
			Destroy (gameObject);
		}


	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.transform == target) {
			target.GetComponent<MoveToWayPoints> ().hp.GetComponent<HpBar>().Dmg (twr.dmg);
			Destroy (gameObject);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWayPoints : MonoBehaviour {

	public float speed;
	public Transform[] wayPoints;
	int curWayPointIndex = 0;

	public GameObject hp;
	public GlobalVariable globVar;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (curWayPointIndex < wayPoints.Length) {
			transform.position = Vector3.MoveTowards (transform.position, wayPoints[curWayPointIndex].position, Time.deltaTime * speed);
			transform.LookAt (wayPoints[curWayPointIndex].position);

			if (Vector3.Distance(transform.position, wayPoints[curWayPointIndex].position) < 0.5f) {
				curWayPointIndex++;
			}
		}

		if (hp.GetComponent<HpBar>().curHP <= 0) {
			
			Destroy (gameObject);
			Destroy (hp);
			globVar.Score (50);
		}

	}
}

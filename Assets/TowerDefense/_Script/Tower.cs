using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public Transform shootElement;
	public Transform LookAtObj;
	public int dmg = 10;
	public GameObject bullet;
	public Transform target;
	public float shootDelay;

	bool isShoot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			LookAtObj.transform.LookAt (target);

			if (!isShoot) {
				StartCoroutine (shoot());
			}
		}
	}

	IEnumerator shoot() {
		isShoot = true;
		yield return new WaitForSeconds(shootDelay);
		GameObject b = GameObject.Instantiate (bullet, shootElement.position, Quaternion.identity) as GameObject;
		b.GetComponent<bulletTower> ().target = target;
		b.GetComponent<bulletTower> ().twr = this;
		isShoot = false;
	}
}

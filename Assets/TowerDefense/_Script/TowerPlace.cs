using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour {

	public GameObject Tower;
	public bool empty = true;
	public Vector3 offset;
	public GameObject curTower;

	public GlobalVariable globVar;
	public int priceTower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {

		if (empty && !globVar.pause) {

			if ((globVar.score - priceTower) >= 0) {
				curTower = GameObject.Instantiate (Tower, transform.position + offset, Quaternion.identity) as GameObject;
				empty = false;

				globVar.Score (priceTower * -1);
			}
		}
	}
}

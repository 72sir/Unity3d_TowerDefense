using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

	public GameObject enemy;

	public int curHP = 30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint (enemy.transform.position);
		GetComponent<Text> ().text = curHP.ToString ();
	}

	public void Dmg (int count) {
		curHP -= count;
	}

}

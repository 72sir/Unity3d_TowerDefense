using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVariable : MonoBehaviour {

	public bool pause;
	public int score;
	public Text scoreText;


	void Update() {
		scoreText.text = score.ToString ();
	}

	public void Score(int val) {
		score += val;

		if ( score < 0 ) {
			score = 0;
		}

		Debug.Log (val + "true");

	}

}

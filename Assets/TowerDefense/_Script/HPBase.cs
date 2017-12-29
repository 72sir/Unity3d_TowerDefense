using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBase : MonoBehaviour {

	public int HP = 100;
	public Text HPText;

	public GameObject textWinLose;
	public bool keyEscape;

	public GlobalVariable globalVar;

	public WaveSpawn[] arrWaveSpawn;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HPText.text = HP.ToString ();

		bool end = false;

		for (int i = 0; i < arrWaveSpawn.Length-1; i++) {
			if (arrWaveSpawn[i].endSpawn && !end) {

				 GameObject enemys = GameObject.FindGameObjectWithTag("enemyBug");

				if (enemys == null) {
					Time.timeScale = 0;
					textWinLose.SetActive (true);
					textWinLose.GetComponent<Text> ().text = "You Win";
				}

			}
		}

		if (HP <= 0) {

			// Lose
			Time.timeScale = 0;
			textWinLose.SetActive (true);
			textWinLose.GetComponent<Text> ().text = "You Lose";

			if (Input.GetKeyDown(KeyCode.Escape)) {
				keyEscape = !keyEscape;
			}

			if (!keyEscape) {
				textWinLose.SetActive (true);
				globalVar.pause = true;
			} else {
				textWinLose.SetActive (false);
				globalVar.pause = true;
			}

		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("enemyBug")) {
			HP -= 25;
			Destroy (other.gameObject);
			Destroy (other.GetComponent<MoveToWayPoints> ().hp);
		}


	}
}

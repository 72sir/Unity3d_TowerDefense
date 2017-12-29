using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartTime : MonoBehaviour {

	public Text startTextCount;
	public float time;
	public float sec;
	public int count = 3;
	public float timeScale;

	public GameObject menuObj;

	public GlobalVariable globVar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = timeScale;

		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (timeScale >= 1) {
				timeScale = 0;
				globVar.pause = true;
				menuObj.SetActive (true);
			} else {
				menuObj.SetActive (false);
				timeScale = 1;
				globVar.pause = false;
			}
		}

		if (timeScale == 1) {
			StartTimeGame ();
		}

	}

	void StartTimeGame() {
		if (count > 0) {
			time += Time.deltaTime;
			sec += time / 40;

			if (sec >= 1) {

				time = 0;
				sec = 0;
				count--;

			} else {
				startTextCount.text = count.ToString ();
			}
		} else {
			startTextCount.text = "";
		}

	}

	public void GameGo() {
		timeScale = 1;
		menuObj.SetActive (false);
	}

	public void GameBasicMenu() {
		SceneManager.LoadScene ("Menu");
	}

	public void GameExitWindows () {
		Application.Quit ();
	}

}

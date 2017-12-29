using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour {

	public int WavaSize;
	public GameObject EnemyPrefab;
	public float EnemyInterval;

	public Transform spawnPoint;
	public float startTime;

	public Transform[] wayPoints;

	public GameObject HP;

	int enemyCount = 0;
	public GameObject canvas;
	public GlobalVariable globalVar;

	public bool endSpawn;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", startTime, EnemyInterval); 
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyCount >= WavaSize) {
			CancelInvoke ("SpawnEnemy");

			endSpawn = true;
		}


	}

	void SpawnEnemy() {
		enemyCount++;
		GameObject enemy = GameObject.Instantiate (EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
		enemy.GetComponent<MoveToWayPoints> ().wayPoints = wayPoints;
		GameObject hp = GameObject.Instantiate (HP, Vector3.zero, Quaternion.identity) as GameObject;
		hp.transform.SetParent (canvas.transform);
		hp.GetComponent<HpBar> ().enemy = enemy;
		enemy.GetComponent<MoveToWayPoints> ().hp = hp;

		enemy.GetComponent<MoveToWayPoints> ().globVar = globalVar;
	}
}

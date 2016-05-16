using UnityEngine;
using System.Collections;

public class TrapSpawner : MonoBehaviour {

	enum TrapTypes
	{
		E_TROMBONE = 0,
		E_VIOLIN = 1,
	};

	//object prefabs that need to be dragged on
	public GameObject Trombone;
	public GameObject Violin;
	public GameObject Player;

	public const int MaxNumberOfTombones = 10;

	GameObject[] trombones = new GameObject[MaxNumberOfTombones];

	//minimum time between traps spawns
	[Range(0,5)]
	float minimumSpawnGap;
	//maximum time between trap spawns
	[Range(5, 10)]
	float maximumSpawnGap;
	//maximum amount it will spawn left or right of the play
	[Range(0,5)]
	public float randMoveAmount;
	//how long since last trap spawned
	float timeSinceLastSpawn;
	//how long until next spawn
	float spawnTimer = 0;

	int numberOfDifferentTraps;
	// Use this for initialization
	void Start () {
		//how many trap types there are
		numberOfDifferentTraps = System.Enum.GetValues(typeof(TrapTypes)).Length;
		//y value of the top of the screen
		float screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
		screenHeight += 0.1f;
		//give spawn timer its first random value between min and max gap
		spawnTimer = Random.Range(minimumSpawnGap, maximumSpawnGap);
	}
	
	// Update is called once per frame
	void Update () {

		//incremant how long since last spawn
		timeSinceLastSpawn += Time.deltaTime;

		//if the time since last spawn is greater than spawn timer, spawn a trap, reset the timer and set a new spawn time
		if (timeSinceLastSpawn >= spawnTimer)
		{
			SpawnRandomTrap();
			timeSinceLastSpawn = 0;
			spawnTimer = Random.Range(minimumSpawnGap, maximumSpawnGap);
		}

	
	}

	void SpawnRandomTrap()
	{

		int trapNumber = Random.Range(0, numberOfDifferentTraps);

		//whichever trap is seleceted randomly, find the next inactive trap in the pool and set it to active
		switch (trapNumber)
		{
			case (int)TrapTypes.E_TROMBONE:
				Trombone.gameObject.SetActive(true);
				break;
			case (int)TrapTypes.E_VIOLIN:
				Instantiate(Violin, new Vector3(Player.transform.position.x + randMoveAmount, 100, Player.transform.position.z), Player.transform.rotation);
				break;
		}
	}
}

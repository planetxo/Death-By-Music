using UnityEngine;
using System.Collections;

public class TrapSpawner : MonoBehaviour {

	//order: harp, violin, cello, drum, tuba, trumpet, clarinet, sax
	//used to determin if an instrument should spawn or not
	public bool[] m_spawnTrapsBool = new bool[8];

	//object prefabs that need to be dragged on
	public GameObject harp;
	public GameObject violin;
	public GameObject cello;
	public GameObject drum;
	public GameObject tuba;
	public GameObject trumpet;
	public GameObject clarinet;
	public GameObject sax;
	public GameObject Player;

	//Max number of traps available at any given time
	const int maxNumberOfTraps = 10;
	const int maxNumberOfHarps = maxNumberOfTraps;
	const int maxNumberOfViolins = maxNumberOfTraps;
	const int maxNumberOfCellos = maxNumberOfTraps;
	const int maxNumberOfDrums = maxNumberOfTraps;
	const int maxNumberOfTubas = maxNumberOfTraps;
	const int maxNumberOfTrumpets = maxNumberOfTraps;
	const int maxNumberOfClarinets = maxNumberOfTraps;
	const int maxNumberOfSaxs = maxNumberOfTraps;

	//current number of traps on the screen
	public int trapCount;
	//float storing y pos of top of screen
	float screenHeight;

	//creates a pool of each type of instrument, to the maximum amount on screen possible
	GameObject[] harpPool = new GameObject[maxNumberOfHarps];
	GameObject[] violinPool = new GameObject[maxNumberOfViolins];
	GameObject[] celloPool = new GameObject[maxNumberOfCellos];
	GameObject[] drumPool = new GameObject[maxNumberOfDrums];
	GameObject[] tubaPool = new GameObject[maxNumberOfTubas];
	GameObject[] trumpetPool = new GameObject[maxNumberOfTrumpets];
	GameObject[] clarinetPool = new GameObject[maxNumberOfClarinets];
	GameObject[] saxPool = new GameObject[maxNumberOfSaxs];


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



	// Use this for initialization
	void Start () {
		//trapCount = 10;
		for (int i = 0; i < 8; i++)
		{ m_spawnTrapsBool[i] = false; }
		//y value of the top of the screen
		screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
		//give spawn timer its first random value between min and max gap
		spawnTimer = Random.Range(minimumSpawnGap, maximumSpawnGap);
		//Instantiate(Violin, new Vector3(Player.transform.position.x + randMoveAmount, 100, Player.transform.position.z), Player.transform.rotation);

		//these for loops create the object pools
		for(int i = 0; i < maxNumberOfHarps; i++)
		{
			harpPool[i] = Instantiate(harp);
			harpPool[i].SetActive(false);
		}

		for (int i = 0; i < maxNumberOfViolins; i++)
		{
			violinPool[i] = Instantiate(violin);
			violinPool[i].SetActive(false);
		}

		for (int i = 0; i < maxNumberOfCellos; i++)
		{
			celloPool[i] = Instantiate(cello);
			celloPool[i].SetActive(false);
		}

		for (int i = 0; i < maxNumberOfDrums; i++)
		{
			drumPool[i] = Instantiate(drum);
			drumPool[i].SetActive(false);
		}

		for (int i = 0; i < maxNumberOfTubas; i++)
		{
			tubaPool[i] = Instantiate(tuba);
			tubaPool[i].SetActive(false);
		}

		for (int i = 0; i < maxNumberOfTrumpets; i++)
		{
			trumpetPool[i] = Instantiate(trumpet);
			trumpetPool[i].SetActive(false);
		}

		for (int i = 0; i < maxNumberOfClarinets; i++)
		{
			clarinetPool[i] = Instantiate(clarinet);
			clarinetPool[i].SetActive(false);
		}

		for (int i = 0; i < maxNumberOfSaxs; i++)
		{
			saxPool[i] = Instantiate(sax);
			saxPool[i].SetActive(false);
		}

	}
	
	// Update is called once per frame
	void Update () {

		//incremant how long since last spawn
		timeSinceLastSpawn += Time.deltaTime;

		//if the time since last spawn is greater than spawn timer, spawn a trap, reset the timer and set a new spawn time
		if (timeSinceLastSpawn >= spawnTimer && trapCount < maxNumberOfTraps)
		{
			
			SpawnRandomTrap(m_spawnTrapsBool);
			timeSinceLastSpawn = 0;
			spawnTimer = Random.Range(minimumSpawnGap, maximumSpawnGap);
		}

	
	}

	//spawns traps based on a bool array
	//bool array is defined by sound
	void SpawnRandomTrap( bool[] spawnTrapsBool)
	{

		if (spawnTrapsBool[0])
		{
			randMoveAmount = Random.Range(-randMoveAmount, randMoveAmount);
			for (int i = 0; i < maxNumberOfHarps; i++)
			{
				if (!harpPool[i].activeSelf)
				{
					harpPool[i].SetActive(true);
					harpPool[i].transform.position = new Vector3(Player.transform.position.x + randMoveAmount, screenHeight + (harpPool[i].GetComponent<Collider>().bounds.size.y / 2), Player.transform.position.z);
					trapCount++;
					Debug.Log("this is called");
					break;
				}

			}
		}

		if (spawnTrapsBool[1])
		{
			randMoveAmount = Random.Range(-randMoveAmount, randMoveAmount);
			for (int i = 0; i < maxNumberOfHarps; i++)
			{
				if (!harpPool[i].activeSelf)
				{
					harpPool[i].SetActive(true);
					harpPool[i].transform.position = new Vector3(Player.transform.position.x + randMoveAmount, screenHeight + (harpPool[i].GetComponent<Collider>().bounds.size.y / 2), Player.transform.position.z);
					trapCount++;
					Debug.Log("this is called");
					break;
				}

			}
		}

		if (spawnTrapsBool[2])
		{
			randMoveAmount = Random.Range(-randMoveAmount, randMoveAmount);
			for (int i = 0; i < maxNumberOfCellos; i++)
			{
				if (!celloPool[i].activeSelf)
				{
					celloPool[i].SetActive(true);
					celloPool[i].transform.position = new Vector3(Player.transform.position.x + randMoveAmount, screenHeight + (celloPool[i].GetComponent<Collider>().bounds.size.y / 2), Player.transform.position.z);
					trapCount++;
					Debug.Log("this is called");
					break;
				}

			}
		}

		if (spawnTrapsBool[3])
		{
			randMoveAmount = Random.Range(-randMoveAmount, randMoveAmount);
			for (int i = 0; i < maxNumberOfDrums; i++)
			{
				if (!drumPool[i].activeSelf)
				{
					drumPool[i].SetActive(true);
					drumPool[i].transform.position = new Vector3(Player.transform.position.x + randMoveAmount, screenHeight + (drumPool[i].GetComponent<Collider>().bounds.size.y / 2), Player.transform.position.z);
					trapCount++;
					Debug.Log("this is called");
					break;
				}

			}
		}

		if (spawnTrapsBool[4])
		{
			randMoveAmount = Random.Range(-randMoveAmount, randMoveAmount);
			for (int i = 0; i < maxNumberOfTubas; i++)
			{
				if (!tubaPool[i].activeSelf)
				{
					tubaPool[i].SetActive(true);
					tubaPool[i].transform.position = new Vector3(Player.transform.position.x + randMoveAmount, screenHeight + (tubaPool[i].GetComponent<Collider>().bounds.size.y / 2), Player.transform.position.z);
					trapCount++;
					Debug.Log("this is called");
					break;
				}

			}
		}

		if (spawnTrapsBool[5])
		{
			randMoveAmount = Random.Range(-randMoveAmount, randMoveAmount);
			for (int i = 0; i < maxNumberOfTrumpets; i++)
			{
				if (!trumpetPool[i].activeSelf)
				{
					trumpetPool[i].SetActive(true);
					trumpetPool[i].transform.position = new Vector3(Player.transform.position.x + randMoveAmount, screenHeight + (trumpetPool[i].GetComponent<Collider>().bounds.size.y / 2), Player.transform.position.z);
					trapCount ++;
					Debug.Log("this is called");
					break;
				}

			}
		}

		if (spawnTrapsBool[6])
		{
			randMoveAmount = Random.Range(-randMoveAmount, randMoveAmount);
			for (int i = 0; i < maxNumberOfClarinets; i++)
			{
				if (!clarinetPool[i].activeSelf)
				{
					clarinetPool[i].SetActive(true);
					clarinetPool[i].transform.position = new Vector3(Player.transform.position.x + randMoveAmount, screenHeight + (clarinetPool[i].GetComponent<Collider>().bounds.size.y / 2), Player.transform.position.z);
					trapCount++;
					Debug.Log("this is called");
					break;
				}

			}
		}

		if (spawnTrapsBool[7])
		{
			randMoveAmount = Random.Range(-randMoveAmount, randMoveAmount);
			for (int i = 0; i < maxNumberOfSaxs; i++)
			{
				//Debug.Log("this is called");
				if (saxPool[i].activeSelf == false)
				{
					saxPool[i].SetActive(true);
					saxPool[i].transform.position = new Vector3(Player.transform.position.x + randMoveAmount, screenHeight + (saxPool[i].GetComponent<Collider>().bounds.size.y / 2), Player.transform.position.z);
					trapCount++;
					Debug.Log("this is called");
					break;
				}

			}
		}
	}


	public void ReduceActiveAmount()
	{
		--trapCount;
	}
}

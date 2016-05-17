using UnityEngine;
using System.Collections;

public class TrapsFallStraight : MonoBehaviour {

	[Range(1,10)]
	public float maxSpeed;

	[Range(0,1)]
	public float baseSpeed;

	[Range(3, 8)]
	public float speedIncrementRate;

	[Range(0, 3)]
	public float speedIncrementSize;

	int incremeantMultiplier;
	float timeSinceLastSpeedIncrease;
	float speed;
	float minY;
	TrapSpawner trapSpawner;
	// Use this for initialization
	void Start () {
		speed = baseSpeed;
		incremeantMultiplier = (int)(Time.time / speedIncrementRate);
		speed += speedIncrementSize * incremeantMultiplier;
		if (speed >= maxSpeed)
		{
			speed = maxSpeed;
		}

		minY = Camera.main.ScreenToWorldPoint( new Vector3(0, 0, 0)).y - (transform.lossyScale.y / 2);
		trapSpawner = FindObjectOfType<TrapSpawner>();
	}

	
	// Update is called once per frame
	void Update () {
		timeSinceLastSpeedIncrease += Time.deltaTime;

		Vector3 updatePos = transform.position;
		updatePos.y -= speed;
		transform.position = updatePos;

		if (transform.position.y <= minY)
		{
			trapSpawner.ReduceActiveAmount();
			enabled = false;
		}
	}
}

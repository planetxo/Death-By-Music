﻿using UnityEngine;
using System.Collections;

public class TrapsFallStraight : MonoBehaviour {

	[Range(0,10)]
	public float maxSpeed;

	[Range(0,10)]
	public float baseSpeed;

	[Range(3, 8)]
	public float speedIncrementRate;

	[Range(0, 10)]
	public float speedIncrementSize;

	int incremeantMultiplier;
	float speed;
	public float minY;
	TrapSpawner trapSpawner;
	// Use this for initialization
	void Start () {
		speed = baseSpeed;
		incremeantMultiplier = (int)(Time.timeSinceLevelLoad / speedIncrementRate);
		speed += speedIncrementSize * incremeantMultiplier;
		if (speed >= maxSpeed)
		{
			speed = maxSpeed;
		}

		int rand = Random.Range(0, 359);
		transform.Rotate(new Vector3(0, 0, 1), (float)rand);

		minY = Camera.main.ScreenToWorldPoint( new Vector3(0, 0, 0)).y - (transform.lossyScale.y / 2);
		trapSpawner = FindObjectOfType<TrapSpawner>();
	}

	
	// Update is called once per frame
	void Update () {

		Vector3 updatePos = transform.position;
		updatePos.y -= speed * Time.timeScale;
		transform.position = updatePos;

		if (transform.position.y <= minY)
		{
			trapSpawner.ReduceActiveAmount();
			gameObject.SetActive(false);
		}
	}
}

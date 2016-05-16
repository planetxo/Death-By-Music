using UnityEngine;
using System.Collections;

public class TrapsFallSinWave : MonoBehaviour {

	[Range(0, 1)]
	public float maxFallSpeed;

	[Range(0, 5)]
	public float maxXVariation;

	[Range(0, 20)]
	public float xVariationSpeed;

	[Range(3, 8)]
	public float speedIncrementRate;

	[Range(0, 3)]
	public float speedIncrementSize;

	[Range(0, 1)]
	public float baseSpeed;

	int incremeantMultiplier;
	float speed;
	// Use this for initialization
	void Start () {
		speed = baseSpeed;
		incremeantMultiplier = (int)(Time.time / speedIncrementRate);
		speed += speedIncrementSize * incremeantMultiplier;
		if (speed >= maxFallSpeed)
		{
			speed = maxFallSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		

		Vector3 updatePos = transform.position;

		updatePos.x = maxXVariation * Mathf.Sin(xVariationSpeed*Time.time);
		updatePos.y -= maxFallSpeed;
		transform.position = updatePos;


			

	}
}

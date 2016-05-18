using UnityEngine;
using System.Collections;

public class TrapsFallSinWave : MonoBehaviour {

	[Range(0, 10)]
	public float maxFallSpeed;

	[Range(0, 10)]
	public float maxXVariation;

	[Range(0, 20)]
	public float xVariationSpeed;

	[Range(3, 8)]
	public float speedIncrementRate;

	[Range(0, 3)]
	public float speedIncrementSize;

	[Range(0,10)]
	public float baseSpeed;

	int incremeantMultiplier;
	float speed;
	float minY;
	float xPosOrg;
	TrapSpawner trapSpawner;
	// Use this for initialization
	void Start () {

		xPosOrg = transform.position.x;
		speed = baseSpeed;
		incremeantMultiplier = (int)(Time.timeSinceLevelLoad / speedIncrementRate);
		speed += speedIncrementSize * incremeantMultiplier;
		if (speed >= maxFallSpeed)
		{
			speed = maxFallSpeed;
		}

		int rand = Random.Range(0, 359);
		transform.Rotate(new Vector3(0, 0, 1), (float)rand);

		minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - (transform.lossyScale.y / 2);
		trapSpawner = FindObjectOfType<TrapSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		

		Vector3 updatePos = transform.position;

		updatePos.x = (maxXVariation * Mathf.Sin(xVariationSpeed*Time.time)) + xPosOrg;
		updatePos.y -= speed * Time.timeScale;
		transform.position = updatePos;
		
		if(transform.position.y <= minY)
		{
			trapSpawner.ReduceActiveAmount();
			gameObject.SetActive(false);
		}

			

	}
}

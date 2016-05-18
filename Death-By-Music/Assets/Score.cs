using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text score;
	int scores = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scores = (int)Time.timeSinceLevelLoad;
		score.text = scores.ToString();
	}
}

using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	public GameObject pause;
	public AudioSource audio;

	public void PlayGame()
	{
		Time.timeScale = 1;
		pause.SetActive(true);
		audio.Play();
		gameObject.SetActive(false);
	}
}

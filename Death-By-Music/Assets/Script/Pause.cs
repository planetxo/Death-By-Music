using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject play;
	public AudioSource audio;

	public void PauseGame()
	{
		Time.timeScale = 0;
		play.SetActive(true);
		audio.Pause();
		gameObject.SetActive(false);
	}
}

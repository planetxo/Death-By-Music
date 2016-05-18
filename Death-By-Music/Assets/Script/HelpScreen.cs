using UnityEngine;
using System.Collections;

public class HelpScreen : MonoBehaviour
{

	public AudioSource audio;

	public void CloseScreen()
	{
		Time.timeScale = 1;
		audio.Play();
		gameObject.SetActive(false);
	}
}

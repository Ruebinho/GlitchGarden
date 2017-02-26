using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	
	public float levelGameTimeSeconds = 100;
	
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;
	
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		winLabel = GameObject.Find("Gewonnen");
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad/levelGameTimeSeconds;
		
		if (Time.timeSinceLevelLoad >= levelGameTimeSeconds && !isEndOfLevel) {
			isEndOfLevel = true;
			audioSource.Play();
			winLabel.SetActive(true);
			Invoke ("LoadNextLevel", audioSource.clip.length);
		}
	}
	
	void LoadNextLevel() {
		levelManager.LoadNextLevel();
	}
}

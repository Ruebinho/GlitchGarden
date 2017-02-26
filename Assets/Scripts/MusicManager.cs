using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log("Don't destroy on load: " + gameObject);
	}
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("Playing Clip:" + thisLevelMusic);
		
		if (thisLevelMusic) { // if there's music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			ChangeVolume(PlayerPrefsManager.getMasterVolume());
			audioSource.Play();
		}
	}
	
	public void ChangeVolume(float slidervalue) {
		audioSource.volume = slidervalue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

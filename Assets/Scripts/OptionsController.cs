using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {
	
	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		Debug.Log(musicManager);
		Debug.Log("get sound: " + PlayerPrefsManager.getMasterVolume());
		volumeSlider.value = PlayerPrefsManager.getMasterVolume();
		difficultySlider.value = PlayerPrefsManager.getDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume(volumeSlider.value);
	}
	
	public void SaveAndExit() {
		PlayerPrefsManager.setMasterVolume(volumeSlider.value);
		Debug.Log("Save Sound: " + PlayerPrefsManager.getMasterVolume());
		PlayerPrefsManager.setDifficulty(difficultySlider.value);
		
		levelManager.LoadLevel("01a Start_Menu");
	}
	
	public void SetDefaults() {
		volumeSlider.value = 1f;
		difficultySlider.value = 2f;
	}
}

using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";	
	
	public static void setMasterVolume(float volume) {
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Volume Wrong!");
		}
	}
	
	public static float getMasterVolume() {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void setLevelUnlocks (int level) {
		if (level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Levelname und dann 1 für true
		} else {
			Debug.LogError("Trying to unlock level not in game!");
		}
	}
	
	public static bool getLevelUnlocks(int level) {
		int levelNumber = PlayerPrefs.GetInt(LEVEL_KEY+level.ToString());
		bool levelUnlocked = (levelNumber == 1);
		
		if (level <= Application.levelCount - 1) {
		return levelUnlocked;
		} else {
		Debug.LogError("Level not unlocked");
		return false;
		}
	}
	
	public static void setDifficulty(float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("DIFFICULTY Wrong!");
		}
	}
	
	public static float getDifficulty() {
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
	
	
}

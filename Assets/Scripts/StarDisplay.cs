using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {
	
	public enum Status {SUCCESS, FAILURE}
	
	private Text starsText;
	private int stars = 100;
	
	// Use this for initialization
	void Start () {
		starsText = GetComponent<Text>();
		UpdateStarsDisplay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddStars(int amount) {
		stars += amount;
		UpdateStarsDisplay();
	}
	
	public Status UseStars(int amount) {
		if (stars >= amount) {
		stars -= amount;
		UpdateStarsDisplay();
		return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateStarsDisplay() {
		starsText.text =stars.ToString();
	}
}

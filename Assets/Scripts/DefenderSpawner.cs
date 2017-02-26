using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject parent;
	private StarDisplay starDisplay;
	
	void Start() {
			parent = GameObject.Find("Defenders");
			starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		if (!parent) {
			parent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown() {
		Vector2 rawPosition = CalculateWorldPointOfMouseClick();
		Vector2 gridPosition = SnapToGrid(rawPosition);
		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defender>().starCost;
		
		if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (gridPosition, defender);
		} else {
			Debug.Log("Insufficient stars to spawn defender!");
		}
		
	}
	
	void SpawnDefender(Vector2 gridPosition, GameObject defender) {
		Quaternion zeroRota = Quaternion.identity;
		GameObject newDef = Instantiate(defender, gridPosition, zeroRota) as GameObject;
			
		newDef.transform.parent = parent.transform;
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPosition) {
		int gridXPosition = Mathf.RoundToInt(rawWorldPosition.x);
		int gridYPosition = Mathf.RoundToInt(rawWorldPosition.y);
		
		Vector2 gridWorldPosition = new Vector2(gridXPosition, gridYPosition);
		
		return gridWorldPosition;
	}
	
	Vector2 CalculateWorldPointOfMouseClick() {
		
		float mouseXPos = Input.mousePosition.x;
		float mouseYPos = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3(mouseXPos, mouseYPos, distanceFromCamera);
		Vector2 mouseWorldCoordinates = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return mouseWorldCoordinates;
	}
}

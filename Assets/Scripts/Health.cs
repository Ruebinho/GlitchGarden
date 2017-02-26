using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setHealth(float attackDamage) {
		
		health -= attackDamage;
		
		if (health <= 0) {
			// Optionally trigger die animation
			DestroyObject();
		}
		
	}
	
	public void DestroyObject() {
		Destroy(gameObject);
	}
}

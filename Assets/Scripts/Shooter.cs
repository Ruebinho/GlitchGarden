﻿using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	void Start() {
		animator = GameObject.FindObjectOfType<Animator>();
	
		if (GameObject.Find("Projectiles")) {
			projectileParent = GameObject.Find("Projectiles");
		}	else {
			projectileParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
	}
	
	void Update() {
		if (IsAttackerAheadInLane()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}
	
	// Look at all spawners and find corresponding spawner in lane and store it in variable
	void SetMyLaneSpawner() {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		
		Debug.LogError(name + " can't find Spawner in lane");
	}
	
	bool IsAttackerAheadInLane() {
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		} 
		
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
			
		}
		
		return false;
	}
	
	private void Fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}

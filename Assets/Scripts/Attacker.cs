using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
	
	[Tooltip("Average number of seconds between appearances.")]
	public float seenEverySeconds;
	
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
	
		if (!GetComponent<Rigidbody2D>()) {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
		}
		
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		
		if (!currentTarget && anim) {
			anim.SetBool("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D() {

	}
	
	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}
	
	// Called from the animator at exact frame of attack
	public void StrikeCurrentTarget (float damage) {
		Debug.Log(name + " caused damage: " + damage);
		
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.setHealth(damage);
			}
		}
		
	}
	
	// Called by collison
	public void Attack (GameObject objCollider) {
		currentTarget = objCollider;
	}
}

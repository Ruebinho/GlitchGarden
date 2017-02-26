using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		GameObject objCollider = collider.gameObject;
		
		// Leave method if not defender
		if (!objCollider.GetComponent<Defender>()) {
			return;
		}
		
		if (objCollider.GetComponent<Gravestone>()) {
			anim.SetTrigger("jump trigger");
		} else {
			anim.SetBool("isAttacking", true);
			attacker.Attack(objCollider);
		}
		
		Debug.Log("Fox collided with " + collider);
	}
}

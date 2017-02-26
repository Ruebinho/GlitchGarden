using UnityEngine;
using System.Collections;

public class Gravestone : MonoBehaviour {

	private Animator anim;
	
	void Start() {
		anim = GetComponent<Animator>();
	}
	
	void Update() {
		
	}
	
	void OnTriggerStay2D(Collider2D collider) {
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
	
		if (attacker) {
			anim.SetTrigger("underAttack Trigger");
		}
	}
}

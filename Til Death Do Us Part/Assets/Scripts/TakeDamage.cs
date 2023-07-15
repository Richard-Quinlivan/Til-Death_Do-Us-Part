using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

	[SerializeField]
	private Renderer rend = null;
	[SerializeField]
	private Animator anim = null;


	[SerializeField]
	private int health;

	private void Start() {
		health = 100;
	}

	public void Damage(int amount) {
		//anim.SetBool("Hurt", true);
		anim.Play("Hurt");
		health -= amount;
		if (health <= 0) {
			Kill();
		}
		rend.enabled = true; // just here to get rid of a warning, can remove later.
	}
	private void Kill() {
		anim.SetBool("Death", true);
		this.gameObject.GetComponent<PlayerController>().enabled = false;
	}
}

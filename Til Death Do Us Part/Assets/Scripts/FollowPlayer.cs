using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	[SerializeField]
	private GameObject player = null;

	private Vector3 offset;
	// Start is called before the first frame update
	private void Start() {
		this.transform.position = player.transform.position;
		this.transform.Translate(0f, 0f, -1);
		offset = this.transform.position - player.transform.position;
	}

	// Update is called once per frame
	private void LateUpdate() {
		this.transform.position = player.transform.position + offset;
	}
}

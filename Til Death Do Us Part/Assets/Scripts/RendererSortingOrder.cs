using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererSortingOrder : MonoBehaviour {

	[SerializeField]
	private int sortingOrderBase = 5000;
	[SerializeField]
	private float offset = 0f;
	[SerializeField]
	private bool RunOnce = false;
	private Renderer rend;

	private float timer;
	private float SetTime = .1f;



	// Start is called before the first frame update
	void Awake() {
		rend = gameObject.GetComponent<Renderer>();
	}

	// Update is called once per frame
	void LateUpdate() {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = SetTime; 
			rend.sortingOrder = (int)(sortingOrderBase - 10 * (transform.position.y - offset));
			if (RunOnce) {
				Destroy(this);
			}
		}
	   
	}
}

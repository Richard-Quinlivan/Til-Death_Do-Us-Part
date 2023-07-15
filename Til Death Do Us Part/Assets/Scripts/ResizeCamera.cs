using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeCamera : MonoBehaviour {
	private void Awake() {
		float pixelsPerUnit = 50f;
		Camera.main.orthographicSize = Screen.height / 2f / pixelsPerUnit;
	}
}

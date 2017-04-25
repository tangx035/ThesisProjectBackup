using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnimation : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3(0, 45, 0) * Time.deltaTime*3);
	//	transform.Rotate (0f,2f,0f);
		transform.position += transform.up * Mathf.Sin (Time.time * 2f) * 0.015f;
		
	}
}

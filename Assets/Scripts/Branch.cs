using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour {

	public int level;

	void Start () {
		MeshRenderer renderer = GetComponent<MeshRenderer>();
		renderer.material.color = new Color (1, 1, 1, 1);
		StartCoroutine ("Fade");
	}

	private IEnumerator Fade() {
		MeshRenderer renderer = GetComponent<MeshRenderer>();
		renderer.material.color = new Color (1, 1, 1, 0);
		float alpha = 0;
		while (alpha < 1) {
			alpha += 0.01f;
			renderer.material	.color = new Color (1, 1, 1, alpha);
			yield return null;
		}
	}
}

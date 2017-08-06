using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationScript : MonoBehaviour {

	private MeshRenderer mesh;
	private float alpha = 0;

	private void Start() {
		mesh = GetComponent<MeshRenderer>();
		mesh.material.color = new Color (1, 1, 1, 0);
	}

	private void Update() {
		Debug.Log (MapCamera.index);
		if (MapCamera.index == 0) {
			alpha = alpha < 1 ? alpha += 0.03f : 1;
			mesh.material.color = new Color (1, 1, 1, alpha);
		} else {
			alpha = alpha > 0 ? alpha -= 0.03f : 0;
			mesh.material.color = new Color (1, 1, 1, alpha);
		}
	}
}

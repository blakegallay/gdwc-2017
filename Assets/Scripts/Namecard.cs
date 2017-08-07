using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Namecard : MonoBehaviour {

	void Update () {
		transform.eulerAngles = new Vector3 (0, Camera.angle, 0);
	}
}

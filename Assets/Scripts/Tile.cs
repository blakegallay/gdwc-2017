using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	protected int x;
	protected int z;

	private void Start () {
		x = (int)transform.position.x;
		z = (int)transform.position.z;
		Stage.Enable (x, z);
	}
}

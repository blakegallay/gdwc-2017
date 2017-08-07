using UnityEngine;
using System;
using System.Collections;

public class Player : MonoBehaviour {

	public int energy = 10;
	public int keys;
	public int stars = 0;
	public bool interactable = false;
	public bool sounded = false;
	public GameObject particle;
	private bool dead = false;
	public GameObject portalParticle;
	public GameObject hurt;
	public GameObject teleport;
	public GameObject lvl;
	public GameObject doorParticle;
	private bool teleporting = true;
	public GameObject collect;
	public bool loading = false;
	public GameObject bonus;

	public bool flagged = false;
	private bool touchingEnd = false;

	private Tile portal;
	private bool touchingPortal = false;
	public float max;

	public static Player instance;

	private void Awake() {
		loading = false;
		instance = this;
		keys = 0;
		max = energy;
		touchingEnd = false;
	}

	private void Start() {
		sounded = false;
		keys = 0;
	}

	private void Update() {
		if (!flagged && energy > 0	) {
			Vector2 target = GetTarget (Camera.angle);
			InitiateMove ((int)target.x, (int)target.y);
		}
		if (Input.GetKeyDown (KeyCode.R) || (energy < 1 && !touchingEnd) || dead) {
			loading = true;
			if (stars > 0) {
				stars = 0;
			}
			if (!sounded) {
				Instantiate (hurt);
				sounded = true;
			}
		}
	}

	public Vector2 GetTarget(float angle) {
		int i = 0;
		int j = 0;
		angle = angle % 360;
		if (angle >= 0 || angle < 90) {
			i = (int)transform.position.x + (int)Input.GetAxis ("Horizontal");
			j = (int)transform.position.z + (int)Input.GetAxis ("Vertical");
		}
		if (angle >= 90 && angle < 180) {
			i = (int)transform.position.x + (int)Input.GetAxis ("Vertical");
			j = (int)transform.position.z - (int)Input.GetAxis ("Horizontal");
		}
		if (angle >= 180 && angle < 270) {
			i = (int)transform.position.x - (int)Input.GetAxis ("Horizontal");
			j = (int)transform.position.z -	 (int)Input.GetAxis ("Vertical");
		}
		if (angle >= 270 && angle < 360) {
			i = (int)transform.position.x - (int)Input.GetAxis ("Vertical");
			j = (int)transform.position.z + (int)Input.GetAxis ("Horizontal");
		}
		return new Vector2 ((int)i, (int)j);
	}

	public void SetPosition (Vector3 position) {
		transform.position = position;
	}

	private void InitiateMove (int i, int j) {
		int x = (int)transform.position.x;
		int z = (int)transform.position.z;
		Vector3 position = transform.position;
		Vector3 snap = new Vector3 (x, 1, z);
		bool snapped = (position == snap);
		bool diagonal  = (i - x) != 0 && (j - z) != 0;
		bool different = (x != i) || (z != j);
		bool valid = Stage.Check (i, j);
		if (snapped && !diagonal && different && valid && !loading) {
			StartCoroutine (Move (i, j));
		}
	}

	private IEnumerator Move (int i, int j) {
		flagged = true;
		Vector3 target = new Vector3 (i, 1, j);
		Vector3 position = transform.position;
		Vector3 velocity = Vector3.zero;
	     while (position != target) {
			position = transform.position;
			transform.position = Vector3.SmoothDamp (position, target, ref velocity, 0.03f);
	        yield return null;
		}
		if (!Stage.Check(i + 1, j) && !Stage.Check(i - 1, j) && !Stage.Check(i, j - 1) && !Stage.Check(i, j + 1)) {
			dead = true;
		}
		if (energy > 0) {
			energy--;
		}
		transform.position = target;
		flagged = false;
	}

	private void OnTriggerEnter (Collider collider) {
		if (collider.tag == "Stage Tile") {
			loading = true;
			Instantiate (lvl);

			touchingEnd = true;
		}
		if (collider.tag == "Level Tile") {
			Instantiate (lvl);
			loading = true;
			touchingEnd = true;
		}
		if (collider.tag == "Drain Tile") {
			energy -= 2;
		}
		if (collider.tag == "Portal Tile") {
			GameObject portalObject = collider.gameObject;
			portal = portalObject.GetComponent<Tile>();
			teleporting = teleporting ? false : true;
			touchingPortal = true;
		}
		if (collider.tag == "Small Battery") {
			energy += 4;
			Instantiate (collect);
			Destroy (collider.gameObject);
		}
		if (collider.tag == "Large Battery") {
			energy += 10;
			Instantiate (collect);
			Destroy (collider.gameObject);
		}
		if (collider.tag == "Key") {
			keys++;
			Instantiate (collect);
			Debug.Log (keys);
			Destroy (collider.gameObject);
		}
		if (collider.tag == "Star") {
			stars++;
			Instantiate (bonus);

			Destroy (collider.gameObject);
			Instantiate (particle, collider.transform.position, Quaternion.identity);
		}
		if (collider.tag == "Enemy") {
			Instantiate (hurt);
			loading = true;
			if (stars > 0) {
				stars = 0;
			}
		}
		if (collider.tag == "Fire Tile") {

		}
		if (collider.tag == "Door Tile") {
			if (keys > 0) {
				Instantiate (hurt);
				Instantiate (doorParticle, collider.transform.position, Quaternion.identity);
				int a = (int)collider.transform.position.x;
				int b = (int)collider.transform.position.z;
				Stage.Enable (a, b);
				Destroy (collider.gameObject);
				keys--;
				Debug.Log (keys);
			}

		}
	}
}

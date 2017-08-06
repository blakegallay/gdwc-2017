using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	public static int stars11;
	public static int stars21;
	public static int stars31;
	public static int stars41;
	public static int stars51;
	public static int total;

	public static int tempStars;

	public static Game instance;
	public static int index = -1;

	void Awake() {
		DontDestroyOnLoad (gameObject);
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
		}
	}

	private void Update() {
		total = stars11 + stars21 + stars31 + stars41  + stars51;
		Debug.Log (total);
	}

	public static void SetStar(int stars) {
		switch (index) {
			case 0:
				stars11 = stars11 > stars ? stars11 : stars;
				break;
			case 1:
				stars21 = stars21 > stars ? stars21 : stars;
				break;
			case 2:
				stars31 = stars31 > stars ? stars31 : stars;
				break;
			case 3:
					stars41 = stars41 > stars ? stars41 : stars;
					break;
			case 4:
					stars51 = stars51 > stars ? stars51 : stars;
					break;
		}
	}

	public static int GetStars(int a) {
		switch (a) {
			case 0:
				return stars11;
			case 1:
				return stars21;
			case 2:
				return stars31;
			case 3:
				return stars41;
			case 4:
				return stars51;
			default:
				return 0;
		}
	}
}

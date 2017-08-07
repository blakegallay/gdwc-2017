using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	void Awake () {
		if (instance != null) {
			
		}
		DontDestroyOnLoad (gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}

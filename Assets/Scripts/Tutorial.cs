using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public Text text;
	public static int phase = 0;

	void Start() {
		phase = 0;
	}

	void Update () {
		float alpha = text.color.a;
		if (phase == 0) {
			text.text = "Use A & D to rotate camera";
			if (alpha < 1) {
				alpha += 0.75f * Time.deltaTime;
				text.color = new Color (1, 1, 1, alpha);
			}
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
				phase++;
			}
		}
		if (phase == 1) {
			if (alpha > 0) {
				alpha -= 0.75f * Time.deltaTime;
				text.color = new Color (1.0f, 1.0f, 1.0f, alpha);
			}
			if (alpha <= 0) {
				phase++;
			}
		}
		if (phase == 2) {
			text.text = "Use arrow keys to move";
			if (alpha < 1) {
				alpha += 0.75f * Time.deltaTime;
				text.color = new Color (1, 1, 1, alpha);
			}
			if (FakePlayer.instance.flagged) {
				phase++;
			}
		}
		if (phase == 3) {
			if (alpha > 0) {
				alpha -= 0.75f * Time.deltaTime;
				text.color = new Color (1.0f, 1.0f, 1.0f, alpha);
			}
			if (alpha <= 0) {
				phase++;
			}
		}
		if (phase == 4) {
			text.text = "Reach the goal to start game";
			if (alpha < 1) {
				alpha += 0.75f * Time.deltaTime;
				text.color = new Color (1, 1, 1, alpha);
			}
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour {

	public static int width = 8;
	public static int length = 8;
	public static int[,] matrix = new int[width, length];

	public static bool Check (int i, int j) {
		return matrix[i, j] != 0;
	}

	public static void Disable (int i, int j) {
		matrix[i, j] = 0;
	}

	public static void Enable (int i, int j) {
		matrix[i, j] = 1;
	}
}

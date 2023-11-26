using UnityEngine;
using UnityEngine.SceneManagement;

public class JumperReset : MonoBehaviour {
	public void reset() {
		SceneManager.LoadScene("Jumper");
	}
}
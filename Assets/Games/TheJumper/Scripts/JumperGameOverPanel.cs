using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperGameOverPanel : MonoBehaviour {
	public JumperDestoryAtBottom dab;
	public GameObject panel;

	IEnumerator wait() {
		yield return new WaitForSeconds(2f);
		panel.SetActive(true);
	}

	void Update() {
		if(dab.GameOver) {
			StartCoroutine(wait());
		}
	}
}
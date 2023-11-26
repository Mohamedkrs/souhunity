using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperCameraFollow : MonoBehaviour {
	public GameObject player;
	JumperPlayerController control;

	void Start() {
		control = player.GetComponent<JumperPlayerController>();
	}
	void Update() {
		if(control.ySpeed > 0 && transform.position.y < control.yCoor) {
			transform.Translate(0,control.ySpeed * Time.deltaTime,0);
		}
	}
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperLoadedSceneAnimation : MonoBehaviour {
	Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
		animator.Play("DarktoScene");
	}
}

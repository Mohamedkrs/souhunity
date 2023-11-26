using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour
{
	private Vector2 startTouchPosition;
	private float swipeThreshold = 50f;

	private float speed = TheJumpSettings.speed;
	public float offsetMove = -32;

	public Transform[] cylinders;

	private ScoreTrigger[] scores;
	private Gyroscope gyro;
	private bool gyroEnabled;

	private void Awake()
	{
		scores = GetComponentsInChildren<ScoreTrigger>();
	}

	// Use this for initialization
	void Start()
	{
		print(speed);
		RandomRotation();
		gyroEnabled = EnableGyro();

	}
	private bool EnableGyro()
	{
		if (SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;
			return true;
		}
		return false;
	}
	// Update is called once per frame
	void Update()
	{

		if (LevelController.instance.gameOver)
			return;

		Rotate();

	}

	void Rotate()
	{
		if (gyro != null && gyroEnabled)
		{
			Vector3 accelerometerData = Input.acceleration;
			float tiltAngle = Mathf.Atan2(accelerometerData.x, accelerometerData.z);
			float tiltAngleDegrees = tiltAngle * Mathf.Rad2Deg;
			if (tiltAngleDegrees > 0 && tiltAngleDegrees < 150)

			{
				print(150 - tiltAngleDegrees);
				transform.Rotate(new Vector3(0, 1, 0) * (150 - tiltAngleDegrees) * speed * Time.deltaTime);
			}
			else if (tiltAngleDegrees < 0 && tiltAngleDegrees > -150)
			{
				transform.Rotate(new Vector3(0, -1, 0) * (tiltAngleDegrees + 150) * speed * Time.deltaTime);

			}
		}
	}

	void RandomRotation()
	{
		for (int i = 0; i < cylinders.Length; i++)
		{
			cylinders[i].rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
		}
	}

	public void Reposition(float yPos)
	{
		transform.position = new Vector3(transform.position.x, transform.position.y + yPos, transform.position.z);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			for (int i = 0; i < scores.Length; i++)
			{
				scores[i].SetColliders(true);
			}
			Reposition(offsetMove);
			RandomRotation();
		}
	}
}

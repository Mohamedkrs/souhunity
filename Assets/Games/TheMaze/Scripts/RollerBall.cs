using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class RollerBall : MonoBehaviour
{
	public GameObject ViewCamera = null;
	public AudioClip JumpSound = null;
	public AudioClip HitSound = null;
	public AudioClip CoinSound = null;
	private Rigidbody mRigidBody = null;
	private AudioSource mAudioSource = null;
	private bool mFloorTouched = false;
	public int speed = 1;
	private bool gyroEnabled;
	private Gyroscope gyro;
	private bool isGameActive = true;
	public GameObject GameOverScreen;
	public GameObject GameOverScreenFail;
	public GameObject Timer;
	public GameObject Score;
	public GameObject Sound;
	private bool Vibrate = Settings.vibrate;


	// GameObject panel = GameObject.Find("Panel");

	// public void GameOver()
	// {
	// 	GameOverScreen.Setup(true);
	// }
	void Start()
	{
		mRigidBody = GetComponent<Rigidbody>();
		mAudioSource = GetComponent<AudioSource>();
		gyroEnabled = EnableGyro();
		GameOverScreen.SetActive(false);

		if (Settings.Instance != null)
		{
			ViewCamera.GetComponent<AudioSource>().volume = Settings.volume;
			// SetColor(Settings.volume);
		}
		// Sound.GetComponent<AudioSource>().GetComponent<Volume>().

		// panel.SetActive(true);
		// Countdown.OnCountdownEnd += () =>
		// {
		// 	isGameActive = false;
		// 	GameOver();
		// };
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

	void FixedUpdate()
	{
		if (isGameActive)
		{
			if (gyro != null && gyroEnabled)
			{
				Vector3 accelerometerData = Input.acceleration;
				float tiltAngle = Mathf.Atan2(accelerometerData.x, accelerometerData.z);
				float tiltAngleDegrees = tiltAngle * Mathf.Rad2Deg;

				if (tiltAngleDegrees > 0 && tiltAngleDegrees < 150)
				{
					mRigidBody.AddTorque(Vector3.back * 10);
					mRigidBody.AddForce(Vector3.right * speed);
				}
				else if (tiltAngleDegrees < 0 && tiltAngleDegrees > -150)
				{
					mRigidBody.AddTorque(Vector3.forward * 10);
					mRigidBody.AddForce(Vector3.left * speed);
				}
				else
				{
					mRigidBody.velocity *= 0.99f;
				}
			}
			if (Input.touchCount > 0)
			{
				if (Input.GetTouch(0).position.x > Screen.width / 1.2)
				{
					mRigidBody.AddTorque(Vector3.right * 10);
					mRigidBody.AddForce(Vector3.forward * speed);
				}
				else if (Input.GetTouch(0).position.x < Screen.width / 3.5)
				{
					mRigidBody.AddTorque(Vector3.left * 10);
					mRigidBody.AddForce(Vector3.back * speed);
				}
			}
			else
			{
				mRigidBody.velocity *= 0.99f;
			}
			if (ViewCamera != null)
			{
				Vector3 direction = (Vector3.up * 2 + Vector3.back) * 2;
				RaycastHit hit;
				Debug.DrawLine(transform.position, transform.position + direction, Color.red);
				if (Physics.Linecast(transform.position, transform.position + direction, out hit))
				{
					ViewCamera.transform.position = hit.point;
				}
				else
				{
					ViewCamera.transform.position = transform.position + direction;
				}
				ViewCamera.transform.LookAt(transform.position);
			}
		}
		else
		{
			mRigidBody.velocity *= 0.99f;
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag.Equals("Floor"))
		{
			mFloorTouched = true;
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.y > .5f)
			{
				mAudioSource.PlayOneShot(HitSound, coll.relativeVelocity.magnitude);
			}
		}
		else
		{
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.magnitude > 2f)
			{
				mAudioSource.PlayOneShot(HitSound, coll.relativeVelocity.magnitude);
				if (Vibrate)
				{
					Handheld.Vibrate();
				}
				if (TheMazeSettings.noCollision)
				{
					ViewCamera.GetComponent<AudioSource>().Stop();
					GameOverScreenFail.SetActive(true);
					Score.GetComponent<Text>().text = Timer.GetComponent<Text>().text;
				}
			}
		}
	}

	void OnCollisionExit(Collision coll)
	{
		if (coll.gameObject.tag.Equals("Floor"))
		{
			mFloorTouched = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Coin"))
		{
			if (mAudioSource != null && CoinSound != null)
			{
				mAudioSource.PlayOneShot(CoinSound);
				Debug.Log("Coin");
			}
			Destroy(other.gameObject);
			GameOverScreen.SetActive(true);
			Score.GetComponent<Text>().text = Timer.GetComponent<Text>().text;
		}
	}
}

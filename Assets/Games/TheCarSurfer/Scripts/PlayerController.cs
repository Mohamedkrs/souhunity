using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 direction;

    public float sideSpeed = 6;
    private float forwardSpeed = TheCarSurferSettings.speed;
    public float maxSpeed;
    public const float SpeedModifier = 0.2f;
    public float displayedSpeed = 0; 

    //0 - left
    //1 - middle
    //2 - right
    private int desiredLane = 1;
    public float laneDistance = 4; //distance beetwen two lanes

    public float jumpForce;
    public float gravity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        IncreaseSpeed();
        direction.z = forwardSpeed;
        direction.x = Input.acceleration.x* sideSpeed;
        PerformJump();

        if (transform.position.x >= -2.87f || transform.position.x <= 2.87f)
        {
            controller.enabled = false;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.86f, 2.86f), transform.position.y, transform.position.z);
            controller.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void PerformTurn()
    {
        TurnRight();
        TurnLeft();
    }

    private void TurnLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft )
        {
            FindObjectOfType<AudioManager>().PlaySound("Turn");

            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
    }

    private void TurnRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
        {
            FindObjectOfType<AudioManager>().PlaySound("Turn");

            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
    }



    private void PerformJump()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp)
                Jump();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.swipeDown)
                JumpDown();
        direction.y += gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        FindObjectOfType<AudioManager>().PlaySound("Jump");
        direction.y = jumpForce;
    }
    private void JumpDown()
    {
       
        direction.y -= jumpForce;
    }

    private void IncreaseSpeed()
    {
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += SpeedModifier * Time.deltaTime;
            displayedSpeed = forwardSpeed * 10;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            var am = FindObjectOfType<AudioManager>();
            am.PlaySound("Crash");
            StartCoroutine(AudioManager.FadeOut(am.GetComponent<AudioSource>(), 2, 0.0f));

            PlayerManager.gameOver = true;
        }
    }

    /*private void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Obstacle")
        {
            var am = FindObjectOfType<AudioManager>();
            am.PlaySound("Crash");
            StartCoroutine(AudioManager.FadeOut(am.GetComponent<AudioSource>(), 2, 0.0f));

            PlayerManager.gameOver = true;
        }
    }*/

    void OnTriggerStay(Collider other)
    {
        Vector3 newPosition = other.transform.localPosition;
        newPosition.z = Mathf.Lerp(other.transform.localPosition.z, transform.localPosition.z, Time.deltaTime * 1);

        other.transform.localPosition = newPosition;
    }
}

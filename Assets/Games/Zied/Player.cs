using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IPointerDownHandler,IPointerUpHandler 
{
    public GameObject character;
    public float moveSpeed = 1.0f;
    public float minXPosition = -146.0f;
    private bool hasBones = false;
    private bool hasItem = false;
    private bool leftButtonPressed = false;
    private bool rightButtonPressed = false;

    void Start()
    {
        Input.location.Start();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print(eventData.position.x);
       if (eventData.position.x > 200)
        {
            rightButtonPressed = true;
            Debug.Log("Right button pressed");
        }
        else
        {                
            leftButtonPressed = true;
            Debug.Log("Left button pressed");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        leftButtonPressed = false;
        rightButtonPressed = false;
    }


    void OnDestroy()
    {
        Input.location.Stop();
    }

    void Update()
    {
        if (!hasBones && character.transform.position.x >= -36.0f && character.transform.position.x <= -26.0f)
        {
            hasBones = GameObject.Find("Gravestone").GetComponent<Graveyard>().GotBones();
        }

        if (Input.location.isEnabledByUser && character.transform.position.x >= -27.0f && character.transform.position.x <= -24.0f)
        {
            Vector3 newPosition = character.transform.position;  
            newPosition.x = -108.0f;  
            character.transform.position = newPosition; 
        }
        else if (character.transform.position.x >= -0.5f && character.transform.position.x <= 3.5f && hasItem)
        {
                GameObject.Find("Well").GetComponent<Well>().CheckAcceleration();
        }

        if(rightButtonPressed)
        {
            MoveRight();
        }
        else if(leftButtonPressed)
        {
            MoveLeft();
        }

    }

    public void MoveLeft()
    {
        if (character.transform.position.x > -146.0f)
        {
            character.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    public void MoveRight()
    {
        if ((!(character.transform.position.x >= -123.0f && character.transform.position.x <= -122.7f) || (character.transform.position.x >= -123.0f && character.transform.position.x <= -122.7f && !GameObject.Find("Road Lamp").GetComponent<RoadLamp>().isItDark())) && character.transform.position.x <= 8.0f )
        {
            character.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (character.transform.position.x >= -94.0f && character.transform.position.x <= -90.0f)
        {
            GameObject.Find("Soldier").GetComponent<Soldier>().Quote(hasBones);
            if(hasBones)
            {
                hasItem = true;
            }
        }
        else{
            GameObject.Find("Soldier").GetComponent<Soldier>().RemoveQuote();
            if (character.transform.position.x >= -64.0f && character.transform.position.x <= -60.0f)
            {
                GameObject.Find("Merchant").GetComponent<Merchant>().Quote(hasItem);
            }
            else{
                GameObject.Find("Merchant").GetComponent<Merchant>().RemoveQuote();
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        // Check if the player is colliding with the object
        if (other.CompareTag("Road Lamp")) // Replace with the appropriate tag
        {
            // Call your script or perform an action when the player is close to the object
            // For example, you can call a method from the object's script:
            RoadLamp objectScript = other.GetComponent<RoadLamp>();
            if (objectScript != null)
            {
                objectScript.isItDark();
            }
        }
    }*/
}

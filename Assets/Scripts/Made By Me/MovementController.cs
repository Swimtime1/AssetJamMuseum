using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Float Variables
    public float playerSpeed;
    float yRot;
    float yChange;
    public float sensitivity;
    float xPosWorld, yPosWorld, zPosWorld;

    // Boolean Variables
    bool active;
    bool transition;

    // GameObject Variables
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        yRot = 0f;

        active = true;
        transition = false;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonMove();        

        // Turns on and off the camera follow
        if(Input.GetKeyDown(KeyCode.C)) { active = !active; }
        
        // Only calls RotateWithCamera() if the player has pressed C an odd number of times
        if(active) { RotateWithCamera(); }
    }

    // Moves the Player
    void ButtonMove()
    {
        // Move the gameobject up by pressing the key W
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        // Move the gameobject down by pressing the key S
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * -(playerSpeed * Time.deltaTime));
        }

        // Move the gameobject left by pressing the key A
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * -(playerSpeed * Time.deltaTime));
        }

        // Move the gameobject up by pressing the key D
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
    }

    // Rotates the player to match the camera
    void RotateWithCamera()
    {
        yChange = Input.GetAxis("Mouse X") * sensitivity;

        yRot += yChange;
        
        transform.localEulerAngles = new Vector3(0, yRot, 0);
    }

    // Called when the Player first touches a trigger
    void OnTriggerEnter(Collider other)
    {
        transition = !transition;
        
        xPosWorld = transform.position.x;
        yPosWorld = transform.position.y;
        zPosWorld = transform.position.z;

        // Moves the player if they just entered a doorway
        if(transition)
        {
            cam.SetActive(false);
            
            // Chooses which doorway to go to
            if(other.gameObject.CompareTag("ToArt"))
            { transform.Translate(0, 0, 230, Space.World); }
            else if(other.gameObject.CompareTag("ExitArt"))
            { transform.Translate(0, 0, -230, Space.World); }
            else if(other.gameObject.CompareTag("ToMusic") 
                    || other.gameObject.CompareTag("ExitProgramming"))
            { transform.Translate(-230, 0, 0, Space.World); }
            else if(other.gameObject.CompareTag("ExitMusic") 
                    || other.gameObject.CompareTag("ToProgramming"))
            { transform.Translate(230, 0, 0, Space.World); }

            cam.SetActive(true);
        }
    }
}

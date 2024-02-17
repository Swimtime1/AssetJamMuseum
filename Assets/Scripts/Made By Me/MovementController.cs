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

    // Start is called before the first frame update
    void Start()
    {
        yRot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonMove();
        RotateWithCamera();
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
}

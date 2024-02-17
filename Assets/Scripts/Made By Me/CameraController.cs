using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Float Variables
    float xRot;
    float xChange;
    public float sensitivity;

    // Boolean Variables
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        xRot = 0f;

        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Turns on and off the camera follow
        if(Input.GetKeyDown(KeyCode.C)) { active = !active; }
        
        // Only calls RotateCamera() if the player has pressed C an odd number of times
        if(active) { RotateCamera(); }
    }

    // Updates the rotation of the camera to follow the mouse
    void RotateCamera()
    {
        xChange = Input.GetAxis("Mouse Y") * -1 * sensitivity;
        
        xRot += xChange;

        // Provides boundaries for looking up and down
        if(xRot > 90f) { xRot = 90f; }
        else if(xRot < -45) { xRot = -45; }

        // Resets vertical camera
        if(Input.GetKeyDown(KeyCode.R)) { xRot = 0f; }
        
        transform.localEulerAngles = new Vector3(xRot, 0, 0);
    }
}

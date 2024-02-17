using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Float Variables
    float xRot;
    float xChange;
    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        xRot = 0f;
    }

    // Update is called once per frame
    void Update()
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

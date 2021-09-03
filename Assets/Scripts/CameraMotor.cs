using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    public Transform cameraFocus;
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        cameraFocus = GameManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // Checking the distance between cameraFocus and camera position on X or Y axis. If it's greater than the bound specified fot that Axis
        // moving the camera according to the direction the cameraFocus moved
        float deltaX = cameraFocus.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < cameraFocus.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                // + can be understood as -(-boundX)
                delta.x = deltaX + boundX;
            }
        }
        
        float deltaY = cameraFocus.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < cameraFocus.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }

}

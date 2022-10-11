using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform root;

    float mouseX, mouseY;


    public ConfigurableJoint hipJoint;
  //  public ConfigurableJoint stomachJoint;
  //  public float stomachOffset;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -120, 60);

        Quaternion rootRotation = Quaternion.Euler(mouseY, mouseX, 0);

        if (Input.GetKey(KeyCode.Z))
        {
            root.rotation = rootRotation;
        }
        else
        {
            root.rotation = rootRotation;
            hipJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);
            //stomachJoint.targetRotation = Quaternion.Euler(-mouseY + stomachOffset, 0, 0);
        }
    }
}


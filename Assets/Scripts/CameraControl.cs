using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform root;
    public Menu menu;

    float mouseX, mouseY;


    public ConfigurableJoint hipJoint;
  //  public ConfigurableJoint stomachJoint;
  //  public float stomachOffset;

    private void Start()
    {

    }
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            CamControl();
        }
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -60, 45    );

        Quaternion rootRotation = Quaternion.Euler(mouseY, mouseX, 0);

        
            root.rotation = rootRotation;
            hipJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);
            //stomachJoint.targetRotation = Quaternion.Euler(-mouseY + stomachOffset, 0, 0);
        
    }
}


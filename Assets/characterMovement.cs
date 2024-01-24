using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 50f;
    Vector2 mouseInput;

    bool canBackStab = true;

    public static characterMovement instance;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        instance = this;
    }

    void Update()
    {
        float direction = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction = -1;
        }
        Vector3 movement = transform.forward * speed * direction * Time.deltaTime;
        transform.position = transform.position + movement;

        float directionH = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            directionH = 1;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            directionH = -1;
        }
        Vector3 movementHorizontal = transform.right * speed * directionH * Time.deltaTime;
        transform.position = transform.position + movementHorizontal;

        

        mouseInput += new Vector2(Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, mouseInput.x, 0);

    }

    public bool GetCanBackStab()
    {
        return canBackStab;
    }

    public void SetCanBackStab(bool variable)
    {
        canBackStab = variable;
    }
}

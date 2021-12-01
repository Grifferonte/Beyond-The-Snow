using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController m_CharCtrl;
    public float runSpeed = 40f;

    float horizontalMove = 0f;

    float verticalMove = 0f;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        }
        else if(joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }

        if(joystick.Vertical >= .2f)
        {
            verticalMove = runSpeed;
        }
        else if(joystick.Vertical <= -.2f)
        {
            verticalMove = -runSpeed;
        }
        else
        {
            verticalMove = 0f;
        }
        Debug.Log(verticalMove * Time.time);
        Debug.Log(horizontalMove * Time.time);
        Vector3 move = transform.right * horizontalMove + transform.forward*verticalMove;
        m_CharCtrl.Move(move * runSpeed * Time.deltaTime);
    }
}

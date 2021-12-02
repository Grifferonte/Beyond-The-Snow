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
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
        Vector3 move = transform.right * horizontalMove + transform.forward*verticalMove;
        m_CharCtrl.Move(move * runSpeed * Time.deltaTime);
    }

    public void SpeedChange(int speed){
        runSpeed = speed;
        Debug.Log(speed);
    }
}

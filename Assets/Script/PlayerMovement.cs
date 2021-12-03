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

    // Gravity management
    Vector3 m_velocity;
    float m_gravity = -9.81f;

    // Check if we're one the ground
    [SerializeField] Transform m_groundCheck;
    [SerializeField] float m_groundDistance = 0.4f;
    [SerializeField] LayerMask m_groundMask;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        #region Gravity management
        isGrounded = Physics.CheckSphere(m_groundCheck.position, m_groundDistance, m_groundMask);

        if (isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = -2f;
        }
        m_velocity.y += m_gravity * Time.deltaTime;
        m_CharCtrl.Move(m_velocity * Time.deltaTime);

        #endregion




        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
        Vector3 move = transform.right * horizontalMove + transform.forward * verticalMove;
        m_CharCtrl.Move(move * runSpeed * Time.deltaTime);
    }

    public void SpeedChange(int speed)
    {
        runSpeed = speed;
    }
}

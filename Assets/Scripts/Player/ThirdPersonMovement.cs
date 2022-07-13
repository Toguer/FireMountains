using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam;

    [Range(1, 10)]
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float jumpBufferTime;
    public float jumpHeight = 0.5f;
    public float gravity = -9.81f;

    private float timeInAir;
    [Tooltip("Es el tiempo durante el cual el PJ puede saltar despues de caer de una plataforma")]
    [Range(0, 1)]
    [SerializeField] private float coyoteTime;

    Queue<KeyCode> inputBuffer;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public Animator animator;



    private void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        inputBuffer = new Queue<KeyCode>();
    }
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) //tocando el suelo
        {

            velocity.y = -2f;
            animator.SetBool("Jump", false);
            timeInAir = 0;
        }
        else if (!isGrounded)
        {
            timeInAir += Time.deltaTime;
              animator.SetBool("Jump", true);
        }
        #region checkBuffer&Jump
        if (isGrounded)
        {
            animator.SetBool("Jump", false);
            if (inputBuffer.Count > 0)
            {
                if (inputBuffer.Peek() == KeyCode.Space)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                    //animator.SetBool("Jump", true);
                    int salto = Random.Range(0, 2);
                    if (salto == 1) AudioManager.instance.Play("salto1");
                    else
                    {
                        AudioManager.instance.Play("salto2");
                    }
                    //Debería emitir el sonido que le asignemos, en este caso el de Jump
                    timeInAir = 1; //Para prevenir el doble salto
                    removeAction();
                }
            }
        }
        else
        {
            if (timeInAir < coyoteTime)
            {
                if (inputBuffer.Count > 0)
                {
                    if (inputBuffer.Peek() == KeyCode.Space)
                    {
                        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                        animator.SetBool("Jump", true);
                        timeInAir = 1; //Para prevenir el doble salto
                        removeAction();
                    }
                }

            }
        }
        #endregion

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            animator.SetFloat("run", 1);
        }
        else
        {
            animator.SetFloat("run", 0);
        }
        #region checkInputJump
        if (Input.GetButtonDown("Jump"))
        {
            inputBuffer.Enqueue(KeyCode.Space);
            Invoke("removeAction", jumpBufferTime);
            /*
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                animator.SetBool("Jump", true);
                timeInAir = 1; //Para prevenir el doble salto
            }
            else
            {
                if (timeInAir < coyoteTime)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                    animator.SetBool("Jump", true);
                    timeInAir = 1; //Para prevenir el doble salto
                }
            }
            */
        }
        #endregion
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void removeAction()
    {
        if (inputBuffer.Count > 0)
        {
            inputBuffer.Dequeue();
        }

    }
}

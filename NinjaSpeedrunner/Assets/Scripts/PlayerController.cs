using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float airSpeed;
    [SerializeField]
    private float jumpsSpeed;
    [SerializeField]
    private float jumpPadStrength;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float gracePeriod;

    
    public int life = 3;

    private float ySpeed;
    // ? means its nullable, so it can have null value
    private float? jumpPress; //For if you press right before landing
    private float? groundPress; //For if you press right after falling
    private float stepOffset;

    private bool isJumping;
    private bool isGrounded;
    private bool isOnJumpad;

    private CharacterController _charCtrl;
    private Animator _animCtrl;


    private void Start()
    {
        _charCtrl = GetComponent<CharacterController>();
        _animCtrl = GetComponent<Animator>();
        stepOffset = _charCtrl.stepOffset;
    }

    private void Update()
    {
        //Para que se muera
        if (life <= 0)
        {
            //No vamos a poner esto todavia para acer testing
            //_charCtrl.enabled = false;

            Debug.Log("You are dead");
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Reduce the speed while shifting
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            horizontalInput *= 0.75f;
            verticalInput *= 0.75f;
        }

        //direction of the movement
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }

        _animCtrl.SetFloat("Horizontal",horizontalInput, 0.05f, Time.deltaTime);
        _animCtrl.SetFloat("Vertical",verticalInput, 0.05f, Time.deltaTime);


        ySpeed += gravity * Time.deltaTime;

        if (_charCtrl.isGrounded)
        {
            groundPress = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPress = Time.time;
        }

        if (Time.time - groundPress <= gracePeriod)
        {
            ySpeed = -1.5f;

            _charCtrl.stepOffset = stepOffset;

            _animCtrl.SetBool("isGrounded", true);
            isGrounded = true;
            _animCtrl.SetBool("isJumping", false);
            isJumping = false;
            _animCtrl.SetBool("isFalling", false);
            _animCtrl.SetBool("isOnJumpPad", false);

            if (Time.time - jumpPress <= gracePeriod)
            {
                ySpeed = jumpsSpeed;

                jumpPress = null;
                groundPress = null;

                _animCtrl.SetBool("isJumping", true);
                isJumping = true;
            }
        }
        else
        {
            _charCtrl.stepOffset = 0;

            _animCtrl.SetBool("isGrounded", false);
            isGrounded = false;

            if((isJumping && ySpeed < 0) || ySpeed < -2)
            {
                _animCtrl.SetBool("isFalling", true);
            }
        }

        if (isOnJumpad)
        {
            ySpeed = jumpPadStrength;

            jumpPress = null;
            groundPress = null;

            _animCtrl.SetBool("isFalling", true);

            isOnJumpad = false;
        }

        if(direction != Vector3.zero)
        {
            _animCtrl.SetBool("isMoving", true);
        }
        else
        {
            _animCtrl.SetBool("isMoving", false);
        }

        if (!isGrounded)
        {
            Vector3 velocity = direction * airSpeed;
            velocity.y = ySpeed;

            _charCtrl.Move(velocity * Time.deltaTime);
        }


    }

    public void JumpPad()
    {
        isOnJumpad = true;
        _animCtrl.SetBool("isOnJumpPad", true);
    }

    private void OnAnimatorMove()
    {
        if (isGrounded)
        {
            Vector3 velocity = _animCtrl.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime;

            _charCtrl.Move(velocity);
        }
    }

    //Para que baje la vida con los balazos
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bullet"))
        {
            life--;
        }
    }
}

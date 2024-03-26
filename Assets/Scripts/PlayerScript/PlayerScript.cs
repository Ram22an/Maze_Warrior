using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody myBody;
    private Animator myAnim;
    private bool isPlayerMoving;
    private float playerSpeed = 2.5f;
    private float rotationSpeed = 4f;
    private float jumpForce = 3f;
    private bool canjump=true;
    private float moveHorizontal, moveVertical;
    private float rotY = 0f;
    public Transform GroundCheck;
    public LayerMask GroundLayer;


    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Start()
    {
        rotY=transform.localRotation.eulerAngles.y;
    }

    void Update()
    {
        PlayerMoveKeyboard();
        animatePlayer();
        attack();
        IsOnGround();
        Jump();
    }

    void FixedUpdate()
    {
        MoveandRotate();
    }

    void PlayerMoveKeyboard()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveHorizontal = -1;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveHorizontal = 0;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveHorizontal = 1;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveHorizontal = 0;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveVertical = 1;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveVertical = 0;
        }
    }
    void MoveandRotate()
    {
        if (moveVertical != 0)
        {
            myBody.MovePosition(transform.position+transform.forward*(moveVertical*playerSpeed));
        }
        rotY += moveHorizontal * rotationSpeed;
        myBody.rotation=Quaternion.Euler(0f,rotY,0f);
    }

    void animatePlayer()
    {
        if (moveVertical != 0)
        {
            if (!isPlayerMoving)
            {
                if (!myAnim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.Run_Animation))
                {
                    isPlayerMoving = true;
                    myAnim.SetTrigger(MyTags.Run_Trigger);
                }
            }
        }
        else
        {
            if (isPlayerMoving)
            {
                if (myAnim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.Run_Animation))
                {
                    isPlayerMoving = false;
                    myAnim.SetTrigger(MyTags.Stop_Trigger);
                }
            }
        }
    }
    void attack()
    {
        if(Input.GetKeyDown(KeyCode.K)) 
        {
            if (!myAnim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.Attack_Animation)||
                !myAnim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.Run_Attack_Animation))
            {
                myAnim.SetTrigger(MyTags.Attack_Trigger);
            }
        }
    }

    void IsOnGround()
    {
        //if we are ground canjump will return true else false
        canjump = Physics.Raycast(GroundCheck.position, Vector3.down, 1f, GroundLayer);
        //Debug.Log("this is on ground ");
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("this is jump or space \n");
            Debug.Log(canjump);
            if(canjump)
            {
                Debug.Log("This is can jump inside");
                canjump=false;
                myBody.MovePosition(transform.position+transform.up*(jumpForce*playerSpeed));
                myAnim.SetTrigger(MyTags.Jump_Trigger); 
            }
        }
    }








}//class

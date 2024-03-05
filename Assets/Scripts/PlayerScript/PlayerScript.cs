using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody myBody;
    private Animator myAnim;
    private bool isPlayerMoving;
    private float playerSpeed = 0.5f;
    private float rotationSpeed = 4f;
    private float jumpForce = 3f;
    private bool canjump;
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
            Debug.Log("Hello");
        }
    }
    void MoveandRotate()
    {

    }





}//class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // RB and Camera 
    Rigidbody rb; 
    Transform cameraTransform;

    // Mouse Controller 
    private float mouseX;
    private float mouseY;
    private float yawH = 1000f;
    private float pitchV = 1000f;
    public float speed = 5.0f;
    //public float jumpForce = 5f;
    
    // Distance of player to ground
    [SerializeField] private float groundDistance =0.4f;
    [SerializeField] private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundMask;

    public TextMeshProUGUI stext_1;
    public TextMeshProUGUI stext_2;
    public TextMeshProUGUI stext_3;
    public TextMeshProUGUI stext_4;
    public TextMeshProUGUI stext_5;

    public bool cflag; 
    public Image img;

    public GameObject friend;
    public GameObject fspawn;

 
    void Start()
    {   
        
        // RB and Camera Setup
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        cflag = true;
        cameraTransform = Camera.main.transform;

        setUI();

        img.enabled = false; 
    }

    void Update()
    {
        //CheckGrounded();
        look();
        //Jump();
        isCursorLocked();
        
        // Close window
        if(Input.GetKeyDown(KeyCode.E)){
            img.enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            Instantiate(friend, fspawn.transform.position, Quaternion.Euler(0f,180f,0f));
        }
    }

    void FixedUpdate(){
        PlayerMovement();
    }

    void isCursorLocked(){
        if(Input.GetKey(KeyCode.Q)){
            if(cflag == true){
                Cursor.lockState = CursorLockMode.None;
                cflag = false;
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }
            else{
                Cursor.lockState = CursorLockMode.Locked;
                cflag = true;
                rb.constraints = RigidbodyConstraints.None;
            }
        }
    }

    void setUI(){
        stext_1.GetComponent<TextMeshProUGUI>().SetText("");
        stext_2.GetComponent<TextMeshProUGUI>().SetText("");
        stext_3.GetComponent<TextMeshProUGUI>().SetText("");
        stext_4.GetComponent<TextMeshProUGUI>().SetText("");
        stext_5.GetComponent<TextMeshProUGUI>().SetText("");
    }

    void PlayerMovement()
    {
        Vector3 movement = Vector3.zero; 
        if (Input.GetKey(KeyCode.W)){ movement += transform.forward;}
        if (Input.GetKey(KeyCode.A)){ movement += transform.TransformDirection (Vector3.left);}
        if (Input.GetKey(KeyCode.S)){ movement -= transform.forward;}
        if (Input.GetKey(KeyCode.D)){ movement += transform.TransformDirection (Vector3.right);}

        movement = Vector3.Normalize (movement);
        movement = movement * speed;
        rb.MovePosition (transform.position + movement *Time.deltaTime);       
    }

    /* No need to jump
    void CheckGrounded(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    }

    void Jump(){
         if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    */
    void look()
    {
        mouseX += Input.GetAxis("Mouse X") * yawH * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * pitchV *Time.deltaTime;
    
        mouseY = Mathf.Clamp(mouseY, -30f, 80f);
        transform.eulerAngles = new Vector3(-mouseY, mouseX,0f);
    }   

    // Collision for items 
    // void OnCollisionEnter(Collision col){
    //     if(col.gameObject.tag == "Floor" ){
    //         isGrounded = true;
    //     }
    // }
    // void OnCollisionExit(Collision col){
    //     if(col.gameObject.tag == "Floor" ){
    //         isGrounded = false; 
    //     }
    // }


}
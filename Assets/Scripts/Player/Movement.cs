using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Unassorted
    public Rigidbody rb;
    #endregion
    #region Basic Movement
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private float crouchMultiplier;
    [SerializeField] private Vector3 jumpDist;
    [SerializeField] private float jumpForce;
    [SerializeField] private float MoveX;
    [SerializeField] private float MoveZ;
    public bool isGrounded = true;
    #endregion
    #region Advanced Movement
    public bool isHanging = false;
    public GameObject ledgeDetector;
    private bool canMantle = false;
    public GameObject thisPlayer;
    private bool isSprinting = false;
    private bool isCrouching = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == false)
        {
            canMantle = true;
        }
        MovePlayerBasic();
        #region Collect Inputs
        MoveX = Input.GetAxisRaw("Horizontal");
        //Gives a value of either 1 or -1 when the D or A keys are pressed 
        MoveZ = Input.GetAxisRaw("Vertical");
        //Gives a value of either 1 or -1 when W or S is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed * sprintMultiplier;
            isSprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
            isSprinting = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            moveSpeed = walkSpeed * crouchMultiplier;
            isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            moveSpeed = walkSpeed;
            isCrouching = false;
        }
        if (isHanging == true && Input.GetKeyDown(KeyCode.W))
        {
            Transform destination = ledgeDetector.GetComponent<LedgeHang>().ledgeTransform;
            thisPlayer.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y + 3, destination.transform.position.z);
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            isHanging = false;
        }
        #endregion
        #region Jump 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        #endregion
        #region MovementState
        if((rb.velocity.x < 0 || rb.velocity.x > 0 || rb.velocity.z < 0 || rb.velocity.z > 0) && isSprinting == false && isCrouching == false && isGrounded)
        {
            thisPlayer.GetComponent<PlayerState>().state = State.Walking;
        }
        else if ((rb.velocity.x < 0 || rb.velocity.x > 0 || rb.velocity.z < 0 || rb.velocity.z > 0) && isSprinting == true && isGrounded)
        {
            thisPlayer.GetComponent<PlayerState>().state = State.Running;
        }
        else if ((rb.velocity.x < 0 || rb.velocity.x > 0 || rb.velocity.z < 0 || rb.velocity.z > 0) && isCrouching == true && isSprinting == false && isGrounded)
        {
            thisPlayer.GetComponent<PlayerState>().state = State.Crouching;
        }
        else if (isHanging == true)
        {
            thisPlayer.GetComponent<PlayerState>().state = State.Hanging;
        }
        else if (isGrounded == false && isHanging == false)
        {
            thisPlayer.GetComponent<PlayerState>().state = State.Jumping;
        }
        else
        {
            thisPlayer.GetComponent<PlayerState>().state = State.Neutral;
        }
        #endregion
    }
    private void Jump()
    {
        rb.AddForce(jumpForce * jumpDist, ForceMode.Impulse);
        isGrounded = false;

    }
    private void MovePlayerBasic ()
    {
        rb.velocity = transform.TransformDirection(new Vector3(MoveX * moveSpeed, rb.velocity.y, MoveZ * moveSpeed));
    }
    private void Climb()
    {

    }
}

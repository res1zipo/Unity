using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    [System.Serializable]
    public class MoveSettings
    {
        public float forwardVel = 12;
        public float rotateVel = 100;
        public float jumpVel = 25;
        public float distToGrounded = 1;
        public LayerMask ground;
    }
    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 0.75f;
    }
    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }

    public MoveSettings moveSettings = new MoveSettings();
    public PhysSettings physSettings = new PhysSettings();
    public InputSettings inputSettings = new InputSettings();

    Vector3 velocity = Vector3.zero;
    Quaternion targetRotation;
    Rigidbody rb;
    float inputForward, inputTurn, jumpInput;


    public Quaternion TargetRotation
    {
        get{ return targetRotation; }
    }
    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSettings.distToGrounded, moveSettings.ground);
    }
    void Start() {
        
        targetRotation = transform.rotation;

        if (GetComponent<Rigidbody>())
            rb = GetComponent<Rigidbody>();
        else
            Debug.LogWarning ("no ridgidbody on Character");

        inputForward = inputTurn = jumpInput = 0;
    }
    void GetInput(){

        inputForward = Input.GetAxis(inputSettings.FORWARD_AXIS);
        inputTurn = Input.GetAxis(inputSettings.TURN_AXIS);
        jumpInput = Input.GetAxisRaw(inputSettings.JUMP_AXIS);
    }
    void Update(){

        GetInput();
        Turn();
    }
    void FixedUpdate(){

        Run();
        Jump();

        rb.velocity = transform.TransformDirection(velocity);
    }
    void Run(){

        if (Mathf.Abs(inputForward) > inputSettings.inputDelay)
        {
            //move
            velocity.z = inputForward * moveSettings.forwardVel;
        }
        else//zero velocity
            velocity.z = 0;
    }
    void Turn(){

        if (Mathf.Abs(inputTurn) > inputSettings.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSettings.rotateVel * inputTurn * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }
    void Jump(){

        if (jumpInput > 0 && Grounded())
        {
            //jump
            velocity.y = moveSettings.jumpVel;
        }
        else if (jumpInput == 0 && Grounded())
        {
            //zero out our velocity.y
            velocity.y = 0;
        }
        else
        {
            //decrease velocity.y
           velocity.y  -= physSettings.downAccel;


        }
    }
}

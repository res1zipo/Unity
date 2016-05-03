using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody2D myRigidbody;
    Animator myAnimator;

    [SerializeField] 
    float movementSpeed;
    bool attack;

    bool facingRight;


	// Use this for initialization
	void Start () {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}

    void Update()
    {
        HandleInput();

    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {

        float horizontal = Input.GetAxis("Horizontal");
        
        HandleMovement(horizontal);

        Flip(horizontal);

        HandleAttacks();
        ResetValues();

	}


    void HandleMovement(float horizontal)
    {

        if(!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y); // x = -1 y =0

        }


        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }


    void HandleAttacks()
    {
        if(attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myAnimator.SetTrigger("attack");
            myRigidbody.velocity = Vector2.zero;
        }
    }

    void HandleInput()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack = true;
        }
        
    }




    // flips sprite to face the other direction
    void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;


        }
    }

    void ResetValues()
    {
        attack = false;
    }
}

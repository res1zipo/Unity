using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movment : MonoBehaviour 
	{
	    Animator anim;

        //   bool isRunning = false;

	    float runSpeed;


        float rotationX;
        float vAxis;
        float hAxis;



	    void Awake()
	    {
		anim = GetComponent<Animator>();
	    }

	    void Update()
	    {
        
        //sprint();




        //Jumping():

		//Turning();

	    //	Move();

        vAxis = Input.GetAxis ("Vertical");
        //Debug.Log(vAxis);   

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!anim.GetBool("Run"))
            {
                anim.SetBool("Run", true);
                runSpeed = 1f;
                Debug.LogWarning("Run: " + anim.GetBool("Run"));
            }
            else
            {
                anim.SetBool("Run", false);
                runSpeed = .5f;
                Debug.LogWarning("Run: " + anim.GetBool("Run") + " " + runSpeed);
            }



            float movementSpeed = (0.5f + runSpeed) * vAxis;
            Debug.Log(movementSpeed);   
            anim.SetFloat("Forward", movementSpeed);



        }


	}

        void getInput()
        {
            
        }

//	void Turning()
//	{
////      turning
////      rotationX += Input.GetAxis("Mouse X");
////      transform.localEulerAngles = new Vector3(0, rotationX, 0);
////  
////      use rotation
//
////			
////		if (!anim.GetBool ("Walk")) {
////			anim.SetFloat ("Turn", Input.GetAxis ("Horizontal"));
////		} else {
////			//TODO lerp clamped float to Input float
////			anim.SetFloat ("Turn", Mathf.Clamp (Input.GetAxis ("Horizontal"), -WALKSPEED, WALKSPEED));
////		}
//}
//
//	
//	void Move()
//	{
//        
//
//
//        //float hAxis = Input.GetAxis ("Horizontal"); 
//        //anim.SetFloat ("Strafe", hAxis);
//
//          //  Mathf.SmoothDamp();
//		
//	}




}

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, -6, -8);
    public float xtilt = 10;

    Vector3 destination = Vector3.zero;
    playerController charController;
    float rotateYVel = 0;
    float rotateXVel = 0;


	// Use this for initialization
	void Start () {
        
        SetCameraTarget(target);
	}
    void SetCameraTarget(Transform t){
        target = t;

        if (target != null)
        {
            if (target.GetComponent<playerController>())
            {
                charController = target.GetComponent<playerController>();
            }
            else
                Debug.Log("The camera's target needs a Player Contraller");
        }
        else
            Debug.LogError("Your Camera needs a target.");
    }
    void LateUpdate () {
	    
        //moving
        MoveToTarget();
        //Turning
        LookAtTrget();
	}
    void MoveToTarget(){

        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }
    void LookAtTrget(){
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateYVel, lookSmooth);
        float eulerXAngle = Mathf.SmoothDampAngle(transform.eulerAngles.x, target.eulerAngles.x + xtilt, ref rotateXVel, lookSmooth);
        transform.rotation = Quaternion.Euler(eulerXAngle, eulerYAngle, 0);
    }
}

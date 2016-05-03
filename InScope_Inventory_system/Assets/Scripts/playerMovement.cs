using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
    public float speed = 10f;

	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(Input.GetAxis("Horizontal")* speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
	}
}

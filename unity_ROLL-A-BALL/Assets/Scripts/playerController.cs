using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
	[SerializeField] float speed;
	[SerializeField] Text countText;
	[SerializeField] Text winText;


    Rigidbody rb;
    Transform mt;
    Vector3 startpos;
	int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        mt = GetComponent<Transform>();
        startpos = mt.position;        //could be any Vector3 position (i.e. spown point)
		count = 0;
		updateCount();
		winText.text = "";
    }

    void Update()
    {
        outofbounds();

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed );
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("PickUP"))
				other.gameObject.SetActive(false);
		count = count + 1;
		updateCount();
	}
	void updateCount()
	{
		countText.text = "Count: " + count.ToString ();
		if (count == 12) {
			winText.text = "YOU WIN";
		}
	}
    void outofbounds()
    {
        //opps i fell out of the world
        if (mt.position.y  < -2.0f)
        {
            
            mt.position = startpos;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

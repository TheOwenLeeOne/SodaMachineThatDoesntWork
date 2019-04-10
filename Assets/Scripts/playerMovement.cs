using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public int speed = 3;

	[SerializeField]
   private Rigidbody playerBody;

   private Vector3 inputVector;
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    void Update()
    {	
    	//Debug.Log("x: " + Input.GetAxis("LeftJoystickX"));
    	inputVector = new Vector3(speed*Input.GetAxis("LeftJoystickX"),playerBody.velocity.y, -1*speed*Input.GetAxis("LeftJoystickZ"));
    	transform.LookAt(transform.position + new Vector3(inputVector.x, 0 , inputVector.z));
    	
	}
	void FixedUpdate(){
		playerBody.velocity = inputVector;
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Ball"){

            FixedJoint joint = gameObject.AddComponent<FixedJoint>(); 
            joint.connectedBody = col.rigidbody;
            joint.enableCollision = false;
            joint.enablePreprocessing = false;
            col.rigidbody.mass=0;
		}
	}

  


}

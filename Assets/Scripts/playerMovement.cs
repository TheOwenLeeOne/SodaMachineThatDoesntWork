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

				     // creates joint
     FixedJoint joint = gameObject.AddComponent<FixedJoint>(); 
     // sets joint position to point of contact
     joint.anchor = col.contacts[0].point; 
     // conects the joint to the other object
     joint.connectedBody = col.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>(); 
     // Stops objects from continuing to collide and creating more joints
     joint.enableCollision = false; 
		}
	}

  


}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 6f;
    public float vertSpeed = 5f;
    public Transform cameraTransform;

    Rigidbody playerRigidBody;
    PlayerLogic playerLogic;

	// Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody>();
        playerLogic = GetComponent<PlayerLogic>();
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        float jump = 0f;

        if(Input.GetKeyDown("space") && playerRigidBody.velocity.y > -.5 && playerRigidBody.velocity.y < .5)
        {
            jump = playerLogic.size + vertSpeed;
            playerRigidBody.AddForce(0f, jump, 0f, ForceMode.VelocityChange);
        }
        /*if(Input.GetKeyDown("escape"))
        {
            if(Cursor.lockState == CursorLockMode.Confined)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
            }
        }*/
        if(Input.GetKeyDown("c")) {
            GameObject pickups = GameObject.FindGameObjectWithTag("Pickupable");
            LegoController[] children = pickups.GetComponentsInChildren<LegoController>();
            foreach(LegoController child in children)
            {
                child.transform.parent = transform;
            }
        }

        //get the forward vector
        Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
        forward.y = 0f;
        forward = forward.normalized;
        
        //get the strafe vector (right side)
        Vector3 strafe = new Vector3(forward.z, 0.0f, -forward.x);

        Vector3 moveDirection = (Input.GetAxisRaw("Horizontal") * strafe + Input.GetAxisRaw("Vertical") * forward).normalized;
        moveDirection *= speed * Time.deltaTime;
        playerRigidBody.AddForce(moveDirection);
    }
}

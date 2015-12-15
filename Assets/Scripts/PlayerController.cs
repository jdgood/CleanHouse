using UnityEngine;

/* Handle all player inputs for both mouse/keyboard and mobile */
public class PlayerController : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public float speed = 6f;
    public float vertSpeed = 5f;
    public Transform cameraTransform;

    Rigidbody playerRigidBody;
    PlayerLogic playerLogic;
    Vector2 fingerDown;
    Vector2 intermediate;
    Vector3 followDistance;
    float driftX = 0f;
    float driftY = 0f;

    //Commented out cursor and lock and visibility due to it not working nice within the unity editor (probably made more for an executable I assume)
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerLogic = GetComponent<PlayerLogic>();
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
        fingerDown = -Vector2.one;
        followDistance = cameraTransform.position - transform.position;
    }

    //Get player input and apply to sphere and camera accordingly
    void Update()
    {
        float jump = 0f;
        float h = 0f;
        float v = 0f;
        float xMovement = 0f;

        //get the forward vector relative to the camera so we know what the horizontal axis maps to
        Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
        forward.y = 0f;
        forward = forward.normalized;

        //Specific mouse and keyboard controls for PC
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        //Jump if spacebar is hit and if y velocity is minimal (sphere is in air after it picks up stuff and is a little bouncy, thats why I did it this way)
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
        //Cheat key to instawin the game
        if(Input.GetKeyDown("c"))
        {
            GameObject pickups = GameObject.FindGameObjectWithTag("Pickupable");
            LegoController[] children = pickups.GetComponentsInChildren<LegoController>();
            foreach(LegoController child in children)
            {
                child.transform.parent = transform;
            }
        }

        //get WASD and mouse inputs
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        xMovement = Input.GetAxis("Mouse X");

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        //Player put their finger down
        if(Input.touchCount > 0)
        {
            Touch firstFinger = Input.touches[0];
            //Register initial positions
            if(firstFinger.phase == TouchPhase.Began)
            {
                fingerDown = firstFinger.position;
                intermediate = firstFinger.position;
                driftX = 0f;
                driftY = 0f;
            }
            //Calculate the total drift of a complete movement to see if this was a tap (could have been done with a timer too)
            else if(firstFinger.phase == TouchPhase.Ended && fingerDown.x >= 0) 
            { 
                Vector2 fingerUp = firstFinger.position;        
                float x = fingerUp.x - fingerDown.x;
                float y = fingerUp.y - fingerDown.y;
                fingerDown.x = -1;

                //considering this a tap (jump input) since minimal movement
                if (driftX < 100 && driftY < 100) 
                {
                    jump = playerLogic.size + vertSpeed;
                    playerRigidBody.AddForce(0f, jump, 0f, ForceMode.VelocityChange);
                }
            }
            //Move camera as player is moving their finger
            else if(fingerDown.x >= 0)
            {
                float x = firstFinger.position.x - intermediate.x;
                float y = firstFinger.position.y - intermediate.y;
                //Keep track of total drift for tap input (prevents a case where player moves finger back to original spot and causes a jump if we only track first and last inputs to determine tap)
                driftX += Mathf.Abs(x);
                driftY += Mathf.Abs(y);
                xMovement = x * 10 / Screen.width;
                intermediate = firstFinger.position;
            }
        }

        //Detects how the phone is being held to determine sphere movement
        h = Input.acceleration.x;
        v = Input.acceleration.y;
#endif

        //get the strafe vector (right side) tp determine the direction to move when moving left and right
        Vector3 strafe = new Vector3(forward.z, 0.0f, -forward.x);


        //handle movement first since we calculated vectors based on old camera
        Vector3 moveDirection = (h * strafe + v * forward).normalized;
        moveDirection *= speed * Time.deltaTime;
        playerRigidBody.AddForce(moveDirection);

        //rotate camera around player after
        Vector3 newCameraPosition = transform.position + followDistance;
        cameraTransform.position = newCameraPosition;
        cameraTransform.RotateAround(transform.position, Vector3.up, xMovement * cameraSpeed);
        followDistance = cameraTransform.position - transform.position;
    }
}

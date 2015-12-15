using UnityEngine;
using System.Collections;

public class LegoController : MonoBehaviour {
    public float size = .25f;
    public bool stuckToPlayer = false;

    GameObject player;
    PlayerLogic playerLogic;
    Rigidbody playerRigidbody;
    GameObject pickups;
    BoxCollider trigger;
    Vector3 originalPosition;
    Quaternion originalRotation;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLogic = player.GetComponent<PlayerLogic>();
        playerRigidbody = player.GetComponent<Rigidbody>();
        pickups = GameObject.FindGameObjectWithTag("Pickupable");
        trigger = GetComponent<BoxCollider>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        PlayerLogic.damageCoolDownTimer -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        LegoController lc = other.gameObject.GetComponent<LegoController>();
        //check if player or object stuck to player
        if (other.gameObject == player || (lc != null && lc.stuckToPlayer == true))
        {
            //check if ball is big enough to pick
            //Debug.Log("My size: " + playerLogic.size + " Lego Size: " + size + " Ratio: " + size / playerLogic.pickupRatio + " Speed: " + playerRigidbody.velocity.magnitude);
            if (size/playerLogic.pickupRatio <= playerLogic.size)
            {
                //attach
                transform.parent = player.transform;
                stuckToPlayer = true;
                trigger.isTrigger = false;
                playerLogic.size += size;
            }
            else
            {
                LegoController[] children = player.GetComponentsInChildren<LegoController>();
                //knock brick off if you hit something too big to pick up at a high speed
                if (PlayerLogic.damageCoolDownTimer < 0 && children.Length > 0 && playerRigidbody.velocity.magnitude > 1.5)
                {
                    //randomly knock something off causes floating bricks so just going to remove last picked up instead
                    //children[Random.Range(0, children.Length)].Detach();
                    children[children.Length - 1].Detach();
                    PlayerLogic.damageCoolDownTimer = PlayerLogic.COOL_DOWN_LIMIT;
                }
            }
        }
    }

    public void Detach()
    {
        Debug.Log("Detaching");
        transform.parent = pickups.transform;
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        stuckToPlayer = false;
        trigger.isTrigger = true;
        playerLogic.size -= size;
    }
}
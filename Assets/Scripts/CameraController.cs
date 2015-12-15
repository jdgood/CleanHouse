using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public float speed = 5f;
    public Transform player;

    Vector3 followDistance;

    void Start()
    {
        followDistance = transform.position - player.position;
    }
    
    void LateUpdate()
    {
        Vector3 newCameraPosition = player.position + followDistance;
        transform.position = newCameraPosition;
        transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
        followDistance = transform.position - player.position;
    }
}

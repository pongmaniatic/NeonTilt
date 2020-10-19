using System;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject extraTrailEffect;
    private Transform trail;
    public Transform _camera;
    public float movementForce = 0.5f;
    private Rigidbody rigidbodyofBall;
    [NonSerialized] public bool isPoweredUp = false;
    void Start()
    {
        trail=Instantiate(extraTrailEffect.transform);
        rigidbodyofBall = gameObject.GetComponent<Rigidbody>();
        _camera = Camera.main.transform;
    }
    private void FixedUpdate()
    {
        trail.position = transform.position;
        // this gets what button was clicked and makes it into a 1,0 or -1 value and feed it into an ecuation to get the desired rotation.
        float dirX = -Input.GetAxis("Horizontal");
        float dirY = -Input.GetAxis("Vertical");
        if (dirX > 0) { rigidbodyofBall.AddForce(-_camera.right * movementForce, ForceMode.Force); }
        if (dirX < 0) { rigidbodyofBall.AddForce(_camera.right * movementForce, ForceMode.Force); }
        if (dirY > 0) { rigidbodyofBall.AddForce(-_camera.forward * movementForce, ForceMode.Force); }
        if (dirY < 0) { rigidbodyofBall.AddForce(_camera.forward * movementForce, ForceMode.Force); }
    }

}

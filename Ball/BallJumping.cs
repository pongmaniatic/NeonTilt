using System.Collections;
using UnityEngine;

public class BallJumping : MonoBehaviour
{
    public float jumpForce = 0.5f;
    [Range(2f, 10f), Tooltip("Force downwards, should be higher than jump")]
    public float smashForce = 2;
    private Rigidbody rigidbodyofBall;
    private Vector3 downDirection = new Vector3(0, -1, 0);
    public Vector3 floorPoint, floorNormal;
    Vector3 velocity;
    RaycastHit hit;
    float distanceToFloor;

    bool desiredJump;
    private BallAudioClips ballAudioClips;
    void Start()
    {
        rigidbodyofBall = gameObject.GetComponent<Rigidbody>();
        ballAudioClips = GetComponent<BallAudioClips>();
    }
    void Update()
    {
        Vector3 position = transform.position;
        Physics.Raycast(position, downDirection, out hit, Mathf.Infinity);
        Debug.DrawRay(position, downDirection * 10, Color.red);
        floorPoint = hit.point;
        distanceToFloor = hit.distance;
        floorNormal = hit.normal;

        desiredJump |= Input.GetButtonDown("Jump");

        if (Input.GetKeyDown(KeyCode.LeftShift) && !OnGround(distanceToFloor))
        {
            rigidbodyofBall.velocity = Vector3.down * smashForce;
            ballAudioClips.PlaySmashAudio();
        }
    }

    void FixedUpdate()
    {
        if (desiredJump && OnGround(distanceToFloor))
        {
            desiredJump = false;
            rigidbodyofBall.AddForce(floorNormal * jumpForce, ForceMode.Impulse);
            ballAudioClips.PlayJumpAudio();
        }
    }
    bool OnGround(float distance) => distance <= 0.5f;
}

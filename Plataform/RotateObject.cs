using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotSpeed = 1f;// how fast the plataform returns to its ideal rotation.
    private GameObject Camera;//the plataform tilts in reference to this objects rotation.
    public float AllowedAngle = 25;//how far the palataform can turn.
    private float minAngle;
    private float maxAngle;

    private void Start()
    {
        minAngle = 0 + AllowedAngle;
        maxAngle = 360 - AllowedAngle;
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void FixedUpdate()
    {
        float rotX = Input.GetAxis("Horizontal");
        float rotY = Input.GetAxis("Vertical");
        if (rotY > 0){transform.Rotate(Camera.transform.right);}
        if (rotY < 0){transform.Rotate(-Camera.transform.right);}
        if (rotX > 0){transform.Rotate(-Camera.transform.forward);transform.Rotate(-Camera.transform.up);}
        if (rotX < 0){transform.Rotate(Camera.transform.forward);transform.Rotate(Camera.transform.up);}
        //this is limiting the rotation of the plataform by snaping it into the limit.
        if (transform.eulerAngles.z > minAngle && transform.eulerAngles.z < maxAngle)
        {
            float DistanceToLimit1 = transform.eulerAngles.z - minAngle;
            float DistanceToLimit2 = maxAngle - transform.eulerAngles.z;
            if (DistanceToLimit1 > DistanceToLimit2) {transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, maxAngle);}
            if (DistanceToLimit1 < DistanceToLimit2) { transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, minAngle);}
        }
        if (transform.eulerAngles.x > minAngle && transform.eulerAngles.x < maxAngle)
        {
            float DistanceToLimit1 = transform.eulerAngles.x - minAngle;
            float DistanceToLimit2 = maxAngle - transform.eulerAngles.x;
            if (DistanceToLimit1 > DistanceToLimit2) {transform.rotation = Quaternion.Euler(maxAngle, transform.eulerAngles.y, transform.eulerAngles.z);}
            if (DistanceToLimit1 < DistanceToLimit2) {transform.rotation = Quaternion.Euler(minAngle, transform.eulerAngles.y, transform.eulerAngles.z);}
        }
        //this smoothly turns the current rotation into the stablished desired rotation. 
        Vector3 direction = gameObject.transform.position - transform.position + new Vector3(0, 0, 1);
        Quaternion rotation = Quaternion.LookRotation(direction);
        if (transform.rotation != rotation){transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSpeed);}
    }
}
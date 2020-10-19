using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float ClampAngleX = 30f;// this determines at what angle is the pitched angle capped.
    private float CameraMoveSpeed = 10;// how fast the camera moves.
    private float InputSensitivity = 275.0f;// this changes how sensitive is the mouth when translating mouse movement to camera rotation.
    private float mouseX;// mouse position x on screen.
    private float mouseY;// mouse position y on screen.
    private float finalInputX;// this will be the final input after all other are conbined correctly.
    private float finalInputZ;// this will be the final input after all other are conbined correctly.
    private float RotY = 0.0f;// the rotation angle for y.
    private float RotX = 0.0f;// the rotation angle for x.
    public GameObject CameraFollowObj;// what object the camera follows, the player prefab had a new empty oject added to it, that one is used as the object being followed for this scene.
    public int CurrentFloor = 0;
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject floor5;
    public GameObject floor6;
    public GameObject floor7;
    public GameObject floor8;
    public GameObject floor9;
    public GameObject floor10;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float inputX = Input.GetAxis("RightStickHorizontal");// detect the movement inputs in the horizontal axis.
            float inputZ = Input.GetAxis("RightStickVertical");// detect the movement inputs in the Vertical axis.
            mouseX = Input.GetAxis("Mouse X");// get the current x position of the mouse.
            mouseY = Input.GetAxis("Mouse Y");// get the current y position of the mouse.
            finalInputX = inputX + mouseX;// both inputs are combined to get the correct input.
            finalInputZ = inputZ + mouseY;// both inputs are combined to get the correct input.
            RotY += finalInputX * InputSensitivity * Time.deltaTime;// horizontal rotation is applied.
            RotX -= finalInputZ * InputSensitivity * Time.deltaTime;// Vertical rotation is applied.
            RotX = Mathf.Clamp(RotX, -ClampAngleX, ClampAngleX);// limits the horizontal rotation.
            Quaternion localRotation = Quaternion.Euler(RotX, RotY, 0.0f);// defines the correct rotation for the camera.
            transform.rotation = localRotation;// applied the right rotation for the camera.
        }
        if (CurrentFloor == 0){CameraFollowObj = floor1;}
        if (CurrentFloor == 1){CameraFollowObj = floor2;}
        if (CurrentFloor == 2){CameraFollowObj = floor3;}
        if (CurrentFloor == 3){CameraFollowObj = floor4;}
        if (CurrentFloor == 4){CameraFollowObj = floor5;}
        if (CurrentFloor == 5){CameraFollowObj = floor6;}
        if (CurrentFloor == 6){CameraFollowObj = floor7;}
        if (CurrentFloor == 7){CameraFollowObj = floor8;}
        if (CurrentFloor == 8){CameraFollowObj = floor9;}
        if (CurrentFloor == 9){CameraFollowObj = floor10;}
    }

    private void LateUpdate() { CameraUpdater(); } //this makes sure the camera update is done last, so to avoid a jittery camera.

    void CameraUpdater()
    {
        Transform target = CameraFollowObj.transform;// define the position of the player.
        float step = CameraMoveSpeed * Time.deltaTime;// how fast the camera will move.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);// moves the camera holder so it smoothly stays with the player.
    }
}

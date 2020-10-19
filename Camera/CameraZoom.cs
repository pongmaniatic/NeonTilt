using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float MinDistance = 8.5f; // how close can the camera get.
    public float MaxDistance = 20.0f; // how far can the camera get.
    public float CurrentDistance = 11.5f; // how far can the camera is.
    public float Smooth = 8.0f; //this controlls how smooth the transition between blocked by wall and not blocked.
    Vector3 CameraVector; // the vector of the camera in reference to the player.
    public float Distance; // the distance of the camera to the player.
    public float RateOfScrollChange = 1f;// this how fast the zoom in and out moves.

    void Awake()
    {
        CameraVector = transform.localPosition.normalized;// it gets the same vector but makes it with lenght of 1, that way when multiplied by the current camera distance.
        Distance = transform.localPosition.magnitude;// this sets the distance to 1 since a normilized vector is 1 in lenght. 
    }

    void Update()
    {
        Vector3 DesiredCameraPos = transform.parent.TransformPoint(CameraVector * CurrentDistance); // updates the vectors with the current lenght.
        Distance = CurrentDistance;
        transform.localPosition = Vector3.Lerp(transform.localPosition, CameraVector * Distance, Time.deltaTime * Smooth); // interpolates the 2 points so its smooth from one place to the other.
        var ScrollWheelnumber = Input.GetAxis("Mouse ScrollWheel");// detects if the scroll wheel was moved up or down.
        if (ScrollWheelnumber > 0.0f) { CurrentDistance -= RateOfScrollChange; }// if moved up, then the camera gets closer.
        else if (ScrollWheelnumber < 0.0f) { CurrentDistance += RateOfScrollChange; }// if moved down, the camera gets further away.
        if (CurrentDistance > MaxDistance) { CurrentDistance = MaxDistance; }// makes sure the camera does not go to far away.
        if (CurrentDistance < MinDistance) { CurrentDistance = MinDistance; }// makes sure the camera does not go too close.
    }
}

using UnityEngine;

public class Obst_PropellerOld : MonoBehaviour
{
    [Range(-20f,20f)] public float rotateSpeed;
    [Range(0.5f,20f)] public float propellerLength;
    [Range(0.5f,20f)] public float propellerHeight;
    [Range(0.2f,5f)] public float propellerWidth;
    public float flashTime;
    public float knockbackPowerMultiplier;
    private GameObject _currentPlatform;
    private MeshRenderer propellerMesh;
    private Color originalColor;
    private float knockbackPower;
    
    private void Awake()
    {
        //Setup for WhiteFlash
        //propellerMesh = GetComponent<MeshRenderer>();
        //originalColor = propellerMesh.material.color;
        
        FindClosestLevelFloor();
        var objectID = gameObject.GetInstanceID(); // for debug
        //Debug.Log("PropellerID = " + objectID + " Closest LevelFloor = " + _currentPlatform); // prints closest LevelFloor
        
        //Set closest LevelFloor as parent
        var emptyObject = new GameObject();
        emptyObject.transform.parent = _currentPlatform.transform;
        transform.parent = emptyObject.transform;
        
        //Sync the rotation of the transform with LevelFloor transform
        //transform.rotation = _currentPlatform.transform.rotation;
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f,rotateSpeed,0f);
        gameObject.transform.localScale = new Vector3(propellerLength,propellerHeight,propellerWidth);
    }

    private void FindClosestLevelFloor()
    {
        GameObject[] LevelFloorArray;
        LevelFloorArray = GameObject.FindGameObjectsWithTag("LevelFloor");
        float distance = Mathf.Infinity;
        Vector3 propellerPosition = transform.position;
        foreach (var levelFloor in LevelFloorArray)
        {
            Vector3 posDifference = levelFloor.transform.position - propellerPosition;
            float currentMeasure = posDifference.sqrMagnitude;
            if (currentMeasure < distance)
            {
                _currentPlatform = levelFloor;
                distance = currentMeasure;
            }
        }
    }
    public void KnockBack(Rigidbody body, ContactPoint point)
    {
        knockbackPower = knockbackPowerMultiplier * rotateSpeed;
        Debug.Log("Hit by propeller");
        Vector3 velocity = Vector3.Reflect(body.velocity, point.normal);   
        body.velocity = velocity.normalized * knockbackPower; 
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBall"){Debug.Log("Player HIT");}
        if (!other.rigidbody) return;
        ContactPoint[] contactPoints = other.contacts;
        ContactPoint contactpoint = contactPoints[0];
        KnockBack(other.rigidbody, contactpoint);
    }
}
using System;
using UnityEngine;

public class FindParent : MonoBehaviour
{
    private GameObject _currentPlatform;
    private float lifetime = 0.5f;
    private void Awake()
    {
        GetComponent<Animator>().speed = 2;
        FindClosestLevelFloor();

        //Set closest "LevelFloor" as parent
        var emptyObject = new GameObject();
        emptyObject.transform.parent = _currentPlatform.transform;
        transform.parent = emptyObject.transform;
    }
    private void FindClosestLevelFloor()
    {
        GameObject[] LevelFloorArray;
        LevelFloorArray = GameObject.FindGameObjectsWithTag("LevelFloor");
        float distance = Mathf.Infinity;
        Vector3 Position = transform.position;

        foreach (var levelFloor in LevelFloorArray)
        {
            Vector3 posDifference = levelFloor.transform.position - Position;
            float currentMeasure = posDifference.sqrMagnitude;
            if (currentMeasure < distance)
            {
                _currentPlatform = levelFloor;
                distance = currentMeasure;
            }
        }
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}

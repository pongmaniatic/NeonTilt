using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] floorsRespawn;
    private float currentFloor;
    private float ActualFloor;

    private void Start()
    {
        foreach (GameObject respawn in floorsRespawn){respawn.GetComponent<MeshRenderer>().enabled = false;}        
    }
    private void Update()
    {
        currentFloor = LevelPass.goldenBlockNumber.gameState;
        ActualFloor = Mathf.Ceil(currentFloor / 2);
        int floor = 0;
        foreach (GameObject respawn in floorsRespawn)
        {
            floor += 1;
            if (ActualFloor == floor) { transform.position = respawn.transform.position; }
        }
    }
}

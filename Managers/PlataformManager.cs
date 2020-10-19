using UnityEngine;

public class PlataformManager : MonoBehaviour
{
    public int FloorNumber;
    private int actualFloorNumber;
    private LevelPass FloorManager;
    void Start()
    {
        FloorManager = GameObject.FindGameObjectWithTag("EntityManager").GetComponent<LevelPass>(); ;
        actualFloorNumber = FloorNumber *2;
    }
    void Update()
    {
        if (FloorManager.gameState > actualFloorNumber){gameObject.SetActive(false);}
    }
}

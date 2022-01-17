using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public static HoleManager HoleManagerSystem;
    //Hole stuff
    private GameObject[] holes;
    // Start is called before the first frame update

    private void Awake() { HoleManagerSystem = this; }
    void Start()
    {
        //Hole stuff
        holes = GameObject.FindGameObjectsWithTag("Hole");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShouldHolesBeGreenOrRed()
    {
        foreach (var hole in holes)
        {
            hole.GetComponent<HoleBlockChangeColors>().ChangeColor(Color.red);
        }

    }
}

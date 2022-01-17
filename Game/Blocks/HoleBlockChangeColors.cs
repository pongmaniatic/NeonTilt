using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleBlockChangeColors : MonoBehaviour
{
    private Material hole;
    public Material textureGreen;
    public Material textureRed;
    private MeshRenderer _mesh;
    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        hole = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    public void ChangeColor(Color color)
    {
        if(LevelPass.goldenBlockNumber.goldenBlocksLeft >= 1)
        {
            _mesh.material = textureRed;
        }
        if (LevelPass.goldenBlockNumber.goldenBlocksLeft < 1)
        {
            _mesh.material = textureGreen;
        }
    }
}

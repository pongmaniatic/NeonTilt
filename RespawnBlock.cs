using System;
using System.Collections;
using System.Collections.Generic;
using Blocks;
using UnityEngine;

public class RespawnBlock : MonoBehaviour
{
    public GameObject spawnThisBlock;

    public bool respawnThisBlock;
    public float respawnTime;
    

    public void Respawn()
    {
        if (respawnThisBlock)
        {
            GameObject thisInstance = Instantiate(spawnThisBlock, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
    private IEnumerator waitThenRespawn(GameObject thisInstance)
    {
        yield return new WaitForSeconds(respawnTime);
        thisInstance.GetComponent<BoxCollider>().enabled = true;
        thisInstance.GetComponent<MeshRenderer>().enabled = true;
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHole : MonoBehaviour
{
    public GameObject portalPrefab;
    public GameObject ball;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBall")
        {
         //GameObject SpawnedPortal = Instantiate(portalPrefab, transform);
            GameObject SpawnedPortalOnBall = Instantiate(portalPrefab, ball.transform);
            //StartCoroutine(timerForPortal(SpawnedPortal.gameObject));
            StartCoroutine(timerForPortal(SpawnedPortalOnBall.gameObject));

        }
     }



    private IEnumerator timerForPortal(GameObject other)
    {
        yield return new WaitForSeconds(1f);
        Destroy(other);
        yield return null;
    }
}
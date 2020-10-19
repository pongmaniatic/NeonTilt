using UnityEngine;

public class BallShadow : MonoBehaviour
{
    public GameObject ball;
    public GameObject plataform;
    private BallJumping ballScript;
    private Vector3 newPosition;
    public GameObject portalShadowPrefab;
    private GameObject portalShadowSpawner;
    void Start()
    {
        portalShadowSpawner = Instantiate(portalShadowPrefab, transform);
        ballScript = ball.GetComponent<BallJumping>(); 
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = ballScript.floorPoint;
        transform.position = newPosition;
        transform.up = plataform.transform.up;
        portalShadowSpawner.transform.position = transform.position;
        portalShadowSpawner.transform.up = ballScript.floorNormal;
    }
}

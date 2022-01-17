using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePostEffect : MonoBehaviour
{
    Vector3 followPos;
    private GameObject entityManager;
    private Camera cam;
    private bool onlyRunOnce = false;
    public float offset;
    public float smoothing;


    void Start()
    {
        entityManager = GameObject.Find("EntityManager");
        Entity_ActivePostEffect entity = gameObject.AddComponent(typeof(Entity_ActivePostEffect)) as Entity_ActivePostEffect;

        followPos = cam.transform.position;
        transform.position = followPos;
    }

    
    void Update()
    {
        //Find Camera
        if (entityManager.GetComponent<UltimateGameManager>().menuMode == false && onlyRunOnce == false)
        {
            cam = GameObject.FindGameObjectWithTag("GameCamera").GetComponent<Camera>();
            onlyRunOnce = true;
        }

        followPos = cam.transform.position;
        transform.position = Vector3.Lerp(transform.position, followPos + Vector3.up * offset, smoothing * Time.deltaTime);
    }

    public void Effect(float strenght)
    {
        transform.position += Vector3.down * strenght;
        if (transform.position.y < offset)
        {
            transform.position = followPos;
        }
    }
}

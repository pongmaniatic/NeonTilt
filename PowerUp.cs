using System;
using System.Collections;
using System.Collections.Generic;
using Blocks;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject PlayerBall;
    private GameObject entityManager;
    public float upTime;
    public float bonusSpeed;
    public float bulldozeWeight;
    private float defaultSpeed;
    private float defaultMass;
    private bool onlyRunOnce = false;
    private Camera cam;
    private Material defaultColor;//Colorchange
    public Material bulldozeColor;//Colorchange
    public Material speedColor;//Colorchange
    public Shader bulldozeShader;
    public Shader speedShader;
    public GameObject powerupEffect;
    
    
    
    private void Awake()
    {
        entityManager = GameObject.Find("EntityManager");
        PlayerBall = GameObject.FindWithTag("PlayerBall");

        //Cached values
        defaultSpeed = PlayerBall.GetComponent<BallMovement>().movementForce;
        defaultMass = PlayerBall.GetComponent<Rigidbody>().mass;
        defaultColor = PlayerBall.GetComponent<MeshRenderer>().material; //Colorchange
        defaultColor.shader = PlayerBall.GetComponent<MeshRenderer>().material.shader;
    }

    private void FixedUpdate()
    {
        //Find Camera
        if (entityManager.GetComponent<UltimateGameManager>().menuMode == false && onlyRunOnce == false)
        {
            cam = GameObject.FindGameObjectWithTag("GameCamera").GetComponent<Camera>();
            onlyRunOnce = true;
        }
        transform.LookAt(cam.transform);
        var newY = Mathf.Sin(Time.time * 10);
        transform.position += new Vector3(0, newY, 0)*Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerBall")
        {
            Instantiate(powerupEffect, PlayerBall.transform.position,PlayerBall.transform.rotation);
            if (gameObject.tag == "PowerUpSpeed")
            {
                other.gameObject.GetComponent<BallMovement>().movementForce = bonusSpeed;
                PlayerBall.GetComponent<MeshRenderer>().material = speedColor;
                PlayerBall.GetComponent<MeshRenderer>().material.shader = speedShader;
            }
            if (gameObject.tag == "PowerUpBulldoze")
            {
                other.gameObject.GetComponent<BallMovement>().isPoweredUp = true;
                PlayerBall.GetComponent<Rigidbody>().mass = bulldozeWeight;
                PlayerBall.GetComponent<MeshRenderer>().material = bulldozeColor;
                PlayerBall.GetComponent<MeshRenderer>().material.shader = bulldozeShader;
            }
            DeActivate();
            StartCoroutine(PowerUpTimer(other.gameObject));
        }
    }

    private void DeActivate()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }

    private IEnumerator PowerUpTimer(GameObject other)
    {
        yield return new WaitForSeconds(upTime);
        other.gameObject.GetComponent<BallMovement>().movementForce = defaultSpeed;
        PlayerBall.GetComponent<Rigidbody>().mass = defaultMass;
        PlayerBall.GetComponent<MeshRenderer>().material = defaultColor;
        PlayerBall.GetComponent<MeshRenderer>().material.shader = defaultColor.shader;
        other.gameObject.GetComponent<BallMovement>().isPoweredUp = false;
        gameObject.SetActive(false);
        
        yield return null;
    }
}

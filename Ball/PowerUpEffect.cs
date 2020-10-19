using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    private GameObject playerBall;
    private PowerUp powerupScript;
    private float timer = 5;
    void Start()
    {
        powerupScript = GetComponent<PowerUp>();
        playerBall = GameObject.FindWithTag("PlayerBall");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        transform.position = playerBall.transform.position;
        if (timer < 0) gameObject.SetActive(false);
    }
}

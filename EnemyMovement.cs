using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionEnemy { Backwards, Forward, Right, Left, Down, Up }
public class EnemyMovement : MonoBehaviour
{
    public DirectionEnemy enemyMovement;
    public float speed = 1f;
    private Rigidbody rb;
    public float movementTime = 5f;
    public float nextMove = 0f;
    private Vector3 movementDirection;
    private int enemyMovementValue;
    private bool hasDirectionSet = false;
    public Transform platform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        try
        {
            transform.parent = platform.transform;
        }
        catch (System.Exception)
        {
            Debug.LogWarning("The parent floor of a moving platform has not been assigned!");
        }
        
        switch (enemyMovement)
        {
            case (DirectionEnemy)0:
                enemyMovementValue = 0;
                return;
            case (DirectionEnemy)1:
                enemyMovementValue = 1;
                return;
            case (DirectionEnemy)2:
                enemyMovementValue = 2;
                return;
            case (DirectionEnemy)3:
                enemyMovementValue = 3;
                return;
            case (DirectionEnemy)4:
                enemyMovementValue = 4;
                return;
            case (DirectionEnemy)5:
                enemyMovementValue = 5;
                return;
            default:
                enemyMovementValue = 0;
                break;
        }
        DirectionForEnemy();
    }

    void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime * speed);
        if (Time.time > nextMove)
        {
            nextMove = Time.time + movementTime;
            speed = speed * -1;
        }
        //Debug.Log(enemyMovementValue);
        if (hasDirectionSet == false) { hasDirectionSet = true; DirectionForEnemy(); }
    }
    void DirectionForEnemy()
    {
        if (enemyMovementValue == 0) { movementDirection = Vector3.forward;}

        if (enemyMovementValue == 1) { movementDirection = Vector3.back; }

        if (enemyMovementValue == 2) { movementDirection = Vector3.left; }

        if (enemyMovementValue == 3) { movementDirection = Vector3.right; }

        if (enemyMovementValue == 4) { movementDirection = Vector3.up; }

        if (enemyMovementValue == 5) { movementDirection = Vector3.down; }
    }
}


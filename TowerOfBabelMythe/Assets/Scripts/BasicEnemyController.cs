using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField]
    private float
        speed,
        lungeSpeed,
        lungeDuration,
        lungeWindupTime,
        playerDetectRange,
        attackCooldown;

    private float
        lungeStartTime,  
        lungeTimer,
        attackCooldownTimer;

    public bool
        moveRight = true,
        groundDetected,
        wallDetected = false,
        playerDetected;


    [SerializeField] Transform
        groundRaycastOrigin,
        frontRaycastOrigin;

    [SerializeField] Rigidbody rigidbody;

    public enum EnemyState
    {
        Wander,
        Attack,
        Hurt,
    }

    private EnemyState currentState;

    
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Wander:
                UpdateWanderState();
                break;
            case EnemyState.Attack:
                UpdateAttackState();
                break;
            case EnemyState.Hurt:
                break;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchState(EnemyState.Attack);
        }

        groundDetected = Physics.Raycast(groundRaycastOrigin.position, Vector2.down, 2f);
        wallDetected = Physics.Raycast(frontRaycastOrigin.position, transform.right, 0.1f);

        /*Ray wallDetector = new Ray(frontRaycastOrigin.position, transform.right * 0.1f);
        Debug.DrawRay(frontRaycastOrigin.position, transform.right * 0.1f, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(wallDetector, out hit, 0.1f))
        {
            Debug.Log(hit.collider.gameObject.tag);
            if(hit.collider.gameObject.tag == "Terrain")
            {
                wallDetected = true;
            }
            else
            {
                wallDetected = false;
            }
        }*/

    }   

    //Wander---------------------

    void EnterWanderState()
    {
        attackCooldownTimer = attackCooldown;
    }

    void UpdateWanderState()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(!groundDetected || wallDetected)
        {
            if(moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }

        attackCooldownTimer -= Time.deltaTime;

        Ray playerDetector = new Ray(frontRaycastOrigin.position, transform.right * playerDetectRange);
        Debug.DrawRay(frontRaycastOrigin.position, transform.right * playerDetectRange);
        RaycastHit hit;
        if(Physics.Raycast (playerDetector, out hit, playerDetectRange))
        {
            Debug.Log(hit.collider.gameObject);
            if(hit.collider.gameObject.tag == "Player" && attackCooldownTimer <= 0)
            {
                SwitchState(EnemyState.Attack);
            }
        }
    }

    //Attack----------------------

    void EnterAttackState()
    {
        lungeStartTime = Time.time;
        lungeTimer = lungeDuration;
    }

    void UpdateAttackState()
    {                
        
        if (Time.time >= lungeStartTime + lungeWindupTime)
        {
            rigidbody.velocity = transform.right * lungeSpeed;
            lungeTimer -= Time.deltaTime;
        }

        if (lungeTimer <= 0)
        {
            if (groundDetected)
            {
                rigidbody.velocity = new Vector3(0, 0, 0);
            }
            SwitchState(EnemyState.Wander);
        }
    }

    //Other-------------------------

    private void SwitchState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Wander:
                EnterWanderState();
                break;                
            case EnemyState.Attack:
                EnterAttackState();
                break;
            case EnemyState.Hurt:
                break;
        }

        currentState = state;
    }
}

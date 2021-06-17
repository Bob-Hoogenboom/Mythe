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
        Falling,
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
            case EnemyState.Falling:
                UpdateFallingState();
                break;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchState(EnemyState.Attack);
        }

        groundDetected = Physics.Raycast(groundRaycastOrigin.position, Vector2.down, 2f);
        //wallDetected = Physics.Raycast(frontRaycastOrigin.position, transform.right, 0.1f);

        /*Ray wallDetector = new Ray(frontRaycastOrigin.position, transform.right);
        Debug.DrawRay(frontRaycastOrigin.position, transform.right * 0.1f, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(wallDetector, out hit, 0.1f))
        {
            
            if(hit.collider.gameObject.tag == "Terrain")
            {
                wallDetected = true;
                Debug.Log(hit.collider.gameObject.tag);
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

        if (!groundDetected)
        {
            Flip();
        }

        Ray wallDetector = new Ray(frontRaycastOrigin.position, transform.right);
        Debug.DrawRay(frontRaycastOrigin.position, transform.right * 0.1f, Color.red);
        RaycastHit hit0;
        if (Physics.Raycast(wallDetector, out hit0, 0.1f))
        {

            if (hit0.collider.gameObject.tag == "Terrain")
            {
                Flip();
            }
        }
            attackCooldownTimer -= Time.deltaTime;

        Ray playerDetector = new Ray(frontRaycastOrigin.position, transform.right * playerDetectRange);
        Debug.DrawRay(frontRaycastOrigin.position, transform.right * playerDetectRange);
        RaycastHit hit1;
        if(Physics.Raycast (playerDetector, out hit1, playerDetectRange))
        {
            //Debug.Log(hit1.collider.gameObject);
            if(hit1.collider.gameObject.tag == "Player" && attackCooldownTimer <= 0)
            {
                SwitchState(EnemyState.Attack);
            }
        }
    }

    void ExitWanderState()
    {

    }

    void Flip()
    {        
            if (moveRight == true)
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
                SwitchState(EnemyState.Falling);
        }
    }

    void ExitAttackState()
    {

    }

    //Hurt-=-=-=-=-=-=-=-=-=-=-=-=-=


    //Falling-----------------------

    void UpdateFallingState()
    {
        if (groundDetected)
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
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

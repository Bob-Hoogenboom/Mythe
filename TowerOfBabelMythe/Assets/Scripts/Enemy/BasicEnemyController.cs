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
        attackCooldown,
        knockbackForce,
        KnockBackDuration;

    private float
        lungeStartTime,
        lungeTimer,
        attackCooldownTimer,
        knockBackStart;

    private int attackDamage = 1;



    public bool
        moveRight = true,
        groundDetected,
        wallDetected = false,
        playerDetected;


    [SerializeField] Transform
        groundRaycastOrigin,
        frontRaycastOrigin,
        playerPosition;

    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] GameObject _damageBox;
    [SerializeField] GameObject _playerDamageBox;

    Vector3 
        direction;

    public Animator animator;

    public enum EnemyState
    {
        Wander,
        Attack,
        Hurt,
        Falling,
    }

    public EnemyState currentState;

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
                UpdateHurtState();
                break;
            case EnemyState.Falling:
                UpdateFallingState();
                break;
        }

        
        groundDetected = Physics.Raycast(groundRaycastOrigin.position, Vector2.down, 0.5f);        
    }

    void Start()
    {
        SwitchState(EnemyState.Falling);
        _damageBox.SetActive(false);
    }

    private void OnCollisionEnter(Collision DamageCollission)
    {
        if(DamageCollission.collider == _playerDamageBox) //enemy hits player, Player takes damage
        {
            Health PC = GetComponent<Health>();
            PC.TakeDamagePlayer(attackDamage);

        }
    }

    //Wander---------------------

    void EnterWanderState()
    {
        animator.SetBool("IsWalking", true);               
    }

    void UpdateWanderState()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);


        Ray wallDetector = new Ray(frontRaycastOrigin.position, transform.right * 0.1f);
        Debug.DrawRay(frontRaycastOrigin.position, transform.right * 0.1f, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(wallDetector, out hit, 0.1f))
        {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "Terrain")
            {
                Flip();
            }            
        }

        if (!groundDetected)
        {
            Flip();
        }

        attackCooldownTimer -= Time.deltaTime;

        Ray playerDetector = new Ray(frontRaycastOrigin.position, transform.right * playerDetectRange);
        Debug.DrawRay(frontRaycastOrigin.position, transform.right * playerDetectRange);
        RaycastHit hit0;
        if(Physics.Raycast (playerDetector, out hit0, playerDetectRange))
        {
            Debug.Log(hit0.collider.gameObject);
            if(hit0.collider.gameObject.tag == "Player" && attackCooldownTimer <= 0)
            {
                SwitchState(EnemyState.Attack);
            }
        }
    }

    void ExitWanderState()
    {
        animator.ResetTrigger("IdlePose");
        animator.SetBool("IsWalking", false);        
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

            _damageBox.SetActive(true);
            animator.SetTrigger("Attack");
            _rigidbody.velocity = transform.right * lungeSpeed;
            lungeTimer -= Time.deltaTime;
        }

        if (lungeTimer <= 0)
        {            
            SwitchState(EnemyState.Falling);
        }
    }

    void ExitAttackState()
    {
        _damageBox.SetActive(false);

        animator.ResetTrigger("Attack");
        animator.SetTrigger("IdlePose");
        attackCooldownTimer = attackCooldown;
    }

    //Hurt_+_+_+_+_+_+_+_+_+_+_+_+_
    void EnterHurtState()
    {
        animator.ResetTrigger("IdlePose");
        direction = (this.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
        knockBackStart = Time.time;
        animator.SetTrigger("IdlePose");
    }
    
    void UpdateHurtState()
    {
        _rigidbody.velocity = new Vector3(direction.normalized.x * knockbackForce, 0, 0);
        if(Time.time >= knockBackStart + KnockBackDuration && groundDetected)
        {
            _rigidbody.velocity = new Vector3(0, 0, 0);
        }
        if (Time.time >= knockBackStart + KnockBackDuration + 0.2)
        {
            SwitchState(EnemyState.Falling);
        }       
    }
    
    void ExitHurtState()
    {
        animator.ResetTrigger("IdlePose");
    }

    //Falling-=-=-=-=-=-=-=-=-=-=-=

    void UpdateFallingState()
    {
        if (groundDetected)
        {
            _rigidbody.velocity = new Vector3(0, 0, 0);
            SwitchState(EnemyState.Wander);
        }
    }


    //Other-------------------------

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

    public void SwitchState(EnemyState state)
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
                EnterHurtState();
                break;
        }

        switch (currentState)
        {
            case EnemyState.Wander:
                ExitWanderState();
                break;
            case EnemyState.Attack:
                ExitAttackState();
                break;
            case EnemyState.Hurt:
                ExitHurtState();
                break;
        }

        currentState = state;
    }
}

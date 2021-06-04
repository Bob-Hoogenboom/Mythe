using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AnimationCurve accelerationCurve;

    public float accelerationSpeed = 1; //we willen geen accelarations voor snappy movement.
    public float deAccelerationSpeed = 0.25f;
    private float currentAcceleration = 0;

    [SerializeField] float _speed = 5f;
    [SerializeField] float _moveDir;

    [SerializeField] bool _isMoving;
    [SerializeField] bool isFacingRight;

    [SerializeField] Vector2 _movement;
    [SerializeField] Rigidbody _rb;

    private float inputDir = 0;
    private float verDir = 0;

    // enum maken met movement states ( deacc. stilstaan. fullspeed.

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // wat is mijn richting?
        // wat is mijn de-acceleratie
        // hoe moet ik bewegen?

        // hoe moet ik bovenstaande dingen toepassen afhankelijk van mijn state?
        _movement = CharMove();
        float curve = accelerationCurve.Evaluate(currentAcceleration);
        transform.Translate(_movement * curve *_speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }

    private Vector2 CharMove()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            inputDir = Input.GetAxisRaw("Horizontal");
            currentAcceleration += Time.deltaTime * accelerationSpeed;
            currentAcceleration = Mathf.Clamp01(currentAcceleration); //Clamp01 caps the value. it cannot go past 0 or 1
        }
        else
        {
            //Here inputDir will be slowly reduced, or increased to 0 depending if it's moving left or right

            currentAcceleration = 0;
            //inputDir = HelperFunctions.EaseOutCirc(inputDir, _drag);
            Debug.Log(inputDir);
        }

        return new Vector2(inputDir, verDir);
    }
}

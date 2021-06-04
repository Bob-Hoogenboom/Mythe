using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField]
    private float
        speed;        

    private bool
        moveRight = true,
        groundDetected,
        wallDetected;
        

    [SerializeField] Transform 
        groundRaycastOrigin,
        wallRaycastOrigin;
    
    void Update()
    {
        groundDetected = Physics.Raycast(groundRaycastOrigin.position, Vector2.down, 2f);
        wallDetected = Physics.Raycast(wallRaycastOrigin.position, transform.right, 0.1f);

        Debug.Log(groundDetected);

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
    }
}

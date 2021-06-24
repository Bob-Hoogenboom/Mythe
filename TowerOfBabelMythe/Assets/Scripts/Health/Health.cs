using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startHealth = 100f;
    public float healthPoints
    {
        get { return _hP; }
        set
        {
            _hP = Mathf.Clamp(value,0f,100f);

            if(_hP <= 0f)
            {
                Death();
            }
        }
    }
    [SerializeField] float _hP = 100f;

    void Start()
    {
        healthPoints = startHealth;
    }

    void Death()
    {
        Destroy (gameObject);
    }

}

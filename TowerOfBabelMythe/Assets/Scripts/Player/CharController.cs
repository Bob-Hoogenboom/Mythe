using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anime.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        anime.SetFloat("vertical", Input.GetAxis("Vertical"));
    }
}

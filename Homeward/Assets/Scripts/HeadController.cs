using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public Animator animator;
    float animCounter = 0f;
    float animIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("head", animIndex);

        animIndex =  Mathf.Abs( Mathf.Sin(animCounter));
        animCounter = animCounter + 0.1f;
    }
}

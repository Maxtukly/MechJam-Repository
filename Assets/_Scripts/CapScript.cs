using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapScript : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeCap()
    {
        animator.SetBool("Opened", !animator.GetBool("Opened"));
    }
     
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationState : MonoBehaviour
{
    public Animator animator;
    int isWalkingHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WalkAnimation()
    {
        animator.SetBool(isWalkingHash, true);
    }
    public void IdleAnimation()
    {
        animator.SetBool(isWalkingHash, false);
    }
}

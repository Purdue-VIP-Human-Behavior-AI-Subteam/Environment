using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class follow : MonoBehaviour
{   /* 
    Let NPC to follow player
    */
    public NavMeshAgent follower;
    public Transform player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        follower.SetDestination(player.position);
        animator.SetFloat("speed",follower.velocity.magnitude);
    }
}

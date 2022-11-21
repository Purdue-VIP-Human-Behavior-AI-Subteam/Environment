using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;

using UnityEngine.AI; //For use of Navmesh agent

public class FunctionalAdult : MonoBehaviour, IHear
{//this file attached to NPC 
    Animator animator;
    private NavMeshAgent agent = null;

  
    private float displacementFromA = 10f;//distance move from annoying sound
    public float Movespeed=1.5f;
 
  

    void Awake() 
    {    
        animator=GetComponent<Animator>(); //Set animation
    }
    

    public void RespondToSound(Sound sound)
    {   
        //react to different soundtype

        if (sound.soundType == Sound.SoundType.Interesting){
            MoveTo(sound.pos);
            
        }
        else if (sound.soundType == Sound.SoundType.Annoying) 
        {
            Vector3 dir = (sound.pos - transform.position).normalized;
            MoveTo(transform.position - (dir * displacementFromA));
        
        //else will do nothing in the case of Sounds with Default sound type
        
    }
    }
    //moving toward destination
    private void MoveTo(Vector3 pos) 
    {
        agent.SetDestination(pos);
        agent.isStopped = false;
        
        animator.SetFloat("speed",agent.speed);
    }
}

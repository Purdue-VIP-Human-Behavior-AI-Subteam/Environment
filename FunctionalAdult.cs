using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;

using UnityEngine.AI; //For use of Navmesh agent

public class FunctionalAdult : MonoBehaviour, IHear
{
    Animator animator;
    [SerializeField] private NavMeshAgent agent = null;

    [SerializeField, Tooltip("How far away, in meters, the agent will run from danger.")] 
    private float displacementFromDanger = 10f;
    public float Movespeed=1.5f;
    public float rotspeed=100f;
    private bool iswandering=false;
    private bool isrotatingleft=false;
    private bool isrotatingright=false;
    private bool iswalking=false;
    //private bool isUpdateEnable=true;

    void Awake() 
    {
        if (agent == null && !TryGetComponent(out agent))        
            Debug.LogWarning(name + " doesn't have an agent!");     
        animator=GetComponent<Animator>();   
    }
    

    public void RespondToSound(Sound sound)
    {   
        
     

        //print(sound.pos);
        /* 
        *   Put fun things here
        *   Examples:
        *   Animate the NPC, Play a sound clip ("What was that?!"), Throw some UI up, Check if the sound is more important than current task
        */
        if (sound.soundType == Sound.SoundType.Interesting){
            MoveTo(sound.pos);
            
        }
        else if (sound.soundType == Sound.SoundType.Dangerous) //Must have this case so that it doesn't run away from the default sound type
        {
            Vector3 dir = (sound.pos - transform.position).normalized;
            MoveTo(transform.position - (dir * displacementFromDanger));
        
        //else will do nothing in the case of Sounds with Default sound type
        
    }
  //isstop();
    //agent.isStopped=true;
    }
    private void MoveTo(Vector3 pos) 
    {
        agent.SetDestination(pos);
        agent.isStopped = false;
        
        animator.SetFloat("speed",agent.speed);
    }

    
    
    
    //public NavMeshAgent wanderer;
    
    

    // Update is called once per frame
    
    void Update(){

       
        
        animator.SetFloat("speed",Movespeed);
        if(iswandering==false){
            StartCoroutine(Wander());
        }
        
        if(isrotatingright==true ){
            
            transform.Rotate(transform.up*Time.deltaTime*rotspeed);
        }
        if(isrotatingleft==true){
            
            transform.Rotate(transform.up*Time.deltaTime*-rotspeed);
        }
        if(iswalking==true  ){
            
            transform.position+=transform.forward*Movespeed*Time.deltaTime;
        }
        
        
        
    
    }
    
    IEnumerator Wander(){
        int rotTime=Random.Range(1,2);
        float rotateWait=Random.Range(0f,0f);
        int rotatel=Random.Range(0,3);
        float walkwait=Random.Range(0f,0f);
        int walktime=Random.Range(1,10);
        iswandering =true;

        yield return new WaitForSeconds(walkwait);
        iswalking=true;
        yield return new WaitForSeconds(walktime);
        iswalking=false;
        yield return new WaitForSeconds(rotateWait);
        if(rotatel==1){
            isrotatingleft=true;
            yield return new WaitForSeconds(rotTime);
            isrotatingleft=false;
        }
        if(rotatel==2){
            isrotatingright=true;
            yield return new WaitForSeconds(rotTime);
            isrotatingright=false;
        }
        iswandering=false;
    }
    
}

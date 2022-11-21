using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wanderer : MonoBehaviour
/*
    These code is let AI npcs randomly walking in the environment.
*/
{   public float Movespeed=3f;
    public float rotspeed=100f;
    private bool iswandering=false;
    private bool isrotatingleft=false;
    private bool isrotatingright=false;
    private bool iswalking=false;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    animator.SetFloat("speed",Movespeed);//set animation
        if(iswandering==false){
            StartCoroutine(Wander());//AI Move
        }
        if(isrotatingright==true){
            transform.Rotate(transform.up*Time.deltaTime*rotspeed);//rotate right
        }
        if(isrotatingleft==true){
            transform.Rotate(transform.up*Time.deltaTime*-rotspeed);//rotate left
        }
        if(iswalking==true){
            transform.position+=transform.forward*Movespeed*Time.deltaTime;//walk forward
        }
    }
    IEnumerator Wander()
    {
        /*
            randomrize time lapse of each actions
        */
        int rotTime=Random.Range(1,2);
        float rotateWait=Random.Range(0f,0f);
        int rotatel=Random.Range(0,3);
        float walkwait=Random.Range(0f,0f);
        int walktime=Random.Range(1,10);
        /*
            Turning on boolean for each actions, 
            and close it after actions.
        */
        iswandering =true;
        yield return new WaitForSeconds(walkwait);
        iswalking=true;
        yield return new WaitForSeconds(walktime);
        iswalking=false;
        yield return new WaitForSeconds(rotateWait);
        if(rotatel==1)
        {
            isrotatingleft=true;
            yield return new WaitForSeconds(rotTime);
            isrotatingleft=false;
        }
        if(rotatel==2)
        {
            isrotatingright=true;
            yield return new WaitForSeconds(rotTime);
            isrotatingright=false;
        }
        iswandering=false;
    }

}

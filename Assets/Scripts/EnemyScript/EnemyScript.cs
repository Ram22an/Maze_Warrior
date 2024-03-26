using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody MyBody;
    private Animator MyAnim;
    private float Enemy_Speed = 70f;

    //this is the min distance b/w the player and enemy this lead enemy to chase the player
    private float Enemy_Watch_Treshold=400f;

    //this is how close player can come to enemy 
    private float Enemy_Attack_Treshold = 40f;

    void Awake()
    {
        Player=GameObject.FindGameObjectWithTag(MyTags.Player_tag);
        MyBody=GetComponent<Rigidbody>();
        MyAnim=GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyAI();
    }

    void EnemyAI()
    {
        Vector3 Distance=Player.transform.position-transform.position;

        //magnitude is the distance/length between two vectors it is under root(x*x+y*y+z*z)
        float magnitude=Distance.magnitude;

        // magnitude of 1 while preserving its direction
        Distance.Normalize();
        
        Vector3 Velocity=Distance*Enemy_Speed;
        if(magnitude > Enemy_Attack_Treshold && magnitude<Enemy_Watch_Treshold)
        {
            MyBody.velocity = new Vector3(Velocity.x,MyBody.velocity.y,Velocity.z);
            if (MyAnim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.Attack_Animation))
            {
                MyAnim.SetTrigger(MyTags.Stop_Trigger);
            }
            MyAnim.SetTrigger(MyTags.Run_Trigger);
            transform.LookAt(new Vector3(Player.transform.position.x,transform.position.y,Player.transform.position.z));
        }
        else if( magnitude<Enemy_Attack_Treshold)
        {
            if (MyAnim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.Run_Animation))
            {
                MyAnim.SetTrigger(MyTags.Stop_Trigger);
            }
            MyAnim.SetTrigger(MyTags.Attack_Trigger);
            transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
        }
        else
        {
            MyAnim.SetTrigger("Stop");
            if (MyAnim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.Run_Animation) || MyAnim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.Attack_Animation))
            {
                MyBody.velocity = new Vector3(0f, 0f, 0f);
                
            }
        }
    }








}//class

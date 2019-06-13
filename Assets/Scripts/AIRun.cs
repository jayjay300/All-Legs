using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRun : MonoBehaviour {
   public float low;
   public float high;
   public float speed;
    private float position;
    public Animator animator;
    Rigidbody rb;
    public bool finish=false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        low = Random.Range(0.6f, 1.5f);
        high = Random.Range(1.5f, 2.4f);

    }
	
	// Update is called once per frame
	void Update () {
        position = transform.position.x;
       // if(position > 48f){
        //    finish = true;
     //   }
        if (finish == false)
        {
            speed = Random.Range(low, high);
            rb.velocity = new Vector3(speed, 0, 0);
            animator.speed = (speed / 1.5f);
        }
        else{
            animator.speed = (1.5f);
            rb.velocity = new Vector3(5, 0, 0);

        }
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run : MonoBehaviour {
    float  x = 0f;
    Rigidbody rb;
    public Animator animator;
 
    public bool finish = false;
    private bool title = false;
    private float position;
    private Scene scene;
    public GameObject playagain;
    private Renderer par;
    void Start () {

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        scene = SceneManager.GetActiveScene();
        if (scene.name != "Title")
        {
            par = playagain.GetComponent<Renderer>();
            par.enabled = false;
        }
        if (scene.name == "Title"){
            title = true;
        }


    }
	
	// Update is called once per frame
	void Update () {
        position = transform.position.x;

       // if (position > 48f && scene.name != "Title")
     //   {
     //       finish = true;
     //   }
       
        if (finish == false)
        {
            if (scene.name != "Title")
            {
                if (Input.GetButtonDown("Jump"))
            {
                x += Random.Range(0.25f, 0.35f); 

            }
            else
            {
                if (x > 0)
                {
                    x *= 0.98f; //when not pressed
                }
            }
            rb.velocity = new Vector3(x, 0, 0);


                animator.speed = (x / 2);
            }else{
                if (position > 515f)
                {
                    SceneManager.LoadScene(1);
                }
                if (Input.GetButtonDown("Jump"))
                {
                    x += Random.Range(1f, 2f);
                }
                rb.velocity = new Vector3(x, 0, 0);
                animator.speed = (x / 5f);
            }
            //Debug.Log(x.ToString());
        }else{
            
            rb.velocity = new Vector3(5f, 0, 0);
            animator.speed = 1.5f;
           
        }


        if(finish == true && position > 75){
            //display play again

            par.enabled = true;

            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(0);

            }


        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Finish") && (finish == false))
        {
            //Debug.Log("OVER BITCH! " + collision.gameObject.tag.ToString() + " WONNNNNN");

            finish = true;
        }
    }
}

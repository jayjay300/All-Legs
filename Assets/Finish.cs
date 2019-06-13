using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool finish = false;
    public GameObject win, lose;
    private Renderer winr, loser;
    public GameObject[] people;
    AudioSource audiodata,winnerdata;
    // Use this for initialization
    void Start()
    {
        audiodata = GetComponent<AudioSource>();
        winr = win.GetComponent<Renderer>();
        loser = lose.GetComponent<Renderer>();
        winr.enabled = false;
        loser.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "AI") && (finish == false))
        {
            audiodata.Stop();
            Debug.Log("OVER BITCH! " + collision.gameObject.tag.ToString() + " WONNNNNN");
            finish = true;
            if (collision.gameObject.tag == "Player")
            {
                winr.enabled = true;

                foreach (GameObject person in people)
                {
                    if (person.name == "Player")
                    {
                        winnerdata = person.GetComponent<AudioSource>();
                        winnerdata.Play();
                        person.GetComponent<Run>().finish = true;
                    }
                    else
                    {
                        person.GetComponent<AIRun>().finish = true;
                        //display "Y'Cuda text/image
                    }

                }
                //display "congratulations image
            }
            else
            {
                loser.enabled = true;
                foreach (GameObject person in people)
                {
                    if (person.name == "Player")
                    {
                        person.GetComponent<Run>().finish = true;
                    }
                    else
                    {
                        winnerdata = person.GetComponent<AudioSource>();

                        if (winnerdata != null){
                            winnerdata.Play();
                        }
                        person.GetComponent<AIRun>().finish = true;
                        //display "Y'Cuda text/image
                    }
                }

            }
        }
    }
}

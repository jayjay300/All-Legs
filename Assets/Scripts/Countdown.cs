using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {
    int currentcountdowntime,waittime=5;
    //images
    public GameObject one, two, three, slam;
    private Renderer oner, twor, threer, slamr;
    //runners
    public GameObject[] people;
    AudioSource audiodata;
   // public GameObject chris,juan,cuda,baby;
    // Use this for initialization
    void Start () {
        audiodata = GetComponent<AudioSource>();
      oner =  one.GetComponent<Renderer>();
        twor = two.GetComponent<Renderer>();
        threer = three.GetComponent<Renderer>();
        slamr = slam.GetComponent<Renderer>();


        oner.enabled = false;
        twor.enabled = false;
        threer.enabled = false;
        slamr.enabled = false;
        foreach (GameObject person in people){
            if (person.name == "Player")
            {
                person.GetComponent<Run>().enabled = false;
            }else{
                person.GetComponent<AIRun>().enabled = false;
            }
            person.GetComponent<Animator>().enabled = false;
        }

        StartCoroutine(countdown(waittime));
	}
	

    public IEnumerator countdown(int waittime){
        currentcountdowntime = waittime;

        while (currentcountdowntime != -2)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(currentcountdowntime.ToString());
            if (currentcountdowntime == 3)
            {
                threer.enabled = true;
            }
            if (currentcountdowntime == 2)
            {
                twor.enabled = true;
            }

            if (currentcountdowntime == 1)
            {
                oner.enabled = true;
            }
            if (currentcountdowntime == 0)
            {
                slamr.enabled = true;

                foreach (GameObject person in people)
                {
                    if (person.name == "Player")
                    {
                        person.GetComponent<Run>().enabled = true;
                    }
                    else
                    {
                        person.GetComponent<AIRun>().enabled = true;
                    }
                    person.GetComponent<Animator>().enabled = true;

                    audiodata.Play();
                }
            }


            currentcountdowntime--;
        }
    }
}

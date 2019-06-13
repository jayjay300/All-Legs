using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private Vector3 temp;
    private float position;
    private bool finish = false;

    // Use this for initialization
    void Start()
    {


        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        offset.z = 0;

    }
	// Update is called once per frame
	void Update () {
        position = transform.position.x;
        if(position > 60.2f){
            finish = true;
        }
        if (finish == false)
        {
            temp = player.transform.position;
        temp.x -= offset.x;
        temp.y -= offset.y;
        temp.z = transform.position.z;

            transform.position = temp;
        }

        
	}

}

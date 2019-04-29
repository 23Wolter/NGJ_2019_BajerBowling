using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionOffLevelDone : MonoBehaviour
{
    public Transform blueSpawn;
    public Transform redSpawn;
    public Rigidbody rbBall;
    int team = 0;


    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathGround")
        {
            if (team == 1)
            {
                transform.position = blueSpawn.position;
                rbBall.velocity = new Vector3(0, 0, 0);
                Debug.Log("respawn");
                team = 0;
            }

            else if (team == 0)
            {
                transform.position = redSpawn.position;
                rbBall.velocity = new Vector3(0, 0, 0);
                Debug.Log("respawn");

                team = 1;
            }

        }
    }
}
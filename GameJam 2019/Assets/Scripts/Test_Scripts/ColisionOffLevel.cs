using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionOffLevel : MonoBehaviour
{
    public Transform blueSpawn;
    public Transform redSpawn;
    public Rigidbody rbBall;

    public Rigidbody rbBeer1;

    public Rigidbody rbBeer2;
    private int team = 0;

	public GameObject blueCam;
	public GameObject redCam;

    public GameObject beer1;
    public GameObject beer2;

    public Transform beer1Spawn;
    public Transform beer2Spawn;

    private PointSystem point; 
    public Transform dummy; 
    public Transform dummy2; 

    private randomSpawning spawning;
    private bool ballIsInMotion;  


    void Start()
    {
        ballIsInMotion = false; 
        rbBall = GetComponent<Rigidbody>();
     
        blueCam.SetActive(true);
		redCam.SetActive(false);

        point = GameObject.Find("Game_manager").GetComponent<PointSystem>(); 
        spawning = GameObject.Find("Game_manager").GetComponent<randomSpawning>(); 

        blueCam.SetActive(true);
        redCam.SetActive(false);
        rbBall.velocity = Vector3.zero;
        rbBall.angularVelocity = Vector3.zero; 

        float rand = Random.Range(-1.0f, 1.0f);    
        transform.position = new Vector3(blueSpawn.position.x, blueSpawn.position.y, blueSpawn.position.z+rand);
        transform.rotation = blueSpawn.rotation;
        transform.GetChild(0).rotation = dummy2.rotation;
        transform.GetChild(0).position = new Vector3(dummy2.position.x, dummy2.position.y, dummy2.position.z+rand);
        rand = Random.Range(-1.0f, 1.0f); 
        beer1.transform.position = new Vector3(beer1Spawn.position.x, beer1Spawn.position.y, beer1Spawn.position.z+rand); 

        // rand = Random.Range(-1.0f, 1.0f);
        // transform.position = new Vector3(redSpawn.position.x, redSpawn.position.y, redSpawn.position.z+rand);
        // transform.rotation = redSpawn.rotation;
        // transform.GetChild(0).rotation = dummy.rotation;
        // transform.GetChild(0).position = new Vector3(dummy.position.x, dummy.position.y, dummy.position.z+rand);
        rand = Random.Range(-1.0f, 1.0f); 
        beer2.transform.position = new Vector3(beer2Spawn.position.x, beer2Spawn.position.y, beer2Spawn.position.z+rand);
    }


    public void resetGame()
    {
        ballIsInMotion = false; 
        spawning.spawnBeer(); 
        float rand = 0.0f; 

        if (team == 1)
        {
            //ball
            blueCam.SetActive(true);
            redCam.SetActive(false);
            
            rand = Random.Range(-1.0f, 1.0f); 
           
            transform.position = new Vector3(blueSpawn.position.x, blueSpawn.position.y, blueSpawn.position.z+rand); 
            transform.rotation = blueSpawn.rotation;
            transform.GetChild(0).rotation = dummy2.rotation;
            transform.GetChild(0).position = new Vector3(dummy2.position.x, dummy2.position.y, dummy2.position.z+rand);  

            rbBall.velocity = Vector3.zero;
            rbBall.angularVelocity = Vector3.zero;
            //Beer
            rand = Random.Range(-1.0f, 1.0f); 
            beer1.transform.position = new Vector3(beer1Spawn.position.x, beer1Spawn.position.y, beer1Spawn.position.z+rand); 
            beer2.transform.position = beer2Spawn.position; 

            beer1.transform.rotation = beer1Spawn.rotation;
            beer2.transform.rotation = beer2Spawn.rotation;
            rbBeer1.velocity = Vector3.zero;
            rbBeer1.angularVelocity = Vector3.zero;

            rbBeer2.velocity = Vector3.zero;
            rbBeer2.angularVelocity = Vector3.zero;
            team = 0;

            point.SetBeerHitP1(); 
        }

        else if (team == 0)
        { 
            //ball
            blueCam.SetActive(false);
            redCam.SetActive(true);

            rand = Random.Range(-1.0f, 1.0f);
            transform.position = new Vector3(redSpawn.position.x, redSpawn.position.y, redSpawn.position.z+rand);
            transform.rotation = redSpawn.rotation;
            transform.GetChild(0).rotation = dummy.rotation;
            transform.GetChild(0).position = new Vector3(dummy.position.x, dummy.position.y, dummy.position.z+rand);
            rbBall.velocity = Vector3.zero;
            //rbBall.Sleep();
            rbBall.angularVelocity = Vector3.zero;

            //Beer
            rand = Random.Range(-1.0f, 1.0f); 
            beer1.transform.position = beer1Spawn.position;
            beer2.transform.position = new Vector3(beer2Spawn.position.x, beer2Spawn.position.y, beer2Spawn.position.z+rand); 

            beer1.transform.rotation = beer1Spawn.rotation;
            beer2.transform.rotation = beer2Spawn.rotation;

            rbBeer1.velocity = Vector3.zero;
            rbBeer1.angularVelocity = Vector3.zero;

            rbBeer2.velocity = Vector3.zero;
            rbBeer2.angularVelocity = Vector3.zero;
            team = 1;

            point.SetBeerHitP2(); 
        }
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathGround")
        {
            resetGame();
        }
    }*/

    public int GetTeamNumber()
    {
        return team; 
    }

    public bool GetBallInMotion() {
        return ballIsInMotion; 
    }

    public void SetBallInMotion() {
        ballIsInMotion = true; 
    }
}

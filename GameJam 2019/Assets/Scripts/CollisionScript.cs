using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    PointSystem pointSystem;

    // Start is called before the first frame update
    void Start()
    {

        pointSystem = GameObject.Find("Game_manager").GetComponent<PointSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "playerBeer1") {
           pointSystem.addPointForTeam2();

        
        }

        if (collisionInfo.collider.tag == "playerBeer2")
        {
            pointSystem.addPointForTeam1();
        }
    }
}

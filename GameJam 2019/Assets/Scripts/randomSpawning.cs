using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawning : MonoBehaviour
{
    public Transform bajer;
  
  public void Start() {
      for(int i=0; i<Random.Range(4, 6); i++) {
          Instantiate(bajer, new Vector3(Random.Range(-7, 7), 25, Random.Range(-3, 3)),Random.rotation);
      }
  }

   public void spawnBeer()
    {
        Debug.Log("SPAWN BEEEERRRRR");
        Instantiate(bajer, new Vector3(Random.Range(-7, 7), 25, Random.Range(-3, 3)),Random.rotation);
    }
}

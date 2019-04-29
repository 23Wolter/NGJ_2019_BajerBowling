using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCam2 : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - new Vector3(player.transform.position.x-16, player.transform.position.y, player.transform.position.z);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

}

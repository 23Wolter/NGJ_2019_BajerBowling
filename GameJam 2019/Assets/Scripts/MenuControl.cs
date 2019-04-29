using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void playFuction()
    {
        Debug.Log("Click Click");

        SceneManager.LoadScene("Test_Oliver", LoadSceneMode.Single);
    }
}

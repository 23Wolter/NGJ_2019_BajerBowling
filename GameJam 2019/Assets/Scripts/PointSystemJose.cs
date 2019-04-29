using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PointSystemJose : MonoBehaviour
{

    private int scoreTeam1;
    private int scoreTeam2;
    public Text scoretext;
    public GameObject ball;
    public GameObject beer1;
    public GameObject beer2;
    private bool beer1IsNotHit;
    private bool beer2IsNotHit;
    public Renderer[] team1Points;
    public Renderer[] team2Points;



    // Start is called before the first frame update
    void Start()
    {
        scoreTeam1 = 0;
        scoreTeam2 = 0;
        beer1IsNotHit = true;
        beer2IsNotHit = true;

        foreach (Renderer r in team1Points)
        {
            Color temp = r.material.color;
            temp.a = 0.2f;
            r.material.color = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkForWin();

    }

    public void addPointForTeam1()
    {
        if (beer2IsNotHit)
        {
            beer2IsNotHit = false;
            scoreTeam1 += 1;
            updateUI();
        }

    }

    public void addPointForTeam2()
    {
        if (beer1IsNotHit)
        {
            beer1IsNotHit = false;
            scoreTeam2 += 1;
            updateUI();
        }

    }

    public void updateUI()
    {
        scoretext.text = scoreTeam1.ToString() + "-" + scoreTeam2.ToString();
    }

    public void checkForWin()
    {

        if (scoreTeam1 == 1 || scoreTeam2 == 1)
        {
            WinState();

        }

    }

    public void WinState()
    {

        StartCoroutine("WaitBeforeReload");

    }

    private IEnumerator WaitBeforeReload()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PointSystem : MonoBehaviour
{

    private int scoreTeam1;
    private int scoreTeam2;
    public Text scoretext;
    public GameObject ball;
    public GameObject beer1;
    public GameObject beer2;
    private bool beer1IsNotHit;
    private bool beer2IsNotHit;
    public Renderer[] team1PointsCylinders;
    public Renderer[] team2PointsCylinders;
    public Renderer[] team1PointsCubes;
    public Renderer[] team2PointsCubes;

    private bool gameover;  
    public Text winText;  
    public GameObject clapSound; 

    // Start is called before the first frame update
    void Start()
    {
        gameover = false; 
        winText.text = ""; 

        scoreTeam1 = 0;
        scoreTeam2 = 0;
        beer1IsNotHit = true;
        beer2IsNotHit = true;

        foreach(Renderer r in team1PointsCylinders)
        {
            Color temp = r.material.color;
            temp.a = 1f;
            r.material.color = temp;
        }

        foreach (Renderer r in team2PointsCylinders)
        {
            Color temp = r.material.color;
            temp.a = 1f;
            r.material.color = temp;
        }

        foreach (Renderer r in team1PointsCubes)
        {
            Color temp = r.material.color;
            temp.a = 1f;
            r.material.color = temp;
        }

        foreach (Renderer r in team2PointsCubes)
        {
            Color temp = r.material.color;
            temp.a = 1f;
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
            colorBeerTeam1();
            scoreTeam1 += 1;
            updateUI();
        }

    }

    public void addPointForTeam2()
    {
        if (beer1IsNotHit) {
            beer1IsNotHit = false;
            colorBeerTeam2();
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

        if(scoreTeam1 == 3)
        {
            WinState("Blue Team");
        } else if(scoreTeam2 == 3) {
            WinState("Red Team"); 
        }

    }

    public void WinState(string player)
    {
        gameover = true; 
        clapSound.GetComponent<AudioSource>().Play(); 
        winText.text = player + " Won! One more time?"; 
        StartCoroutine("WaitBeforeReload");
    }

    private IEnumerator WaitBeforeReload()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("mainMenuSceneMain", LoadSceneMode.Single);
    }

    public void colorBeerTeam1()
    {
        Color tempCylinder = team1PointsCylinders[scoreTeam1].material.color;
        tempCylinder.a = 0f;
        team1PointsCylinders[scoreTeam1].material.color = tempCylinder;

        Color tempCube = team1PointsCubes[scoreTeam1].material.color;
        tempCube.a = 0f;
        team1PointsCubes[scoreTeam1].material.color = tempCube;
    }

    public void colorBeerTeam2()
    {
        Color tempCylinder = team2PointsCylinders[scoreTeam2].material.color;
        tempCylinder.a = 0f;
        team2PointsCylinders[scoreTeam2].material.color = tempCylinder;

        Color tempCube = team2PointsCubes[scoreTeam2].material.color;
        tempCube.a = 0f;
        team2PointsCubes[scoreTeam2].material.color = tempCube;

    }

    public void SetBeerHitP1() {
        beer1IsNotHit = true;
    }

    public void SetBeerHitP2() {
        beer2IsNotHit = true; 
    }

    public bool GetGameOver() {
        return gameover;  
    }
}

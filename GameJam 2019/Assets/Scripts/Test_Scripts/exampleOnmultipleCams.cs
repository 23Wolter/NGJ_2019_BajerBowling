// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class exampleOnmultipleCams : MonoBehaviour
// {
//     [SerializeField] private GameObject pausePanel;

//     void Start()
//     {
//         pausePanel.SetActive(false);
//     }
//     public void pause()
//     {
//         if (!pausePanel.activeInHierarchy)
//         {
//             PauseGame();
//             Debug.Log("pause");
//         }
//         else if (pausePanel.activeInHierarchy)
//         {
//             ContinueGame();
//             Debug.Log("contine");
//         }
//     }
//     private void PauseGame()
//     {
//         Time.timeScale = 0;
//         pausePanel.SetActive(true);
//         //Disable scripts that still work while timescale is set to 0
//     }
//     private void ContinueGame()
//     {
//         Time.timeScale = 1;
//         pausePanel.SetActive(false);
//         //enable the scripts again
//     }
// }

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameOverUI: MonoBehaviour
 {
     [SerializeField] private BallController ballController;
     private void OnEnable()
     {
         ballController.OnGameOver += GameOver;
     }

     private void OnDisable()
     {
         ballController.OnGameOver -= GameOver;
     }

     private void GameOver()
     {
         print("Game Over scene Show");
         SceneManager.LoadScene("GameOverScene");
     }
 }

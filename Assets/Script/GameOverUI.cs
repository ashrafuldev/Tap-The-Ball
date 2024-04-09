using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI: MonoBehaviour
 {
     [SerializeField] private BallController _ballController;
     private void OnEnable()
     {
         _ballController.OnGameOver += GameOver;
     }

     private void OnDisable()
     {
         _ballController.OnGameOver -= GameOver;
     }

     private void GameOver()
     {
         print("Game Over scene Show");
         SceneManager.LoadScene("GameOverScene");
     }
 }

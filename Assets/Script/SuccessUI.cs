using UnityEngine;
using UnityEngine.SceneManagement;
public class SuccessUI : MonoBehaviour
{
   public void Exit()
   {
      Application.Quit();
   }

   public void Restart()
   {
      SceneManager.LoadScene("GameScene");
   }
   public void Replay()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}

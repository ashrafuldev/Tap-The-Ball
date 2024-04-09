using UnityEngine;
using UnityEngine.SceneManagement;
public class UpdateUI : MonoBehaviour
{
   public void Exit()
   {
      Application.Quit();
   }

   public void Restart()
   {
      SceneManager.LoadScene("GameScene");
   }
 
}

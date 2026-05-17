using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
   public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Home()
    {
        SceneManager.LoadScene("HOME_PAGE");
    }
}

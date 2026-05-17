using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenucontroller : MonoBehaviour
{
    public void Playgame()
    {
        int selectedCharecter =
         int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        

        Gamemanager.instance.Charindex = selectedCharecter;
        SceneManager.LoadScene("Gameplay");
    }
}

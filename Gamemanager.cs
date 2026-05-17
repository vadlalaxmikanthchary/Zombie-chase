using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Characters;
    public static Gamemanager instance;
    [SerializeField]
    private int _Charindex;
    public int Charindex
    {
        get{ return _Charindex;}
        set{ _Charindex = value;}
    }

    private void Awake()
    {
        if(instance == null)
        {
           instance = this;
           DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
            
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded +=  OnLevelFinisedLoading;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -=  OnLevelFinisedLoading;
    }

    void OnLevelFinisedLoading(Scene scene ,LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            Instantiate(Characters[Charindex]);
        }
    }

}

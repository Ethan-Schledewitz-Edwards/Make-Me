using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Singleton")]
    private static SceneLoader instance;
    public static SceneLoader Instance
    {
        get
        {
            if (!instance)
            {
                // Create the GameManager prefab
                instance = GameManager.CreateSingletonManager().GetComponent<SceneLoader>();
            }
            return instance;
        }
    }

    [field: Header("MicroGameIndex")]
    [field: SerializeField] public MicroGame_Index MicroGame_Index { get; private set; }





    private void Awake()
    {
        instance = this;
    }





    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }





    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}

using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Singleton")]
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (!instance)
            {
                // Create the GameManager prefab
                instance = GameManager.CreateSingletonManager().GetComponent<UIManager>();
            }
            return instance;
        }
    }

    [Header("Components")]
    [SerializeField] private Animator Animator;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private GameManager _gameManager;

    [Header("UI Elements")]
    [SerializeField] private GameObject _alpha;
    [SerializeField] private LifeIconComponent[] _lives;
    [SerializeField] private TextMeshProUGUI _contextText;
    [SerializeField] private TextMeshProUGUI _promptText;



    #region Initialization Methods
    private void Awake()
    {
        instance = this;
    }

    #endregion



    #region MakeMe Animation Trigger Methods
    public void StartMakeMeAnim(MicroGame microGame)
    {
        Animator.SetTrigger("MakeMe");
        _contextText.text = microGame.Context;
        _promptText.text = microGame.PromptName;
    }




    public void FailedMakeMeAnim(MicroGame microGame)
    {
        Animator.SetTrigger("Failed");
        _contextText.text = microGame.Context;
        _promptText.text = microGame.PromptName;
    }
    #endregion




    #region Animation Events
    public void LoadNextScene()
    {
        SceneLoader.Instance.LoadScene(_gameManager.GetCurrentMicrogame().SceneID);
    }

    public void LoseLife()
    {
        for (int i = 0; i < _lives.Length; i++)
        {
            if (i > _gameManager.ReturnLivesRemaining() - 1)
                _lives[i].LoseLife();
        }
    }

    public void TransitionFinish()
    {
        _alpha.SetActive(false);
        _gameManager.BeginMicroGame();
    }
    #endregion
}

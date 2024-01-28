using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Singleton")]
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (!instance)
            {
                // Create the GameManager prefab
                instance = CreateSingletonManager().GetComponent<GameManager>();
            }
            return instance;
        }
    }


    [Header("Components")]
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private SceneLoader _sceneLoader;


    [Header("System")]
    private MicroGame currentMicroGame;
    private int gameCounter;// The amount of games completed so far

    private int currentLives;
    private float GameSpeedMult;
    private bool countingDown;
    private float timeRemaining;




    #region Init Methods
    public static GameObject CreateSingletonManager()
    {
        var managerPrefab = Instantiate(Resources.Load<GameObject>("Managers/GameManager"));
        DontDestroyOnLoad(managerPrefab);
        return managerPrefab;
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion



    #region MicroGame Loop
    /// <summary>
    /// This method is called by the GameInitilializer, it starts the MicroGame loop.
    /// </summary>
    public void StartMicroGameLoop()
    {
        // Initialize game values
        currentLives = 3;
        GameSpeedMult = 1f;
        gameCounter = 0;

        // Start game loop
        currentMicroGame = _sceneLoader.MicroGame_Index.ReturnNextGame(gameCounter);
        _uIManager.StartMakeMeAnim(currentMicroGame);// Passes the prompt name to the UI
    }



    /// <summary>
    /// This method is used to start a micro game after the transition has finished
    /// </summary>
    public void BeginMicroGame()
    {
        countingDown = true;
        timeRemaining = currentMicroGame.TimeAllowed;
        PlayerInput.Instance.SetInputEnabled(true);
    }




    private void Update()
    {
        if (countingDown)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
                FailMicroGame();
        }
    }
    #endregion




    #region MicroGame state methods
    public MicroGame GetCurrentMicrogame()
    {
        return currentMicroGame;
    }




    /// <summary>
    /// This method should be called when a player completes a MicroGame.
    /// </summary>
    public void CompleteMicroGame()
    {
        FinishMicroGame();

        currentMicroGame = _sceneLoader.MicroGame_Index.ReturnNextGame(gameCounter);
        _uIManager.CompleteMakeMeAnim(currentMicroGame);// Passes the prompt name to the UI
    }




    /// <summary>
    /// This method should be called when a player fails a MicroGame.
    /// </summary>
    public void FailMicroGame()
    {
        FinishMicroGame();
        currentLives--;

        // Close the game if you run out of lives
        if (currentLives <= 0)
            Application.Quit();

        // Load failed Anim
        currentMicroGame = _sceneLoader.MicroGame_Index.ReturnNextGame(gameCounter);
        _uIManager.FailedMakeMeAnim(currentMicroGame);
    }




    /// <summary>
    /// Increments the MicroGame loop
    /// </summary>
    private void FinishMicroGame()
    {
        PlayerInput.Instance.SetInputEnabled(false);
        countingDown = false;

        Debug.Log("HEH?");
        gameCounter++;
    }
    #endregion



    public int ReturnLivesRemaining()
    {
        return currentLives;
    }
}

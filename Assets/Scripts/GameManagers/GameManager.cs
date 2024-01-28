using System;
using System.Collections;
using System.Collections.Generic;
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
    private int currentLives;
    private float GameSpeedMult;
    private int microGameCount;
    private bool countingDown;
    private float timeRemaining;

    public event Action OnComplete;
    public event Action OnFail;


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

        // Finish micro game subscribes to on OnComplete event
        OnComplete += FinishMicroGame;

        // Fail micro game subscribes to OnFail event
        OnFail += FailMicroGame;
    }
    #endregion

    private void Update()
    {
        if (countingDown)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
                FailMicroGame();
        }
    }



    /// <summary>
    /// This method is called by the GameInitilializer, it starts the MicroGame loop.
    /// </summary>
    public void StartMicroGames()
    {
        // Initialize game values
        currentLives = 3;
        GameSpeedMult = 1f;
        microGameCount = 0;

        // Load the first micro game
        _uIManager.StartMakeMeAnim();
    }

    public int GetCurrentMicrogame()
    {
        return microGameCount;
    }

    #region MicroGame state methods
    /// <summary>
    /// This method should be called when a player completes a micro game.
    /// </summary>
    public void FinishMicroGame()
    {
        countingDown = false;
        microGameCount++;
    }

    /// <summary>
    /// This method should be called when a player fails a micro game.
    /// </summary>
    public void FailMicroGame()
    {
        countingDown = false;
        currentLives--;
        microGameCount++;
        Debug.Log("Failed");
    }
    #endregion

    #region Scene transition methods
    /// <summary>
    /// This method is used to start a micro game after the transition has finished
    /// </summary>
    public void BeginMicroGame()
    {
        countingDown = true;
        timeRemaining = 5;
    }
    #endregion
}

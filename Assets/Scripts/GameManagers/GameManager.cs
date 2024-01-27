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

    [Header("MicroGameIndex")]

    [Header("Components")]


    [Header("System")]
    private int currentLives;
    private float GameSpeedMult;
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
        // initialize game values
        currentLives = 3;
        GameSpeedMult = 1f;

        // Load the first micro game
        string firstMicroGame = GetNextMicroGame();
        SceneLoader.Instance.LoadScene(firstMicroGame);
    }


    /// <summary>
    /// Returns the name of the next MicroGame's scene.
    /// </summary>
    /// <returns></returns>
    private string GetNextMicroGame()
    {
        string name = null;


        //ZZZ
        //This is next


        return name;
    }

    #region MicroGame state methods
    /// <summary>
    /// This method should be called when a player completes a micro game.
    /// </summary>
    public void FinishMicroGame()
    {
        countingDown = false;
    }

    /// <summary>
    /// This method should be called when a player fails a micro game.
    /// </summary>
    public void FailMicroGame()
    {
        countingDown = false;
        currentLives--;
    }
    #endregion

    #region Scene transition methods
    /// <summary>
    /// This method is used to start a micro game after the transition has finished
    /// </summary>
    public void BeginMicroGame()
    {
        countingDown = true;
    }
    #endregion
}

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
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

   // [Header("System")]


    private void Awake()
    {
        instance = this;
    }
}

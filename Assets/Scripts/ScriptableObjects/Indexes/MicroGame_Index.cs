using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MicroGameIndex", menuName = "Indexes/MicroGameIndex", order = 0)]
public class MicroGame_Index : ScriptableObject
{
    [Header("Act ID's")]
    [field: SerializeField] private List<string> microGames;

    public string ReturnNextScene(int currentMicroGame)
    {
        string name = "";

        if (currentMicroGame <= microGames.Count)
            name = microGames[currentMicroGame];


        Debug.Log(name);
        return name;
    }
}

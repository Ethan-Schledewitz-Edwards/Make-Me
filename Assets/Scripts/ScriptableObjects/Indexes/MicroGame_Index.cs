using UnityEngine;

[CreateAssetMenu(fileName = "MicroGameIndex", menuName = "Indexes/MicroGameIndex", order = 0)]
public class MicroGame_Index : ScriptableObject
{
    [Header("Act ID's")]
    [field: SerializeField] private MicroGame[] microGames;


    /// <summary>
    /// This method returns the neext micro game
    /// </summary>
    public MicroGame ReturnNextGame(int currentMicroGame)
    {
        MicroGame game = null;

        if (currentMicroGame <= microGames.Length)
            game = microGames[currentMicroGame];

        return game;
    }
}

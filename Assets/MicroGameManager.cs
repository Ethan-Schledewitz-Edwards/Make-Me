using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MicroGameManager : MonoBehaviour
{
    private MicroGame microGame;
    private int pointsRequired;
    private int currentPoints;




    public void SetMicroGame(MicroGame game)
    {
        microGame = game;
        pointsRequired = game.PointsRequired;
        currentPoints = 0;
    }



    /// <summary>
    /// This method should be used when a condition that adds towards game completion is met
    /// </summary>
    public void AddPoint()
    {
        currentPoints++;

        if (currentPoints >= pointsRequired)
            Finished();
    }




    /// <summary>
    /// If a fail condidion is implemented by the micro game other than the standard timer, utilize this method.
    /// </summary>
    public void Finished()
    {
        GameManager.Instance.CompleteMicroGame();
    }




    /// <summary>
    /// If a fail condidion is implemented by the micro game other than the standard timer, utilize this method.
    /// </summary>
    public void Fail()
    {
        GameManager.Instance.FailMicroGame();
    }
}

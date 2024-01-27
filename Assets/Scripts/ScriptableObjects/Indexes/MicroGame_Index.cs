using System.Collections.Generic;
using UnityEngine;

public enum SceneAct
{
    First,
    Second,
    Third
}

[CreateAssetMenu(fileName = "MicroGameIndex", menuName = "Indexes/MicroGameIndex", order = 0)]
public class MicroGame_Index : ScriptableObject
{
    [Header("Sequence dependent IDs")]
    [SerializeField] private string _titleSceneID;
    [SerializeField] private string _endItSceneID;

    [Header("Act ID's")]
    [SerializeField] private List<string> _firstActIDs;
    [SerializeField] private List<string> _secondActIDs;
    [SerializeField] private List<string> _thirdActIDs;

    public string GetTitleID()
    {
        return _titleSceneID;
    }

    public string GetFinalSceneID()
    {
        return _endItSceneID;
    }


    public string ReturnRandomScene(SceneAct sceneAct)
    {
        string returnedScene = null;
        int random;


        switch (sceneAct)
        {
            case SceneAct.First:

                // Get random scene from first act
                break;


            case SceneAct.Second:


                break;


            case SceneAct.Third:


                break;
        }


        return returnedScene;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroGameLoad : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _alpha;

    public void Load()
    {
        SceneLoader.Instance.LoadScene(_sceneLoader.MicroGame_Index.ReturnNextScene(_gameManager.GetCurrentMicrogame()));
    }

    public void TransitionFinish()
    {
        _alpha.SetActive(false);
        _gameManager.BeginMicroGame();
    }
}

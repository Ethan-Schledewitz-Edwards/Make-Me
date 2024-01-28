using UnityEngine;

public class MakeMeLaugh_Clown_Trigger : MonoBehaviour, ITrigger
{
    [Header("Components")]
    [SerializeField] private string id;
    public string ID => id;

    public void Trigger()
    {
        GameManager.Instance.CompleteMicroGame();
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "MicroGameData", menuName = "MicroGame/MicroGameData", order = 0)]
public class MicroGame : ScriptableObject
{
    [field: SerializeField] public string PromptName { get; private set; }
    [field: SerializeField] public string SceneID { get; private set; }
    [field: SerializeField] public int Time { get; private set; }
}

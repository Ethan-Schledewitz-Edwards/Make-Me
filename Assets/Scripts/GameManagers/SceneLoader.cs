using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [field: Header("MicroGameIndex")]
    [field: SerializeField] public MicroGame_Index MicroGame_Index { get; private set; }
}

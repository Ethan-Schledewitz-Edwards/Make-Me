using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryingClown : ITrigger
{
    public override void Trigger()
    {
        MicroGameManager.instance.AddPoint();
    }
}

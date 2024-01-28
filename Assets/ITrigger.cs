using UnityEngine;

public abstract class ITrigger : MonoBehaviour
{
   [field: SerializeField] public string ID { get; private set; }

    public abstract void Trigger();
}

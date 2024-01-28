using UnityEngine;

public interface ITrigger
{
   [field: SerializeField] public string ID { get; }

    public abstract void Trigger();
}

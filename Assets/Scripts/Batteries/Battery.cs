
using UnityEngine;

namespace Batteries
{
    public class Battery : ScriptableObject
    {
        [SerializeField] public string batteryName;
        [SerializeField] public Sprite icon;

        public virtual void Use()
        {
            Debug.Log(name + " was collected.");
        }
    }
}


using UnityEngine;

namespace Batteries
{
    [CreateAssetMenu(menuName = "Battery")]
    
    public class BatteryCollect : Battery
    {
        [SerializeField] private GameObject prefab;
        public BatteryType batType;

        public enum BatteryType {Blue, Purple, Red, Dark, Pink, Green}
    }
}

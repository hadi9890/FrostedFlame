using Batteries;
using UnityEngine;

namespace Waypoint
{
    public class WaypointActivation : MonoBehaviour
    {
        [SerializeField] GameObject wp;
        
        void Update()
        {
            activateWaypoint();
        }

        private void activateWaypoint()
        {
            if(BatteryUIControl.numberOfBatteries == 6)
            {
                wp.SetActive(true);
            }
        }
    }
}

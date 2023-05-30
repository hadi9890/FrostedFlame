using Batteries;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace changingacenes
{
    public class SceneChanger : MonoBehaviour
    {
        private static bool gotToPlane = false;
        
        void Update()
        {
            if (BatteryUIControl.numberOfBatteries == 6)
            {
                if(gotToPlane){
                    gotToPlane = false;
                    SceneManager.LoadScene("scene2");
                }
            }
        }

        // Add trigger for gotToPlane
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.gameObject.CompareTag("ShipWP"))
            {
                gotToPlane = true;
            }
        }
    }
}
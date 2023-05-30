
using Batteries;
using UnityEngine;

namespace Pickup
{
    public class RaycastingPickup : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] LayerMask pickupLayer;
        GameObject collectibleGenerator;    // Children of this object are the original collectibles
        GenerateCollectibleWithPooling collectiblePooling;
        public static bool[] tentsAccessed;
        public static bool loaded = false;
        private Camera cam;
        // private bool enteredTrigger = false;
        private void Start()
        {
            if (!loaded)
            {
                tentsAccessed = new bool[] { false, false, false, false, false, false };
            }
            cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            collectibleGenerator = GameObject.Find("CollectibleGenerator");
            collectiblePooling = collectibleGenerator.GetComponent<GenerateCollectibleWithPooling>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray r = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;

                if (Physics.Raycast(r, out hit, pickupLayer))
                {
                    float pickupRange = Vector3.Distance(player.position, hit.transform.position);

                    if (hit.transform.gameObject.layer == 9 && pickupRange <= 3)    //Pickup layer
                    {
                        Battery newBattery = hit.transform.GetComponent<BatteryObject>().bats as Battery;
                        // Destroy on collect
                        StartCoroutine(collectiblePooling.hideCollectible(hit.transform.gameObject));
                        // Debug.Log(hit.transform.name);
                        BatteryUIControl.activatePickedUpBattery(newBattery);
                        // Debug.Log(newBattery.batteryName);
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
        void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case "BatTrigger1":
                    // Make collectible battery appear when player enters trigger zone
                    if (!tentsAccessed[0])
                    {
                        collectiblePooling.createCollectible(other.transform.GetChild(0).GetComponent<Transform>().position);
                    }
                    tentsAccessed[0] = true;    // Deactivating trigger
                    break;

                case "BatTrigger2":
                    if (!tentsAccessed[1])
                    {
                        collectiblePooling.createCollectible(other.transform.GetChild(0).GetComponent<Transform>().position);
                    }
                    tentsAccessed[1] = true;    // Deactivating trigger
                    break;

                case "BatTrigger3":
                    if (!tentsAccessed[2])
                    {
                        collectiblePooling.createCollectible(other.transform.GetChild(0).GetComponent<Transform>().position);
                    }
                    tentsAccessed[2] = true;    // Deactivating trigger
                    break;

                case "BatTrigger4":
                    if (!tentsAccessed[3])
                    {
                        collectiblePooling.createCollectible(other.transform.GetChild(0).GetComponent<Transform>().position);
                    }
                    tentsAccessed[3] = true;    // Deactivating trigger
                    break;

                case "BatTrigger5":
                    if (!tentsAccessed[4])
                    {
                        collectiblePooling.createCollectible(other.transform.GetChild(0).GetComponent<Transform>().position);
                    }
                    tentsAccessed[4] = true;    // Deactivating trigger
                    break;

                case "BatTrigger6":
                    if (!tentsAccessed[5])
                    {
                        collectiblePooling.createCollectible(other.transform.GetChild(0).GetComponent<Transform>().position);
                    }
                    tentsAccessed[5] = true;    // Deactivating trigger
                    break;
                
            }
        }

    }
}

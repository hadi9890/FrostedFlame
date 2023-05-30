using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Waypoint
{
    public class WaypointScript : MonoBehaviour
    {
        [SerializeField] private Image img;
        [SerializeField] private Transform target;
        public TextMeshProUGUI meter;
        [SerializeField] private Vector3 targetOffset;

        // Update is called once per frame
        private void Update()
        {
            float minX = img.GetPixelAdjustedRect().width / 2;
            // Debug.Log(img.GetPixelAdjustedRect());
            float maxX = Screen.width - minX;
            float minY = img.GetPixelAdjustedRect().height / 2;
            float maxY = Screen.height - minX;

            Vector2 pos = Camera.main.WorldToScreenPoint(target.position + targetOffset);

            //Determine if the waypoint target is in front of behind the camera
            if (Vector3.Dot(target.position - transform.position, transform.forward) < 0)
            {
                pos.x = pos.x < (double)Screen.width / 2 ? maxX : minX;
            }
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            img.transform.position = pos;

            meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
        }
    }
}

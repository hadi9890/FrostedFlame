using UnityEditor;
using UnityEngine;

namespace EnemyCharacters.Scripts
{
    [CustomEditor(typeof(FieldOfView))]

    public class FOVEditor : Editor
    {
        private void OnSceneGUI() {
            FieldOfView fov = (FieldOfView)target;
            Handles.color = Color.white;
            Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);
            Vector3 viewAngleA = fov.directionFromAngle(-fov.viewAngle / 2, false);
            Vector3 viewAngleB = fov.directionFromAngle(fov.viewAngle / 2, false);
            Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
            Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);
            Handles.color = Color.red;

            if(fov.visiblePlayer)
            {
                Handles.DrawLine(fov.transform.position, fov.visiblePlayer.position);
            }
        }
    }
}

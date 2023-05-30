
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotX;
    private float rotY;
    [SerializeField] private Transform player;
    [SerializeField] float distanceFromPlayer = 2.0f;
    [SerializeField] private float sensitivity = 3.0f;
    private Vector3 currRot;
    private Vector3 smoothVelocity = Vector3.zero;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private Vector2 rotationXMinMax = new Vector2(-40, 40);

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotY += mouseX;
        rotX -= mouseY;

        // Clamping X rotation
        rotX = Mathf.Clamp(rotX, rotationXMinMax.x, rotationXMinMax.y);

        // Damping rotation changes
        Vector3 nextRot = new Vector3(rotX, rotY);

        // Substract forward vector of the GameObject to point its forward vector to the target
        currRot = Vector3.SmoothDamp(currRot, nextRot, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currRot;

        transform.position = player.position - transform.forward * distanceFromPlayer;
    }
}

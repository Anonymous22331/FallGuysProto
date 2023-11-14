using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float camSpeedX;
    [SerializeField] private Vector3 cameraOffset;
    private Vector3 velocity = Vector3.zero;
    void CamFollow()
    {
        transform.LookAt(player.transform.position + new Vector3(0, cameraOffset.y, 0));
        transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X") * camSpeedX);
        Vector3 cameraPosition = player.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, 0.8f);
    }

    void FixedUpdate()
    {
        CamFollow();
    }
}

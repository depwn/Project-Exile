using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    Vector3 cameraOffset;
    [SerializeField]
    Vector3 cameraAngle;
    [SerializeField]
    float zoomSpeed;
    [SerializeField]
    float zoomFactor = 5f;
    [SerializeField]
    float minZoomFactor=2f;
    [SerializeField]
    float maxZoomFactor=10f;
  
    void Update()
    {
        zoomFactor -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoomFactor = Mathf.Clamp(zoomFactor, minZoomFactor, maxZoomFactor);
       
    }
    void LateUpdate()
    {
        transform.position = target.position + cameraOffset * zoomFactor;
        transform.LookAt(target.position + cameraAngle);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Camera _camera;
    public float dampTime = 0.15f;
    public float smoothTime = 2f;
    public float zoomvalue;
    private Vector3 velocity = Vector3.zero;


    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            ZoomIn();
        }
        if (Input.GetKey(KeyCode.X))
        {
            ZoomOut();
        }
    }

    

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 point = _camera.WorldToViewportPoint(player.transform.position);
            Vector3 delta = player.transform.position - _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }

    private void ZoomOut()
    {
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, Camera.main.orthographicSize-zoomvalue, smoothTime * Time.deltaTime);
    }

    private void ZoomIn()
    {
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, Camera.main.orthographicSize + zoomvalue, smoothTime * Time.deltaTime);
    }

}

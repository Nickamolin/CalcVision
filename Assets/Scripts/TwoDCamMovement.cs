using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDCamMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private Vector3 previousPosition;

    private float camZoom = 12;
    private float dZoom = 0.80f;

    void Start()
    {
        cam.orthographicSize = camZoom;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += direction;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            camZoom *= dZoom;
            cam.orthographicSize = camZoom;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camZoom /= dZoom;
            cam.orthographicSize = camZoom;
        }
    }
}

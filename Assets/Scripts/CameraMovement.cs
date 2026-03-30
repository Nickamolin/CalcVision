using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private Vector3 previousPosition;

    private float camZoom = -25;
    private float dZoom = 2f;

    void Start()
    {
        cam.transform.position = new Vector3();
        cam.transform.Translate(new Vector3(0, 0, camZoom));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            cam.transform.position = new Vector3();

            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 270);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 270, Space.World);
            cam.transform.Translate(new Vector3(0, 0, camZoom));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetAxis ("Mouse ScrollWheel") > 0)
        {
            camZoom += dZoom;
            cam.transform.Translate(new Vector3(0, 0, dZoom));
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camZoom -= dZoom;
            cam.transform.Translate(new Vector3(0, 0, -dZoom));
        }
    }
}

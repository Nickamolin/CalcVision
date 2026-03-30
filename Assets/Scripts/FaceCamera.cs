using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVector = this.transform.position - cam.transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, cam.transform.rotation * Vector3.up);
    }
}

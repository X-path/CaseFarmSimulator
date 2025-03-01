using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotateTowardCamera : MonoBehaviour
{
    Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(camera);
        transform.Rotate(0, 180, 0);
    }
}

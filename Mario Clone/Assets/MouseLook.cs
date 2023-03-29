using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour 
{
    public enum RotationAxes 
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float SensitivityHor = 9.0f;
    public float SensitivityVert = 9.0f;

    public float maxVert = 45.0f;
    public float minVert = -45.0f;

    private float _rotationX = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update() 
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * SensitivityHor, 0);
        } else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        } else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * SensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}

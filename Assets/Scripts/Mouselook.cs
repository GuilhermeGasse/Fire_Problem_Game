using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    public float mousesensi = 100f;
    public Transform playerbody;
    float xrotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mousesensi * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mousesensi * Time.deltaTime;

        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mousex);
    }
}

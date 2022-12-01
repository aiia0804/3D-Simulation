using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCmaera : MonoBehaviour
{
    Camera cam;
    public float speed = 10.0f;
    public float rotationSpeed = 20.0f;
    void Start()
    {
        cam = this.GetComponentInChildren<Camera>();
        cam.gameObject.transform.LookAt(this.transform.position);
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float translation2 = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        this.transform.Translate(0, 0, translation);
        this.transform.Translate(translation2, 0, 0);

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        float distance = Vector3.Distance(cam.transform.position, this.transform.position);
        if (Input.GetKey(KeyCode.R) && cam.transform.position.y > 10 && distance > 5)
        {
            cam.gameObject.transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.F) && cam.transform.position.y < 30 && distance < 30)
        {
            cam.gameObject.transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        float angle = Vector3.Angle(cam.gameObject.transform.forward, Vector3.up);

        if (Input.GetKey(KeyCode.T) && angle < 175 && cam.transform.position.y < 16)
        {
            cam.gameObject.transform.Translate(Vector3.up);
            cam.gameObject.transform.LookAt(this.transform.position);
        }
        if (Input.GetKey(KeyCode.G) && angle > 95)
        {
            cam.gameObject.transform.Translate(-Vector3.up);
            cam.gameObject.transform.LookAt(this.transform.position);
        }
    }
}

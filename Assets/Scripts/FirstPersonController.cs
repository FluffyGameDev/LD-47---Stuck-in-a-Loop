using System;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed = 1.0f;
    [SerializeField]
    private float CameraMaxAngle = 89.0f;
    [SerializeField]
    private Vector2 CameraRotationSpeed = new Vector2();

    private Transform m_CameraTransform;
    private CharacterController m_CharacterController;

    void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();

        Camera camera = GetComponentInChildren<Camera>();
        if (camera != null)
        {
            m_CameraTransform = camera.transform;
        }
        else
        {
            Debug.LogError("Could not find Camera in 1st Person Controller Children.");
        }
    }

    void Update()
    {
        UpdateCamera();
        UpdateMovement();
    }

    void UpdateCamera()
    {
        float xAxis = Input.GetAxis("CameraHor");
        float yAxis = Input.GetAxis("CameraVert");

        Vector3 cameraEuler = m_CameraTransform.eulerAngles;
        while (cameraEuler.x > 2 * CameraMaxAngle)
        {
            cameraEuler.x -= 360.0f;
        }

        cameraEuler.x -= yAxis * CameraRotationSpeed.y * Time.deltaTime;
        cameraEuler.y += xAxis * CameraRotationSpeed.x * Time.deltaTime;

        cameraEuler.x = Mathf.Clamp(cameraEuler.x, -CameraMaxAngle, CameraMaxAngle);

        m_CameraTransform.eulerAngles = cameraEuler;
    }

    void UpdateMovement()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xAxis * MovementSpeed, 0.0f, yAxis * MovementSpeed);
        moveDirection = Quaternion.AngleAxis(m_CameraTransform.eulerAngles.y, Vector3.up) * moveDirection;

        //transform.position += moveDirection;
        m_CharacterController.Move(moveDirection * Time.deltaTime);
    }
}

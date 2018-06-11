using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    public Transform Player;
    public float SensitivityX = 5f;
    public float SensitivityY = 5f;
    public float Distance = 10;

    private Transform CamTransform;
    private Camera Cam;
    private float CurrentX;
    private float CurrentY;
    private const float MaxY = 60;
    private const float MinY = 5;

    void Start()
    {
        CamTransform = transform;
        Cam = Camera.main;
    }

    void Update()
    {
        CurrentX += Input.GetAxis("Mouse X") * SensitivityX * Time.deltaTime;
        CurrentY += Input.GetAxis("Mouse Y") * SensitivityY * Time.deltaTime;

        CurrentY = Mathf.Clamp(CurrentY, MinY, MaxY);
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -Distance);
        Quaternion rotation = Quaternion.Euler(CurrentY, CurrentX, 0);
        CamTransform.position = Player.position + rotation * dir;
        CamTransform.LookAt(Player.position);
    }
}

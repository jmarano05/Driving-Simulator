using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float string horizontalInput;
    private float string verticalInput;
    private float steerAngle;
    private float currentBrakeForce;
    private bool isBraking;

    [SteralizeField] private float motorForce;
    [SteralizeField] private float brakeForce;
    [SteralizeField] private float maxSteerAngle;

    [SteralizeField] private WheelCollider DriverFront;
    [SteralizeField] private WheelCollider PassFront;
    [SteralizeField] private WheelCollider DriverRear;
    [SteralizeField] private WheelCollider PassRear;

    [SteralizeField] private Transfom TDriverFront;
    [SteralizeField] private Transfom TPassFront;
    [SteralizeField] private Transfom TDriverRear;
    [SteralizeField] private Transfom TPassRear;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBraking = horizontalInput.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        DriverFront.motorTorque = verticalInput * motorForce;
        PassFront.motorTorque = verticalInput * motorForce;
        currentBrakeForce = isBraking ? brakeForce : 0f;
        if(isBraking)
        {
            ApplyBreaking();
        }
    }

    private void ApplyBreaking()
    {
        DriverFront.brakeTorque = currentBrakeForce;
        PassFront.brakeTorque = currentBrakeForce;
        DriverRear.brakeTorque = currentBrakeForce;
        PassRear.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteeringAngle * horizontalInput;
        DriverFront.steerAngle = steerAngle;
        PassFront.steerAngle = steerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(PassFront, TPassFront);
        UpdateSingleWheel(DriverFront, TDriverFront);
        UpdateSingleWheel(PassRear, TPassRear);
        UpdateSingleWheel(DriverRear, TDriverRear);
    }

    private void UpdateSingleWheel(WheelCollider col, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        col.GetWorldPose(out Pose, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }
}

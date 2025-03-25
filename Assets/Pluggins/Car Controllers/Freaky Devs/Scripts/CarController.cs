using UnityEngine;
using System;
using System.Collections.Generic;

   namespace CarContollingScripts
{ 
    public class CarController : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
        public TrailRenderer trailRenderer; // Added TrailRenderer reference
    }

    public ControlMode control;

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;
    public float maxSpeed = 40.0f; // Maximum speed in km/h
    public float reverseSpeed = 20.0f; // Maximum reverse speed in km/h

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;
    bool isBraking;
    bool isReversing;

    private Rigidbody carRb;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;

        // Initialize Trail Renderer if it exists in each wheel
        foreach (var wheel in wheels)
        {
            if (wheel.trailRenderer != null)
            {
                wheel.trailRenderer.emitting = false; // Start with emission off
                
                // Mobile-specific settings
                #if UNITY_ANDROID || UNITY_IOS
                    wheel.trailRenderer.time = 5.0f;
                    wheel.trailRenderer.startWidth = 0.1f;
                    wheel.trailRenderer.endWidth = 0.05f;
                    wheel.trailRenderer.minVertexDistance = 0.1f;
                #endif
            }
        }
    }

    void Update()
    {
        GetInputs();
        AnimateWheels();
        WheelEffects();
    }

    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    public void MoveInput(float input)
    {
        moveInput = input;
    }

    public void SteerInput(float input)
    {
        steerInput = input;
    }

    public void BrakeInput(bool input)
    {
        isBraking = input;
    }

    void GetInputs()
    {
        if (control == ControlMode.Keyboard)
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
            isBraking = Input.GetKey(KeyCode.Space);
        }
        else if (control == ControlMode.Buttons)
        {
            // Here you would set moveInput, steerInput, and isBraking based on UI button presses
            // Example: moveInput = GetMoveInputFromButtons();
            // Example: steerInput = GetSteerInputFromButtons();
            // Example: isBraking = GetBrakeInputFromButtons();
        }
    }

    void Move()
    {
        // Calculate the current speed of the car in km/h
        float speed = carRb.linearVelocity.magnitude * 3.6f; // Convert m/s to km/h

        for (int i = 0; i < wheels.Count; i++)
        {
            // Check if the car is moving forward or in reverse
            if (isReversing)
            {
                if (speed < reverseSpeed)
                {
                    wheels[i].wheelCollider.motorTorque = -moveInput * 600 * maxAcceleration * Time.deltaTime;
                }
                else
                {
                    wheels[i].wheelCollider.motorTorque = 0;
                }
            }
            else
            {
                if (speed < maxSpeed)
                {
                    wheels[i].wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
                }
                else
                {
                    wheels[i].wheelCollider.motorTorque = 0;
                }
            }
        }
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void Brake()
    {
        if (isBraking)
        {
            for (int i = 0; i < wheels.Count; i++)
            {
                wheels[i].wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }

            // If the car is almost stopped, allow reversing
            if (carRb.linearVelocity.magnitude < 0.1f)
            {
                isReversing = true;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Count; i++)
            {
                wheels[i].wheelCollider.brakeTorque = 0;
            }

            // If the car is not braking, disable reversing
            if (carRb.linearVelocity.magnitude < 0.1f)
            {
                isReversing = false;
            }
        }
    }

    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

    void WheelEffects()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.trailRenderer != null)
            {
                if (isBraking && wheel.axel == Axel.Rear && wheel.wheelCollider.isGrounded && carRb.linearVelocity.magnitude >= 10.0f)
                {
                    wheel.trailRenderer.emitting = true;
                }
                else
                {
                    wheel.trailRenderer.emitting = false;
                }
            }
        }
    }
}

}

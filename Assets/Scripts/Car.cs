using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    public Rigidbody rigid;

    public WheelCollider wheel1, wheel2, wheel3, wheel4;

    public float drivespeed = 1500f;
    public float steerspeed = 30f;
    public float brakeForce = 3000f;

    CarInputActions input;

    float moveInput;
    float steerInput;
    float brakeInput;

    void Awake()
    {
        input = new CarInputActions();
    }

    void OnEnable()
    {
        input.Car.Enable();
    }

    void OnDisable()
    {
        input.Car.Disable();
    }

    void Update()
    {
        moveInput  = input.Car.Move.ReadValue<float>();
        steerInput = input.Car.Steer.ReadValue<float>();
        brakeInput = input.Car.Brake.ReadValue<float>();
    }

    void FixedUpdate()
    {
        // Motore
        float motor = moveInput * drivespeed;

        wheel1.motorTorque = motor;
        wheel2.motorTorque = motor;
        wheel3.motorTorque = motor;
        wheel4.motorTorque = motor;

        // Sterzo (ruote anteriori)
        wheel1.steerAngle = steerspeed * steerInput;
        wheel2.steerAngle = steerspeed * steerInput;

        // Freno (tutte le ruote)
        float brake = brakeInput * brakeForce;

        wheel1.brakeTorque = brake;
        wheel2.brakeTorque = brake;
        wheel3.brakeTorque = brake;
        wheel4.brakeTorque = brake;
    }
}

using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public TextMeshProUGUI speedText;
    public Transform needleTransform;
    public float maxSpeed = 200f;
    public float minSpeedAngle = -40f;  // Starting angle
    public float maxSpeedAngle = 220f;  // Ending angle
    
    void Start()
    {
        // Set needle to starting position
        if (needleTransform != null)
        {
            needleTransform.localRotation = Quaternion.Euler(0, 0, minSpeedAngle);
        }
    }
    
    void Update()
    {
        if (carRigidbody == null) return;
        
        float speed = carRigidbody.linearVelocity.magnitude * 3.6f;
        
        if (speedText != null)
            speedText.text = Mathf.RoundToInt(speed) + " km/h";
        
        if (needleTransform != null)
        {
            float normalizedSpeed = Mathf.Clamp01(speed / maxSpeed);
            float angle = Mathf.Lerp(minSpeedAngle, maxSpeedAngle, normalizedSpeed);
            needleTransform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
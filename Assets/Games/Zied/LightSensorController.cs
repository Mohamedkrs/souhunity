using UnityEngine;
using UnityEngine.InputSystem;

public class LightSensorController : MonoBehaviour
{
    private float darknessThreshold = 0.1f;

    private void Start()
    {
        
        // Ensure that the light sensor is available
        if (LightSensor.current != null)
        {
            // Enable the light sensor
            InputSystem.EnableDevice(LightSensor.current);
        }
        else
        {
            Debug.LogWarning("Light sensor is not available on this device.");
        }
    }

    public bool isItDark()
    {
        if (LightSensor.current != null)
        {
            // Read the light level from the sensor
            float lightLevel = LightSensor.current.lightLevel.ReadValue();
            if (lightLevel < darknessThreshold)
            {
                Debug.Log("It's dark.");
                return true;
            }
            else
            {
                Debug.Log("It's not dark.");
            }
        }
        return false;
    }

    private void OnDestroy()
    {
        // Disable the light sensor when the script is destroyed or no longer needed
        if (LightSensor.current != null)
        {
            InputSystem.DisableDevice(LightSensor.current);
        }
    }
}

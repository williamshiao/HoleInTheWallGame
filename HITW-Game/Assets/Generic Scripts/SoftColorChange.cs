using UnityEngine;

public class SoftColorChange : MonoBehaviour
{
    private Light spotlight;
    [SerializeField] private float changeInterval = 0.5f; // Interval between color changes
    [SerializeField] private float rotationSpeed = 10.0f; // Speed of rotation around the Y-axis

    private Color currentColor;
    private Color targetColor;
    private float timeSinceLastChange = 0f; // Time since the last color change

    void Start()
    {
        spotlight = GetComponent<Light>();
        currentColor = spotlight.color;
        targetColor = GetRandomColor();
    }

    void Update()
    {
        // Rotate the spotlight
        Vector3 currentRotation = transform.localEulerAngles;
        float newYRotation = currentRotation.y + rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(currentRotation.x, newYRotation, currentRotation.z);

        // Lerp between colors
        timeSinceLastChange += Time.deltaTime;
        float lerpFactor = timeSinceLastChange / changeInterval;
        spotlight.color = Color.Lerp(currentColor, targetColor, lerpFactor);

        // Change target color at specified intervals
        if (timeSinceLastChange >= changeInterval)
        {
            timeSinceLastChange = 0f;
            currentColor = targetColor;
            targetColor = GetRandomColor();
        }
    }

    Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}

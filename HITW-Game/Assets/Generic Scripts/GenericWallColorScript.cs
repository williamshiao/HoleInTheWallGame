using UnityEngine;

public class GenericWallColorScript : MonoBehaviour
{
    void Start()
    {
        // Generate a random color
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Assign the random color to the material
        GetComponent<Renderer>().material.SetColor("_BaseColor", randomColor);
    }
}

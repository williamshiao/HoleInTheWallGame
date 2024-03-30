using UnityEngine;
using System.Collections;
using TMPro; // Required for TextMeshPro

public class ShapeHandler : MonoBehaviour
{
    public GameObject uiElement; // The UI element to pop up
    public float popUpDuration = 2f; // Duration for the pop-up to stay visible
    private AudioSource specificSoundSource; // AudioSource for the specific sound
    private AudioSource randomSoundSource; // AudioSource for random sounds
    public AudioClip specificSoundClip; // The specific sound clip
    public AudioClip[] randomSoundClips; // Array of random sound clips
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro text component
    private int score = 0; // The current score

    void Start()
    {
        specificSoundSource = gameObject.AddComponent<AudioSource>();
        randomSoundSource = gameObject.AddComponent<AudioSource>();
        specificSoundSource.clip = specificSoundClip;
        UpdateScoreText(); // Update the score text initially
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            specificSoundSource.Play(); // Play the specific sound
            PlayRandomSound(); // Play a random sound
            StartCoroutine(PopUpRoutine()); // Start the pop-up coroutine
            IncrementScore(); // Increment the score
        }
    }

    IEnumerator PopUpRoutine()
    {
        uiElement.SetActive(true); // Enable the UI element
        yield return new WaitForSeconds(popUpDuration); // Wait for the specified duration
        uiElement.SetActive(false); // Disable the UI element
    }

    void PlayRandomSound()
    {
        int randomIndex = Random.Range(0, randomSoundClips.Length); // Get a random index
        randomSoundSource.clip = randomSoundClips[randomIndex]; // Set the clip to a random sound
        randomSoundSource.Play(); // Play the sound
    }

    void IncrementScore()
    {
        score++; // Increment the score
        UpdateScoreText(); // Update the score text
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString("0000"); // Format the score as a four-digit number
    }
}

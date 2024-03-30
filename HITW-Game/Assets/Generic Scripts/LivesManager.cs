using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Required for coroutines

public class LivesManager : MonoBehaviour
{
    public Image[] hearts;
    public int lives = 3;
    private AudioSource randomSoundSource;
    private AudioSource specificSoundSource;
    public AudioClip[] soundClips;
    public AudioClip specificSoundClip;
    public GameObject popUpElement; // The UI element to pop up
    public float popUpDuration = 1.5f; // Duration for the pop-up to stay visible

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        randomSoundSource = audioSources[0];
        specificSoundSource = audioSources[1];
        specificSoundSource.clip = specificSoundClip;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseLife();
        }
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            hearts[lives].enabled = false;
            PlayRandomSound();
            specificSoundSource.Play();
            StartCoroutine(PopUpRoutine()); // Start the pop-up coroutine
        }
    }

    void PlayRandomSound()
    {
        int randomIndex = Random.Range(0, soundClips.Length);
        randomSoundSource.clip = soundClips[randomIndex];
        randomSoundSource.Play();
    }

    IEnumerator PopUpRoutine()
    {
        popUpElement.SetActive(true); // Enable the UI element
        yield return new WaitForSeconds(popUpDuration); // Wait for the specified duration
        popUpElement.SetActive(false); // Disable the UI element
    }
}

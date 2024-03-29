using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMerger : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("RunnerLevelEditor", LoadSceneMode.Additive);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        PlayerPrefs.SetInt("Lives", 3);  // Set initial lives to 3.
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level 1");  // Load the Level 1 scene.
    }
}

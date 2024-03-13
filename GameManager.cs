using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string loseSceneName = "YouLose";
    public float timeLimit = 60.0f;

    private float timer;
    public Text timerText;

    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimerText();  // Update the timer display.

        if (timer >= timeLimit)
        {
            LoadLoseScene();
        }
    }

    void UpdateTimerText()
    {
        float remainingTime = Mathf.Max(0, timeLimit - timer); // Ensure the timer doesn't go negative.
        timerText.text = "Time: " + remainingTime.ToString("F1");
    }

    void LoadLoseScene()
    {
        Debug.Log("Time's up. Level failed.");
        SceneManager.LoadScene(loseSceneName);
    }
}

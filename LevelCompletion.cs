using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{
    public GameObject spherePurple;
    public GameObject sphereGreen;
    public GameObject sphereBlue;
    public GameObject sphereRed;

    private bool purpleCompleted;
    private bool greenCompleted;
    private bool blueCompleted;
    private bool redCompleted;

    private float timer;
    private bool levelCompleted;

    private void Start()
    {
        timer = 0.0f;
        levelCompleted = false;
    }

    private void Update()
    {
        if (!levelCompleted)
        {
            timer += Time.deltaTime;

            if (timer >= 60.0f)
            {
                // Handle a timeout or any other logic for failure.
                Debug.Log("Time limit exceeded. Level failed.");
                // You can add code here to restart the level or perform other actions.
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!levelCompleted)
        {
            if (collision.gameObject == spherePurple)
            {
                purpleCompleted = true;
            }
            else if (collision.gameObject == sphereGreen)
            {
                greenCompleted = true;
            }
            else if (collision.gameObject == sphereBlue)
            {
                blueCompleted = true;
            }
            else if (collision.gameObject == sphereRed)
            {
                redCompleted = true;
            }

            if (purpleCompleted && greenCompleted && blueCompleted && redCompleted)
            {
                levelCompleted = true;
                Debug.Log("Level completed!");

                // Load the next scene when all conditions are met.
                SceneManager.LoadScene("NextSceneName");
            }
        }
    }
}

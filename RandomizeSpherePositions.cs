using UnityEngine;

public class RandomizeSpherePositions : MonoBehaviour
{
    public string sphereTag = "Sphere"; // Adjust the tag name for your spheres in the Unity editor.
    public string targetTag = "Player"; // Adjust the tag name of the target in the Unity editor.
    public int numberOfSpheres = 10; // Adjust the number of spheres as needed.
    public Vector3 minPositionOffset = new Vector3(-2.0f, 0.5f, -2.0f); // Adjust the minimum position offset.
    public Vector3 maxPositionOffset = new Vector3(2.0f, 0.5f, 2.0f);   // Adjust the maximum position offset.

    void Start()
    {
        GameObject[] spheres = GameObject.FindGameObjectsWithTag(sphereTag);

        if (spheres.Length == 0)
        {
            Debug.LogError("No GameObjects with the specified sphere tag found in the scene.");
            return;
        }

        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);

        if (targetObjects.Length == 0)
        {
            Debug.LogError("No GameObjects with the specified target tag found in the scene.");
            return;
        }

        foreach (GameObject sphere in spheres)
        {
            // Pick a random target object from the list.
            GameObject targetObject = targetObjects[Random.Range(0, targetObjects.Length)];

            // Calculate a random position offset within the specified range.
            Vector3 randomPositionOffset = new Vector3(
                Random.Range(minPositionOffset.x, maxPositionOffset.x),
                Random.Range(minPositionOffset.y, maxPositionOffset.y),
                Random.Range(minPositionOffset.z, maxPositionOffset.z)
            );

            // Calculate the random position relative to the chosen target.
            Vector3 randomPosition = targetObject.transform.position + randomPositionOffset;

            // Reposition the existing sphere.
            sphere.transform.position = randomPosition;
        }
    }
}
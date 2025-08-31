using UnityEngine;
using Vuforia;
using UnityEngine.InputSystem;

public class ModelPlacer : MonoBehaviour
{
    public GameObject[] models; // Assign prefabs in Inspector
    private int currentIndex = 0;
    private GameObject placedModel;

    // Called from PlaneFinder → OnInteractiveHitTest (set in Inspector)
    public void PlaceModel(HitTestResult result)
    {
        Debug.Log("HitTest Fired at: " + result.Position);

        if (placedModel != null) Destroy(placedModel);

        placedModel = Instantiate(
            models[currentIndex],
            result.Position,
            result.Rotation
        );

        Debug.Log("Model Placed: " + placedModel.name);
    }


    // Called from UI Button
    public void SetModelIndex(int index)
    {
        currentIndex = index;
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var pos = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
            Instantiate(models[currentIndex], pos, Quaternion.identity);
            Debug.Log("Manual Spawned (New Input System)");
        }
    }
}



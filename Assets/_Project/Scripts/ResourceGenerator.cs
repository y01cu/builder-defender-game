using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField] private BuildingTypeSO buildingType;
    private float timer;
    private float timerMax;

    private void Awake()
    {
        timerMax = buildingType.resourceGeneratorData.generationInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer += timerMax;
            ResourceManager.Instance.AddResourceWithAmount(buildingType.resourceGeneratorData.resourceType, 1);
        }
    }
}
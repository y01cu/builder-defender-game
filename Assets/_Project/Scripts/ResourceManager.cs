using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; set; }
    public event EventHandler OnResourceAmountChanged;

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    private void Awake()
    {
        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResetResourceAmounts();
    }

    private void ResetResourceAmounts()
    {
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));

        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0;
        }
    }

    public void AddResourceWithAmount(ResourceTypeSO resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;

        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetResourceAmount(ResourceTypeSO resourceType)
    {
        return resourceAmountDictionary[resourceType];
    }
}
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;

    public class OnActiveBuildingTypeChangedEventArgs : EventArgs
    {
        public BuildingTypeSO activeBuildingType;
    }

    [SerializeField] private BuildingTypeSO activeBuildingType;
    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (activeBuildingType != null)
            {
                Instantiate(activeBuildingType.prefab, UtilsBase.GetMouseWorldPositionOnCamera(mainCamera), Quaternion.identity);
            }
        }
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingType)
    {
        activeBuildingType = buildingType;
        OnActiveBuildingTypeChanged?.Invoke(this, new OnActiveBuildingTypeChangedEventArgs { activeBuildingType = activeBuildingType });
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
    }
}
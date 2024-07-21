using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
    [SerializeField] private BuildingTypeSO activeBuildingType;
    [SerializeField] private Camera mainCamera;

    private BuildingTypeListSO buildingTypeList;

    private void Awake()
    {
        Instance = this;
        buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
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
    }

    public BuildingTypeSO GetActiveBuildingType()
    {
        return activeBuildingType;
    }
}
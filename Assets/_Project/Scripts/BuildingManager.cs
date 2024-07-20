using System;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private BuildingTypeSO buildingType;
    [SerializeField] private Camera mainCamera;

    private BuildingTypeListSO buildingTypeList;

    private void Awake()
    {
        buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));
        buildingType = buildingTypeList.list[1];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildingType.prefab, UtilsBase.GetMouseWorldPositionOnCamera(mainCamera), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
        }
    }
}
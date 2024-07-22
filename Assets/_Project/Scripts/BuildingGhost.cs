using System;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    [SerializeField] private Camera camera;

    private GameObject spriteGameObject;

    private void Awake()
    {
        spriteGameObject = transform.Find("Sprite").gameObject;

        Hide();
    }

    private void Start()
    {
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
    }

    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e)
    {
        if (e.activeBuildingType == null)
        {
            Hide();
        }
        else
        {
            Show(e.activeBuildingType.sprite);
        }
    }

    private void Update()
    {
        transform.position = UtilsBase.GetMouseWorldPositionOnCamera(camera);
    }

    private void Show(Sprite ghostSprite)
    {
        spriteGameObject.GetComponent<SpriteRenderer>().sprite = ghostSprite;
        spriteGameObject.SetActive(true);
    }

    private void Hide()
    {
        spriteGameObject.SetActive(false);
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    [SerializeField] private Sprite cursorSprite;

    private Dictionary<BuildingTypeSO, Transform> buttonTransformDictionary;
    private Transform cursorButton;

    private void Awake()
    {
        buttonTransformDictionary = new Dictionary<BuildingTypeSO, Transform>();

        Transform buttonTemplate = transform.Find("Button Template");

        buttonTemplate.gameObject.SetActive(false);

        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>(nameof(BuildingTypeListSO));

        float offsetAmount = -130f;

        int index = 0;
        cursorButton = Instantiate(buttonTemplate, transform);
        cursorButton.gameObject.SetActive(true);
        // RectTransform arrowButtonRectTransform = cursorButton.GetComponent<RectTransform>();
        // Vector3 anchoredPositionArrow = arrowButtonRectTransform.anchoredPosition;
        // anchoredPositionArrow = new Vector2(anchoredPositionArrow.x + offsetAmount, anchoredPositionArrow.y);
        // arrowButtonRectTransform.anchoredPosition = anchoredPositionArrow;

        cursorButton.Find("Image").GetComponent<Image>().sprite = cursorSprite;
        cursorButton.Find("Image").GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        cursorButton.GetComponent<Button>().onClick.AddListener(() => { BuildingManager.Instance.SetActiveBuildingType(null); });

        index++;

        foreach (var buildingType in buildingTypeList.list)
        {
            Transform buttonTransform = Instantiate(buttonTemplate, transform);
            buttonTransform.gameObject.SetActive(true);
            RectTransform buttonRectTransform = buttonTransform.GetComponent<RectTransform>();
            Vector3 anchoredPosition = buttonRectTransform.anchoredPosition;
            anchoredPosition = new Vector2(anchoredPosition.x + offsetAmount * index, anchoredPosition.y);
            buttonRectTransform.anchoredPosition = anchoredPosition;

            buttonTransform.Find("Image").GetComponent<Image>().sprite = buildingType.sprite;
            buttonTransform.GetComponent<Button>().onClick.AddListener(() => { BuildingManager.Instance.SetActiveBuildingType(buildingType); });

            buttonTransformDictionary[buildingType] = buttonTransform;

            index++;
        }
    }

    private void Update()
    {
        UpdateActiveBuildingTypeButton();
    }

    private void UpdateActiveBuildingTypeButton()
    {
        cursorButton.Find("Selected").gameObject.SetActive(false);

        foreach (BuildingTypeSO buildingType in buttonTransformDictionary.Keys)
        {
            buttonTransformDictionary[buildingType].Find("Selected").gameObject.SetActive(false);
        }

        BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
        if (activeBuildingType == null)
        {
            cursorButton.Find("Selected").gameObject.SetActive(true);
        }
        else
        {
            buttonTransformDictionary[activeBuildingType].Find("Selected").gameObject.SetActive(true);
        }
    }
}
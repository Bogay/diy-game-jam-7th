using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class showDetailPanel : MonoBehaviour, IPointerEnterHandler
{
    CharaSelectCanvas charaSelectCanvas;

    private void Start()
    {
        charaSelectCanvas = GameObject
            .Find("CharacterSelectionCanvas")
            .GetComponent<CharaSelectCanvas>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        charaSelectCanvas.detailedDescription_Panel.SetActive(true);
    }
}

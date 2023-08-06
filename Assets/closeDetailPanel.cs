using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class closeDetailPanel : MonoBehaviour, IPointerExitHandler
{
    CharaSelectCanvas charaSelectCanvas;

    private void Start()
    {
        charaSelectCanvas = GameObject
            .Find("CharacterSelectionCanvas")
            .GetComponent<CharaSelectCanvas>();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        charaSelectCanvas.detailedDescription_Panel.SetActive(false);
    }
}

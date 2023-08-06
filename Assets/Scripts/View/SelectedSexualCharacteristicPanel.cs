using System.Collections;
using System.Collections.Generic;
using UniDi;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SelectedSexualCharacteristicPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [SerializeField]
    private int index;

    [Inject]
    private CharaBinder.CharaSelect charaSelect;

    [Inject]
    public CharaBinder.PlayerChara playerChara;

    [Inject(Id = "tooltip")]
    private GameObject tooltip;

    private CharacterSO actorData => this.charaSelect.characterSOs[this.playerChara.currentSelect];
    private SexualCharacteristicsSO selected
    {
        get
        {
            if (this.index >= this.actorData.sexualCharacteristicsSOList.Count) return null;
            return this.actorData.sexualCharacteristicsSOList[this.index];
        }
    }

    private void Start()
    {
        tooltip.GetComponentInChildren<TMP_Text>().text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.selected == null) return;

        tooltip.GetComponentInChildren<TMP_Text>().text = this.selected.viewData.Description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.selected == null) return;

        tooltip.GetComponentInChildren<TMP_Text>().text = "";
    }

    public void OnPointerMove(PointerEventData eventData) { }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniDi;
using TMPro;

public class CharaSelectCanvas : MonoBehaviour
{
    [Inject]
    public CharaBinder.CharaSelect charaSelect;

    [Inject]
    public CharaBinder.PlayerChara playerChara;

    public int _currentSelect;

    // public GameObject  name;
    public GameObject chineseName;
    public Image loveCharaSprite;

    // public GameObject  gender;
    // public GameObject  sexualOrientation;
    public GameObject sexualCharacteristics_01;
    public GameObject sexualCharacteristics_02;
    public GameObject sexualCharacteristics_03;
    public GameObject fetish;
    public GameObject Max_HP;
    public GameObject Attack;
    public GameObject detailedDescription_Panel;
    public TMP_Text skillName;
    public TMP_Text detailedDescription;

    // public GameObject  skill;
    // public GameObject  skillType;
    // public GameObject  skillDuration;
    // public GameObject  skillCooldown;
    // public GameObject  skillForUs;
    // public GameObject  skillSpecialEffectsForUs;
    // public GameObject  skillForEnemy;
    // public GameObject  skillSpecialEffectsForEnemy;
    // public GameObject  skillDirection;
    // public GameObject  skillRange;
    // public GameObject  remark;

    public GameObject UPButton;
    public GameObject DOWNButton;
    public GameObject HPPrefab;
    public GameObject ATKPrefab;

    void Start()
    {
        _currentSelect = playerChara.currentSelect;
        SetChara();
    }

    private void SetChara()
    {
        if (charaSelect == null)
            return;

        CharacterSO selected = charaSelect.characterSOs[_currentSelect];
        chineseName.GetComponent<TMP_Text>().text = selected.m_chineseName.ToString();
        GameObject[] cs = new GameObject[] {
            sexualCharacteristics_01,
            sexualCharacteristics_02,
            sexualCharacteristics_03,
        };
        for (int i = 0; i < cs.Length; i++)
        {
            try
            {
                cs[i].GetComponent<TMP_Text>().text = selected.sexualCharacteristicsList[i].ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                cs[i].GetComponent<TMP_Text>().text = "-";
            }
        }
        fetish.GetComponent<TMP_Text>().text = selected.m_fetish.ToString();
        loveCharaSprite.sprite = selected.m_sprite;
        string skillText = selected.m_skill.ToString();
        string detailText = selected.m_detailedDescriptionText.ToString();
        skillName.text = "技能: " + skillText.Replace("_", "，");
        detailedDescription.text = detailText.Replace("_", "，");

        SetHPUI();
        SetATKUI();
        playerChara.currentSelect = _currentSelect;
        // Debug.Log(_currentSelect);
        // Debug.Log(playerChara.currentSelect);
    }

    void SetHPUI()
    {
        ResetChild(Max_HP);
        int max_hp = charaSelect.characterSOs[_currentSelect].m_Max_HP;
        for (int i = 0; i < max_hp; i++)
        {
            Instantiate(HPPrefab, Max_HP.transform);
        }
    }

    void SetATKUI()
    {
        ResetChild(Attack);
        int atk = charaSelect.characterSOs[_currentSelect].m_Attack;
        for (int i = 0; i < atk; i++)
        {
            Instantiate(ATKPrefab, Attack.transform);
        }
    }

    void ResetChild(GameObject parent)
    {
        int childs = parent.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            GameObject.Destroy(parent.transform.GetChild(i).gameObject);
        }
    }

    public void currentSelect_Add()
    {
        if (_currentSelect < charaSelect.characterSOs.Count - 1)
            _currentSelect++;
        else
            _currentSelect = 0;
        // Debug.Log("_currentSelect_Add");

        SetChara();
    }

    public void currentSelect_Reduce()
    {
        if (_currentSelect > 0)
            _currentSelect--;
        else
            _currentSelect = charaSelect.characterSOs.Count - 1;
        // Debug.Log("_currentSelect_Reduce");
        SetChara();
    }
}

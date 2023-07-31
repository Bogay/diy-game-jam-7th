using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharaSelectCanvas : MonoBehaviour
{
    CharaSelect CSB;
    public int currentSelect = 0;
    // public GameObject  name;
    public GameObject  chineseName;
    public Image  loveCharaSprite;
    // public GameObject  gender;
    // public GameObject  sexualOrientation;
    public GameObject  sexualCharacteristics_01;
    public GameObject  sexualCharacteristics_02;
    public GameObject  sexualCharacteristics_03;
    public GameObject  fetish;
    public GameObject  Max_HP;
    public GameObject  Attack;
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
        SetChara();
    }

    private void SetChara()
    {
        CSB = GameObject.Find("CharaSelectObject").GetComponent<CharaSelect>();
        chineseName.GetComponent<TMP_Text>().text = CSB.chara[currentSelect].m_Data.m_chineseName.ToString();
        sexualCharacteristics_01.GetComponent<TMP_Text>().text = CSB.chara[currentSelect].m_Data.m_sexualCharacteristics_01.ToString();
        sexualCharacteristics_02.GetComponent<TMP_Text>().text = CSB.chara[currentSelect].m_Data.m_sexualCharacteristics_02.ToString();
        sexualCharacteristics_03.GetComponent<TMP_Text>().text = CSB.chara[currentSelect].m_Data.m_sexualCharacteristics_03.ToString();
        fetish.GetComponent<TMP_Text>().text = CSB.chara[currentSelect].m_Data.m_fetish.ToString();
        loveCharaSprite.sprite = CSB.chara[currentSelect].m_Data.m_sprite;

        SetHPUI();
        SetATKUI();
    }

    void SetHPUI()
    {
        ResetChild(Max_HP);
        int max_hp = CSB.chara[currentSelect].m_Data.m_Max_HP;
        for (int i = 0; i < max_hp; i++)
        {
            Instantiate(HPPrefab,Max_HP.transform);
        }
    }

    void SetATKUI()
    {
        ResetChild(Attack);
        int atk = CSB.chara[currentSelect].m_Data.m_Attack;
        for (int i = 0; i < atk; i++)
        {
            Instantiate(ATKPrefab,Attack.transform);
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
        if(currentSelect < CSB.chara.Count)
            currentSelect++;
        else
            currentSelect = 0;
        Debug.Log("currentSelect_Add");
        SetChara();
    }

    public void currentSelect_Reduce()
    {
        if(currentSelect > 0)
            currentSelect--;
        else
            currentSelect = CSB.chara.Count - 1;
        Debug.Log("currentSelect_Reduce");
        SetChara();
    }

}

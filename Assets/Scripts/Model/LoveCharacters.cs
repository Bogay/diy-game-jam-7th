using RogueSharp;
using RogueSharp.DiceNotation;
using RogueSharpTutorial.Controller;
using RogueSharpTutorial.View;
using UniDi;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RogueSharpTutorial.Model
{
    public class LoveCharacters : Monster
    {

        public LoveCharacters(Game game, CharacterSO characterSO, DiContainer container)
            : base(game, characterSO, container) { }



        // public LoveCharacters(Game game, CharacterSO characterSO)
        //     : base(game, characterSO) { }

        // {
        // [Inject]
        // public CharaBinder.CharaSelect charaSelect;
        // int listCount;
        // int randomChara;
        // CharacterSO currentChara;

        // public CharacterSO.LoveCharaName m_name;
        // public CharacterSO.LoveCharaChineseName m_chineseName;
        // public Sprite m_sprite;
        // public CharacterSO.Gender m_gender;
        // public CharacterSO.Gender m_sexualOrientation;
        // public CharacterSO.SexualCharacteristics m_sexualCharacteristics_01;
        // public CharacterSO.SexualCharacteristics m_sexualCharacteristics_02;
        // public CharacterSO.SexualCharacteristics m_sexualCharacteristics_03;
        // public CharacterSO.SexualCharacteristics m_fetish;
        // public int m_Max_HP;
        // public int m_Attack;
        // public string m_skill;
        // public bool m_skillType;
        // public float m_skillDuration;
        // public float m_skillCooldown;
        // public int m_skillForUs;
        // public CharacterSO.SkillSpecialEffects m_skillSpecialEffectsForUs;
        // public int m_skillForEnemy;
        // public CharacterSO.SkillSpecialEffects m_skillSpecialEffectsForEnemy;
        // public CharacterSO.SkillDirection m_skillDirection;
        // public int m_skillRange;
        // public string m_remark;

        // [Inject]
        // public CharaBinder.PlayerChara playerChara;

        // public void Initialize()
        // {
        //     listCount = charaSelect.characterSOs.Count;
        //     randomChara = UnityEngine.Random.Range(0, listCount);
        //     currentChara = charaSelect.characterSOs[randomChara];

        //     m_name = currentChara.m_name;
        //     m_chineseName = currentChara.m_chineseName;
        //     m_sprite = currentChara.m_sprite;
        //     m_gender = currentChara.m_gender;
        //     m_sexualOrientation = currentChara.m_sexualOrientation;
        //     m_sexualCharacteristics_01 = currentChara.m_sexualCharacteristics_01;
        //     m_sexualCharacteristics_02 = currentChara.m_sexualCharacteristics_02;
        //     m_sexualCharacteristics_03 = currentChara.m_sexualCharacteristics_03;
        //     m_fetish = currentChara.m_fetish;
        //     m_Max_HP = currentChara.m_Max_HP;
        //     m_Attack = currentChara.m_Attack;
        //     m_skill = currentChara.m_skill;
        //     m_skillType = currentChara.m_skillType;
        //     m_skillDuration = currentChara.m_skillDuration;
        //     m_skillCooldown = currentChara.m_skillCooldown;
        //     m_skillForUs = currentChara.m_skillForUs;
        //     m_skillSpecialEffectsForUs = currentChara.m_skillSpecialEffectsForUs;
        //     m_skillForEnemy = currentChara.m_skillForEnemy;
        //     m_skillSpecialEffectsForEnemy = currentChara.m_skillSpecialEffectsForEnemy;
        //     m_skillDirection = currentChara.m_skillDirection;
        //     ;
        //     m_skillRange = currentChara.m_skillRange;
        //     // string m_remark;
        // }
        // }
        // public static LoveCharacters Create(int level, Game game)
        // {
        //     int health = Dice.Roll("2D5");

        //     return new LoveCharacters(game)
        //     {
        //         Attack = Dice.Roll("1D3") + level / 3,
        //         AttackChance = Dice.Roll("25D3"),
        //         Awareness = 10,
        //         Color = Colors.KoboldColor,
        //         Defense = Dice.Roll("1D3") + level / 3,
        //         DefenseChance = Dice.Roll("10D4"),
        //         Gold = Dice.Roll("5D5"),
        //         Health = health,
        //         MaxHealth = health,
        //         Name = "Kobold",
        //         Speed = 14,
        //         Symbol = '0'
        //     };
        // }
    }
}

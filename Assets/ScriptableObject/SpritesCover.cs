using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoveCharacterData
{

    public enum Gender
    {
        male,
        female,
        none
    }

    public enum SexualCharacteristics
    {
        S,
        M,
        Beast,                  //獸
        Muscle,                 //肌肉
        Transvestite,           //偽娘
        AI,
        Death_meeting,          //死會
        Elder_brother,          //哥哥
        Sister,                 //姊姊
        Younger_sister,         //妹妹
        Idol,                   //偶像
        Marginal_seople,        //邊緣
        Reality_enrichment,     //現充
        Mouthless,              //無口
        NTR,
        Sickly,                 //病嬌
        Genius,                 //天才
        Two_dimensional,        //二次元
        Poor_breasts,           //貧乳
        Big_breasts,            //巨乳
        Effort,                 //努力
        None,                   //無
    }

    public enum SkillSpecialEffects
    {
        buckle_blood,                                                   //扣血,
        blood,                                                          //補血,
        Replenish_blood_according_to_the_number_of_people_around,       //身旁人數補血,
        Heals_half_damage,                                              //回复一半損傷,
        changing_sexual_characteristics,                                //變化性徵,
        attribute_changes,                                              //屬性改變,
        alter_another_s_personality,                                    //改變他人性徵,
        increased_experience,                                           //經驗增加,
        bounce_damage_once,                                             //反彈一次傷害,
        Immune_to_Paralysis_once,                                       //免疫一次麻痺,
        Immune_to_skills_once,                                          //免疫一次技能,
        Push_the_enemy_forward_one_square,                              //推敵前進一格
        normal_damage_increased,                                        //普通傷害增加
        The_other_party_turns_into_a_man,                               //對方性轉成男
        paralysis,                                                      //麻痺
        relieve_paralysis,                                              //解除麻痺
        paralysis_and_injury,                                           //麻痺和傷害
        harm,                                                           //傷害
        none,                                                           //無,
    }

    public enum SkillDirection
    {
        facing,             //面向
        itself,             //自身
        around,             //四周
        selfAndFacing,      //自身&面向
    }

    public enum LoveSkill
    {
        man_i_m_coming_in,                              //小夫我要進來了,
        Listen_and_let_me_see,                          //聽話讓我看看,
        Can_t_flirt,                                    //不可以色色,
        undress,                                        //脫衣,
        so_cute_must_be_a_boy,                          //這麼可愛一定是男孩子,
        Aaaaaaaaaaaaaaah,                               //阿阿阿阿阿阿阿阿阿,
        wink,                                           //wink,
        evil_smile,                                     //邪笑,
        Debug,                                          //Debug,
        what_about_liars,                               //騙子又怎樣呢,
        I_was_a_doctor_in_my_previous_life,             //我前世是醫生,
        Performance,                                    //表演,
        with_acting,                                    //配合演技,
        Annual_salary_of_100_million_passive_income,    //年薪一億，被動收入,
        guitar_hero,                                    //吉他英雄,
        group,                                          //組團,
        Sing,                                           //唱歌,
        eat_grass,                                      //吃草,
        guillotine,                                     //斷頭台,
        loving_cuisine,                                 //愛心料理,
        gaze,                                           //凝視,
        c8736,                                          //c8736,
        Confess_first_and_lose,                         //先告白就輸了,
        tease,                                          //捉弄,
        slow,                                           //遲鈍,
        shemale_boxing,                                 //人妖拳法,
        hormone_fruit,                                  //賀爾蒙果實,
        invitation_sword,                               //邀請之劍,
    }

    public enum LoveCharaName
    {
        fat_tiger,               //胖虎,
        Jacko,                   //傑哥,
        Shiba_Inu,               //柴犬,
        billy,                   //比利,
        Minato_Kasukabe,         //春日部湊,
        old_beast,               //野獸前輩,
        Nervous_adults,          // 神經大人,
        Lord_Evil_Nervous,       //邪惡神經大人,
        vedal,                   //vedal,
        Hoshino_Ai,              //星野愛,
        Aquia,                   //阿奎亞,
        Ruby,                    //露比,
        Arima_Kana,              //有馬佳奈,
        Pieron_Cool_Chicken,     //皮耶勇酷雞,
        little_loneliness,       //小孤獨,
        Hongxia,                 //虹夏,
        Kita,                    //喜多,
        Ryo_Yamada,              //山田涼,
        Brother_Cheng,           //誠哥,
        asuna,                   //亞絲娜,
        My_wife_Yuno,            //我妻由乃,
        Kirito,                  //桐人,
        Kaguya,                  //輝夜,
        silver,                  //白銀,
        Takagi,                  //高木,
        Western_slices,          //西片,
        Von_Clay,                //馮克雷,
        Eva_Cove,                //伊娃科夫,
        brave,                   //勇者,
    }

    public LoveCharaName         m_name;
    public Sprite                m_sprite;
    public Gender                m_gender;
    public Gender                m_sexualOrientation;
    public SexualCharacteristics m_sexualCharacteristics_01;
    public SexualCharacteristics m_sexualCharacteristics_02;
    public SexualCharacteristics m_sexualCharacteristics_03;
    public SexualCharacteristics m_fetish;
    public int                   m_hp;
    public int                   m_attackPower;
    public string                m_skill;
    public bool                  m_skillType;
    public float                 m_skillDuration;
    public float                 m_skillCooldown;
    public SkillSpecialEffects   m_skillForUs;
    public SkillSpecialEffects   m_skillSpecialEffectsForUs;
    public SkillSpecialEffects   m_skillForEnemy;
    public SkillSpecialEffects   m_skillSpecialEffectsForEnemy;
    public SkillDirection        m_skillDirection;
    public int                   m_skillRange;
    public string                m_remark;    
}

[CreateAssetMenu(fileName = "New Character",menuName = "SO/Create Data Asset",order = 1)]
public class SpritesCover : ScriptableObject
{
    public LoveCharacterData m_Data;
}



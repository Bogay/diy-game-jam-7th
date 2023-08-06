using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "SO/Create Data Asset", order = 1)]
public class CharacterSO : ScriptableObject
{
    public enum Gender
    {
        male,
        female,
        none
    }

    public enum SexualCharacteristics
    {
        無,
        S,
        M,
        獸,
        肌肉,
        偽娘,
        AI,
        死會,
        哥哥,
        姊姊,
        妹妹,
        偶像,
        邊緣,
        現充,
        無口,
        NTR,
        病嬌,
        天才,
        二次元,
        貧乳,
        巨乳,
        努力,
        人妻,
        //None,                   //無
        //S,                      //S
        //M,                      //M
        //Beast,                  //獸
        //Muscle,                 //肌肉
        //Transvestite,           //偽娘
        //AI,                     //AI
        //Death_meeting,          //死會
        //Elder_brother,          //哥哥
        //Sister,                 //姊姊
        //Younger_sister,         //妹妹
        //Idol,                   //偶像
        //Marginal_seople,        //邊緣
        //Reality_enrichment,     //現充
        //Mouthless,              //無口
        //NTR,                    //NTR
        //Sickly,                 //病嬌
        //Genius,                 //天才
        //Two_dimensional,        //二次元
        //Poor_breasts,           //貧乳
        //Big_breasts,            //巨乳
        //Effort,                 //努力
    }

    public enum SkillSpecialEffects
    {
        無,
        扣血,
        補血,
        身旁人數補血,
        回复一半損傷,
        變化性徵,
        屬性改變,
        改變他人性徵,
        經驗增加,
        反彈一次傷害,
        免疫一次麻痺,
        免疫一次技能,
        推敵前進一格,
        普通傷害增加,
        對方性轉成男,
        麻痺,
        解除麻痺,
        麻痺和傷害,
        傷害,
        add_1,
        // none,                                                           //無,
        // buckle_blood,                                                   //扣血,
        // add_blood,                                                      //補血,
        // Replenish_blood_according_to_the_number_of_people_around,       //身旁人數補血,
        // Heals_half_damage,                                              //回复一半損傷,
        // changing_sexual_characteristics,                                //變化性徵,
        // attribute_changes,                                              //屬性改變,
        // alter_another_s_personality,                                    //改變他人性徵,
        // increased_experience,                                           //經驗增加,
        // bounce_damage_once,                                             //反彈一次傷害,
        // Immune_to_Paralysis_once,                                       //免疫一次麻痺,
        // Immune_to_skills_once,                                          //免疫一次技能,
        // Push_the_enemy_forward_one_square,                              //推敵前進一格
        // normal_damage_increased,                                        //普通傷害增加
        // The_other_party_turns_into_a_man,                               //對方性轉成男
        // paralysis,                                                      //麻痺
        // relieve_paralysis,                                              //解除麻痺
        // paralysis_and_injury,                                           //麻痺和傷害
        // harm,                                                           //傷害
        // add_one,                                                        //+1
    }

    public enum SkillDirection
    {
        facing, //面向
        itself, //自身
        around, //四周
        selfAndFacing, //自身&面向
    }

    public enum LoveSkill
    {
        小夫我要進來了,
        聽話讓我看看,
        不可以色色,
        脫衣,
        這麼可愛一定是男孩子,
        阿阿阿阿阿阿阿阿阿,
        wink,
        邪笑,
        Debug,
        騙子又怎樣呢,
        我前世是醫生,
        showTime,
        配合演技,
        年薪一億_被動收入,
        吉他英雄,
        組團,
        唱歌,
        吃草,
        斷頭台,
        愛心料理,
        凝視,
        c8736,
        先告白就輸了,
        捉弄,
        遲鈍,
        人妖拳法,
        賀爾蒙果實,
        邀請之劍,
        曹氏宗親會集合,
        雷影_開始行動,
        //man_i_m_coming_in,                              //小夫我要進來了,
        //Listen_and_let_me_see,                          //聽話讓我看看,
        //Can_t_flirt,                                    //不可以色色,
        //undress,                                        //脫衣,
        //so_cute_must_be_a_boy,                          //這麼可愛一定是男孩子,
        //Aaaaaaaaaaaaaaah,                               //阿阿阿阿阿阿阿阿阿,
        //wink,                                           //wink,
        //evil_smile,                                     //邪笑,
        //Debug,                                          //Debug,
        //what_about_liars,                               //騙子又怎樣呢,
        //I_was_a_doctor_in_my_previous_life,             //我前世是醫生,
        //Performance,                                    //表演,
        //with_acting,                                    //配合演技,
        //Annual_salary_of_100_million_passive_income,    //年薪一億，被動收入,
        //guitar_hero,                                    //吉他英雄,
        //group,                                          //組團,
        //Sing,                                           //唱歌,
        //eat_grass,                                      //吃草,
        //guillotine,                                     //斷頭台,
        //loving_cuisine,                                 //愛心料理,
        //gaze,                                           //凝視,
        //c8736,                                          //c8736,
        //Confess_first_and_lose,                         //先告白就輸了,
        //tease,                                          //捉弄,
        //slow,                                           //遲鈍,
        //shemale_boxing,                                 //人妖拳法,
        //hormone_fruit,                                  //賀爾蒙果實,
        //invitation_sword,                               //邀請之劍,
    }

    public enum LoveCharaName
    {
        Fat_tiger, //胖虎,
        Jacko, //傑哥,
        Shiba_Inu, //柴犬,
        Billy, //比利,
        Minato_Kasukabe, //春日部湊,
        Beast_senpai, //野獸前輩,
        Neuro_sama, //神經大人,
        Evil_Neuro_sama, //邪惡神經大人,
        Vedal, //vedal,
        Hoshino_Ai, //星野愛,
        Aquia, //阿奎亞,
        Ruby, //露比,
        Arima_Kana, //有馬佳奈,
        Pieron_Cool_Chicken, //皮耶勇酷雞,
        Little_loneliness, //小孤獨,
        Nijika, //虹夏,
        Kita, //喜多,
        Ryo_Yamada, //山田涼,
        Brother_Cheng, //誠哥,
        Asuna, //亞絲娜,
        Gasai_Yuno, //我妻由乃,
        Kirito, //桐人,
        Kaguya, //輝夜,
        Silver, //白銀,
        Takagi, //高木,
        Nishikata, //西片,
        Von_Clay, //馮克雷,
        Eva_Cove, //伊娃科夫,
        Brave, //勇者,
        Cao_Cao, //曹操
        Raikage, //雷影
    }

    public enum LoveCharaChineseName
    {
        胖虎,
        傑哥,
        柴犬,
        比利,
        春日部湊,
        野獸前輩,
        神經大人,
        邪惡神經大人,
        vedal,
        星野愛,
        阿奎亞,
        露比,
        有馬佳奈,
        皮耶勇酷雞,
        小孤獨,
        虹夏,
        喜多,
        山田涼,
        誠哥,
        亞絲娜,
        我妻由乃,
        桐人,
        輝夜,
        白銀,
        高木,
        西片,
        馮克雷,
        伊娃科夫,
        勇者,
        曹操,
        雷影,
    }

    public enum DetailedDescriptionText
    {
        往指定敵方前進_造成魅力加一情傷,
        對指定敵方_造成魅力加一情傷,
        免疫敵方對己使用的一次技能,
        啟動後兩回合_被情傷加一_造成魅力加二情傷,
        兩回合內指定敵方性轉成男,
        回復所受情傷一半墨鏡,
        使四周敵方麻痺,
        解除一次麻痺,
        根據對方性癖變化自身性徵,
        回復三點墨鏡,
        自身的血量屬性變成對手的血量屬性,
        每三回合自動加一經驗,
        每有一人在身旁加一墨鏡,
        啟動後兩回合_墨鏡加二,
        自己受一情傷_對指定敵方造成麻痺和一點傷害,
        對指定敵方_造成魅力加三情傷,
        冷卻時間三回合_反彈一次傷害,
        對指定敵方造成麻痺和基本魅力情傷,
        冷卻時間三回合_免疫一次麻痺,
        對指定敵方_造成魅力加二情傷,
        兩回合內指定敵方性別變為偽娘,
        對指定敵方_造成麻痺和基本魅力情傷,
        依身旁NTR屬性人數_回復兩倍人數之墨鏡,
        對面假如為人妻_造成對方麻痺和魅力加一情傷,
    }

    public LoveCharaName m_name;
    public LoveCharaChineseName m_chineseName;
    public Sprite m_sprite;
    public Gender m_gender;
    public Gender m_sexualOrientation;
    public SexualCharacteristics m_sexualCharacteristics_01;
    public SexualCharacteristics m_sexualCharacteristics_02;
    public SexualCharacteristics m_sexualCharacteristics_03;
    public SexualCharacteristics m_fetish;
    public int m_Max_HP = 10;
    public int m_Attack = 3;
    public LoveSkill m_skill;
    public SkillData skillData;
    public DetailedDescriptionText m_detailedDescriptionText;
    public List<SexualCharacteristicsSO> sexualCharacteristicsSOList;
}

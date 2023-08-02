using UniDi;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharaBinder : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CharaSelect>().AsSingle();
        Container.Bind<PlayerChara>().AsSingle();
    }

    public class PlayerChara
    {
        public int currentSelect { get; set; }
    }

    public class CharaSelect
    {
        public List<CharacterSO> characterSOs = new List<CharacterSO>
        {
            Resources.Load<CharacterSO>("LoveCharacter/Fat_tiger"),
            Resources.Load<CharacterSO>("LoveCharacter/Jacko"),
            Resources.Load<CharacterSO>("LoveCharacter/Shiba_Inu"),
            Resources.Load<CharacterSO>("LoveCharacter/Billy"),
            Resources.Load<CharacterSO>("LoveCharacter/Minato_Kasukabe"),
            Resources.Load<CharacterSO>("LoveCharacter/Beast_senpai"),
            Resources.Load<CharacterSO>("LoveCharacter/Neuro_sama"),
            Resources.Load<CharacterSO>("LoveCharacter/Evil_Neuro_sama"),
            Resources.Load<CharacterSO>("LoveCharacter/Vedal"),
            Resources.Load<CharacterSO>("LoveCharacter/Hoshino_Ai"),
            Resources.Load<CharacterSO>("LoveCharacter/Aquia"),
            Resources.Load<CharacterSO>("LoveCharacter/Ruby"),
            Resources.Load<CharacterSO>("LoveCharacter/Arima_Kana"),
            Resources.Load<CharacterSO>("LoveCharacter/Pieron_Cool_Chicken"),
            Resources.Load<CharacterSO>("LoveCharacter/Little_loneliness"),
            Resources.Load<CharacterSO>("LoveCharacter/Nijika"),
            Resources.Load<CharacterSO>("LoveCharacter/Kita"),
            Resources.Load<CharacterSO>("LoveCharacter/Ryo_Yamada"),
            Resources.Load<CharacterSO>("LoveCharacter/Brother_Cheng"),
            Resources.Load<CharacterSO>("LoveCharacter/Asuna"),
            Resources.Load<CharacterSO>("LoveCharacter/Gasai_Yuno"),
            Resources.Load<CharacterSO>("LoveCharacter/Kirito"),
            Resources.Load<CharacterSO>("LoveCharacter/Kaguya"),
            Resources.Load<CharacterSO>("LoveCharacter/Silver"),
            Resources.Load<CharacterSO>("LoveCharacter/Takagi"),
            Resources.Load<CharacterSO>("LoveCharacter/Nishikata"),
            Resources.Load<CharacterSO>("LoveCharacter/Von_Clay"),
            Resources.Load<CharacterSO>("LoveCharacter/Eva_Cove"),
            Resources.Load<CharacterSO>("LoveCharacter/Brave"),
            Resources.Load<CharacterSO>("LoveCharacter/Cao_Cao"),
            Resources.Load<CharacterSO>("LoveCharacter/Raikage"),
        };
    }
}

using UnityEngine;
using UnityEngine.UI;
using RogueSharpTutorial.Model;
using RogueSharpTutorial.Controller;
using UniDi;
using TMPro;
using System.Collections;
using System.Collections.Generic;

namespace RogueSharpTutorial.View
{
    public class UI_Stats : MonoBehaviour
    {
        [Inject]
        public CharaBinder.CharaSelect charaSelect;

        [Inject]
        public CharaBinder.PlayerChara playerChara;

        // [SerializeField]
        // private Text nameField;

        // [SerializeField]
        // private Text healthField;

        // [SerializeField]
        // private Text attackField;

        // [SerializeField]
        // private Text defenseField;

        // [SerializeField]
        // private Text goldField;

        // [SerializeField]
        // private Text mapLevelField;

        [SerializeField]
        private TMP_Text nameField;

        [SerializeField]
        private GameObject HPField;

        [SerializeField]
        private GameObject ATKField;

        [SerializeField]
        private TMP_Text LevelField;

        [SerializeField]
        private TMP_Text ExpField;

        // [SerializeField]
        // private TMP_Text genderField;

        [SerializeField]
        private TMP_Text sexualCharacteristics_01_Field;

        [SerializeField]
        private TMP_Text sexualCharacteristics_02_Field;

        [SerializeField]
        private TMP_Text sexualCharacteristics_03_Field;

        [SerializeField]
        private TMP_Text fetishField;

        [SerializeField]
        private GameObject dialogueUI;

        [SerializeField]
        private TMP_Text skillField;

        // [SerializeField]
        // private TMP_Text skillField;

        // [SerializeField]
        // private TMP_Text skillTypeField;

        // [SerializeField]
        // private TMP_Text skillDurationField;

        // [SerializeField]
        // private TMP_Text skillCooldownField;

        // [SerializeField]
        // private TMP_Text skillForUsField;

        // [SerializeField]
        // private TMP_Text skillDirectionField;

        // [SerializeField]
        // private TMP_Text skillRangeField;

        // [SerializeField]
        // private GameObject playerUI;

        public GameObject enemyUI;

        [SerializeField]
        private TMP_Text enemy_nameField;

        [SerializeField]
        private TMP_Text enemy_HPField;

        [SerializeField]
        private TMP_Text enemy_ATKField;

        [SerializeField]
        private TMP_Text enemy_LevelField;

        // [SerializeField]
        // private TMP_Text enemy_ExpField;

        // [SerializeField]
        // private TMP_Text genderField;

        [SerializeField]
        private TMP_Text enemy_sexualCharacteristics_01_Field;

        [SerializeField]
        private TMP_Text enemy_sexualCharacteristics_02_Field;

        [SerializeField]
        private TMP_Text enemy_sexualCharacteristics_03_Field;

        [SerializeField]
        private TMP_Text enemy_fetishField;

        [SerializeField]
        private GameObject enemy_dialogueUI;

        [SerializeField]
        private TMP_Text enemy_skillField;

        [SerializeField]
        private VerticalLayoutGroup enemyGroup;

        [SerializeField]
        private GameObject statBarPrefab;

        [SerializeField]
        private Button castSkillButton;

        [SerializeField]
        private Button restButton;

        public GameObject HPPrefab;
        public GameObject CHPPrefab;
        public GameObject ATKPrefab;

        /// <summary>
        /// Update stats section of the screen for the player stats.
        /// </summary>
        /// <param name="game"></param>
        public void DrawPlayerStats(Game game)
        {
            if (game == null)
            {
                return;
            }

            //nameField.color = healthField.color = attackField.color = defenseField.color = mapLevelField.color = Colors.Text;
            //goldField.color = Colors.Gold;

            // nameField.text = "Name:    " + game.Player.Name;
            // healthField.text = "Health:   " + game.Player.Health + "/" + game.Player.MaxHealth;
            // attackField.text =
            //     "Attack:   " + game.Player.Attack + " (" + game.Player.AttackChance + "%)";
            // defenseField.text =
            //     "Defense: " + game.Player.Defense + " (" + game.Player.DefenseChance + "%)";
            // goldField.text = "Gold:      " + game.Player.Gold;
            // mapLevelField.text = "Map Level: " + game.mapLevel;
            // genderField.text = "性別";

            SetPlayerUI();

            SetHPUI(game);
        }

        public void SetPlayerUI()
        {
            nameField.text = charaSelect.characterSOs[
                playerChara.currentSelect
            ].m_chineseName.ToString();

            LevelField.text = "等級:?";

            sexualCharacteristics_01_Field.text = charaSelect.characterSOs[
                playerChara.currentSelect
            ].m_sexualCharacteristics_01.ToString();

            sexualCharacteristics_02_Field.text = charaSelect.characterSOs[
                playerChara.currentSelect
            ].m_sexualCharacteristics_02.ToString();

            sexualCharacteristics_03_Field.text = charaSelect.characterSOs[
                playerChara.currentSelect
            ].m_sexualCharacteristics_03.ToString();

            fetishField.text = charaSelect.characterSOs[
                playerChara.currentSelect
            ].m_fetish.ToString();
        }

        public void ShowPlayerDialogue()
        {
            StartCoroutine(ShowAndWait(dialogueUI, 2.5f));
        }

        public void SetEnemyUI(CharacterSO enemy)
        {
            enemy_nameField.text = enemy.m_chineseName.ToString();

            enemy_HPField.text = enemy.m_Max_HP.ToString();

            enemy_ATKField.text = enemy.m_Attack.ToString();

            enemy_sexualCharacteristics_01_Field.text = enemy.m_sexualCharacteristics_01.ToString();

            enemy_sexualCharacteristics_02_Field.text = enemy.m_sexualCharacteristics_02.ToString();

            enemy_sexualCharacteristics_03_Field.text = enemy.m_sexualCharacteristics_03.ToString();

            enemy_fetishField.text = enemy.m_fetish.ToString();

            enemy_skillField.text = enemy.m_skill.ToString();
        }

        public void ShowEnemyDialogue()
        {
            StartCoroutine(ShowAndWait(enemy_dialogueUI, 2.5f));
        }

        IEnumerator ShowAndWait(GameObject dialogue, float waitTime)
        {
            dialogue.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            dialogue.SetActive(false);
        }

        /// <summary>
        /// Update the Monsters section of stats screen dynamically based on the number of Monsters in the Player's FOV.
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="position"></param>
        public void DrawMonsterStats(Monster monster, int position)
        {
            if (position == 0)
            {
                ClearMonsterStats();
            }

            GameObject obj = Instantiate(statBarPrefab);
            obj.transform.SetParent(enemyGroup.transform, false);

            StatBar bar = obj.GetComponent<StatBar>();

            bar.SetSlider(
                monster.Health,
                monster.MaxHealth,
                monster.Name,
                ColorMap.UnityColors[monster.Color],
                monster.Symbol
            );
        }

        /// <summary>
        /// Clear all Monsters from the stats section of the screen. Necessary when there was one monster in the Player's FOV and then none were.
        /// </summary>
        public void ClearMonsterStats()
        {
            foreach (Transform child in enemyGroup.transform)
            {
                Destroy(child.gameObject);
            }
        }

        void SetHPUI(Game game)
        {
            ResetChild(HPField);
            for (int i = 0; i < game.Player.Health; i++)
            {
                Instantiate(HPPrefab, HPField.transform);
            }
            for (int i = 0; i < game.Player.MaxHealth - game.Player.Health; i++)
            {
                Instantiate(CHPPrefab, HPField.transform);
            }
        }

        void SetATKUI(Game game)
        {
            ResetChild(ATKField);
            int atk = charaSelect.characterSOs[playerChara.currentSelect].m_Attack;
            for (int i = 0; i < atk; i++)
            {
                Instantiate(ATKPrefab, ATKField.transform);
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

        public void BindInputKeyboard(InputKeyboard inputKeyboard)
        {
            this.castSkillButton.onClick.AddListener(inputKeyboard.PrepareSkill);
            this.restButton.onClick.AddListener(inputKeyboard.Rest);
        }
    }
}

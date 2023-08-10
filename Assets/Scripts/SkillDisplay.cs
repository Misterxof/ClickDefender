using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Possibilities
{
    public class SkillDisplay : MonoBehaviour
    {
        public Skills Skill;

        public TextMeshProUGUI SkillName;
        public TextMeshProUGUI SkillDescription;
        public Image SkillIcon;
        public TextMeshProUGUI SkillAttribute;
        public TextMeshProUGUI SkillAttributeAmount;
        public TextMeshProUGUI SkillPointsNeeded;

        [SerializeField]
        private PlayerStats _playerHandler;

        // Start is called before the first frame update
        void Start()
        {
            _playerHandler = GameObject.Find("Player").GetComponent<PlayerStats>();
            _playerHandler.onExperienceChange += ReactToChange;
            _playerHandler.onLevelChange += ReactToChange;

            if (Skill)
            {
                Skill.SetValues(this.gameObject, _playerHandler);
            }

            EnableSkills();
        }

        public void EnableSkills()
        {
            //  if player have the skill then show it as enabled
            if (_playerHandler && Skill && Skill.EnableSkill(_playerHandler))
            {
                TurnOnSkillIcon();
            }
            else if (_playerHandler && Skill && Skill.CheckSkill(_playerHandler))
            {
                this.GetComponent<Button>().interactable = true;
                this.transform.Find("Icon").Find("Disabled").gameObject.SetActive(false);
            }
            else
            {
                TurnOffSkillIcon();
            }
        }

        private void OnEnabled()
        {
            EnableSkills();
        }

        private void OnDisable()
        {
            _playerHandler.onExperienceChange -= ReactToChange;
        }

        public void GetSkill()
        {
            if (Skill.GetSkill(_playerHandler))
            {
                TurnOnSkillIcon();
            }
        }

        private void TurnOnSkillIcon()
        {
            this.GetComponent<Button>().interactable = false;
            this.transform.Find("Icon").Find("Available").gameObject.SetActive(false);
            this.transform.Find("Icon").Find("Disabled").gameObject.SetActive(false);
        }

        private void TurnOffSkillIcon()
        {
            this.GetComponent<Button>().interactable = false;
            this.transform.Find("Icon").Find("Available").gameObject.SetActive(true);
            this.transform.Find("Icon").Find("Disabled").gameObject.SetActive(true);
        }

        void ReactToChange()
        {
            EnableSkills();
        }
    }

}
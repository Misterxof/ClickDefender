using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Possibilities
{
    public class SkillDisplay : MonoBehaviour
    {
        public Skills skill;

        public TextMeshProUGUI skillName;
        public TextMeshProUGUI skillDescription;
        public Image skillIcon;
        public TextMeshProUGUI skillAttribute;
        public TextMeshProUGUI skillAttributeAmount;
        public TextMeshProUGUI skillPointsNeeded;

        [SerializeField]
        private  PlayerStats m_playerHandler;

        // Start is called before the first frame update
        void Start()
        {
            m_playerHandler = GameObject.Find("Player").GetComponent<PlayerStats>();
            m_playerHandler.onExperienceChange += ReactToChange;
            m_playerHandler.onLevelChange += ReactToChange;

            if (skill)
            {
                skill.SetValues(this.gameObject, m_playerHandler);
            }

            EnableSkills();
        }

        public void EnableSkills()
        {
            //  if player have the skill then show it as enabled
            if(m_playerHandler && skill && skill.EnableSkill(m_playerHandler))
            {
                TurnOnSkillIcon();
            }
            else if (m_playerHandler && skill && skill.CheckSkill(m_playerHandler))
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
            m_playerHandler.onExperienceChange -= ReactToChange;
        }

        public void GetSkill()
        {
            if (skill.GetSkill(m_playerHandler))
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
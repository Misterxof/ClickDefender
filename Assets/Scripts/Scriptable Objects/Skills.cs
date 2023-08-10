using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Possibilities
{
    [CreateAssetMenu(menuName = "Generator/Player/Create Skill")]
    public class Skills : ScriptableObject
    {
        public string Name;
        public string Descriptiton;
        public Sprite Icon;
        public int KnowledgePointsNeeded;
        public int CurrentLevel;
        public bool isEvolutionary;
        public List<PlayerAttributes> AffectetedAttributes = new List<PlayerAttributes>();

        public void OnRequirements() { }

        public void OnPowers() { }

        //  public method to set the values in the Tier UI
        public void SetValues(GameObject SkillDisplayObject, PlayerStats player)
        {
            if (SkillDisplayObject)
            {
                SkillDisplay skillDisplay = SkillDisplayObject.GetComponent<SkillDisplay>();
                skillDisplay.SkillName.text = Name;

                if (skillDisplay.SkillDescription)
                    skillDisplay.SkillDescription.text = Descriptiton;

                if (skillDisplay.SkillIcon)
                    skillDisplay.SkillIcon.sprite = Icon;

                if (skillDisplay.SkillPointsNeeded)
                    skillDisplay.SkillPointsNeeded.text = KnowledgePointsNeeded.ToString();

                if (skillDisplay.SkillAttribute)
                    skillDisplay.SkillAttribute.text = AffectetedAttributes[0].Attribute.ToString();

                if (skillDisplay.SkillAttributeAmount)
                    skillDisplay.SkillAttributeAmount.text = "+" + AffectetedAttributes[0].Amount.ToString();

            }
        }

        //  check if the player is able to get the skill
        public bool CheckSkill(PlayerStats player)
        {
            if (player.PlayerKnowledgePoints < KnowledgePointsNeeded)
                return false;

            return true;
        }

        //  check if fthe player already has the skill
        public bool EnableSkill(PlayerStats player)
        {
            List<Skills>.Enumerator skills = player.PlayerSkills.GetEnumerator();
            while (skills.MoveNext())
            {
                var currSkill = skills.Current;
                if (string.Equals(currSkill.Name, this.Name))
                {
                    return true;
                }
            }

            return false;
        }

        //  get new skill
        public bool GetSkill(PlayerStats player)
        {
            int i = 0;

            // List through the skill's attributets
            List<PlayerAttributes>.Enumerator attributes = AffectetedAttributes.GetEnumerator();
            while(attributes.MoveNext())
            {
                //  List through the player attributes and match with skill attributes
                List<PlayerAttributes>.Enumerator playerAttributes = player.Attributes.GetEnumerator();
                while (playerAttributes.MoveNext())
                {
                    if(string.Equals(attributes.Current.Attribute.name, playerAttributes.Current.Attribute.name))
                    {
                        playerAttributes.Current.Amount += attributes.Current.Amount;
                        i++;
                    }
                }

                if (i > 0)
                {
                    player.PlayerKnowledgePoints -= this.KnowledgePointsNeeded;
                    player.PlayerSkills.Add(this);
                    return true;
                }
            }
            return false;
        }
    }
}

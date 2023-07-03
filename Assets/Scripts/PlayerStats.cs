using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Possibilities
{
    public class PlayerStats : MonoBehaviour
    {
        private float maxHealthPoints = 100f;
        private float maxExperiencePoints = 100f;   // for new level

        [Header("Player Stats")]
        
        [SerializeField]
        private float healthPoints = 100f;
        [SerializeField]
        private float m_PlayerExperience = 0;
        [SerializeField]
        private int m_Level = 1;
        [SerializeField]
        private int knowledgePoints = 1;

        [Header("Attributes")]
        public List<PlayerAttributes> Attributes = new List<PlayerAttributes>();

        [Header("Skills")]
        public List<Skills> PlayerSkills = new List<Skills>();

        public float PlayerMaxHealthPoints
        {
            set { maxHealthPoints = value; }
            get { return maxHealthPoints; }
        }

        public float PlayerMaxExperiencePoints
        {
            set { maxExperiencePoints = value; }
            get { return maxExperiencePoints; }  
        }

        public float PlayerHealthPoints
        {
            get { return healthPoints; }
            set { healthPoints = value; }
        }

        public float PlayerExperiencePoints
        {
            get { return m_PlayerExperience; }
            set {
                m_PlayerExperience = value;

                if (onExperienceChange != null)
                    onExperienceChange();
            }
        }

        public int PlayerLevel
        {
            get { return m_Level; }
            set
            {
                m_Level = value;

                //  for subscribers
                if (onLevelChange != null)
                    onLevelChange();
            }
        }

        public int PlayerKnowledgePoints
        {
            get { return knowledgePoints; }
            set { knowledgePoints = value; }
        }

        // Start is called before the first frame update
        void Start()
        {
            maxExperiencePoints = healthPoints;
        }

        // Update is called once per frame
        void Update()
        {

        }

        //  Delegates for listeners
        public delegate void OnExperienceChange();
        public event OnExperienceChange onExperienceChange;

        public delegate void OnLevelChange();
        public event OnLevelChange onLevelChange;

        // test
        public void UpdateLevel(int amount)
        {
            PlayerLevel += amount;
        }

        public void UpdateKP(int amount)
        {
            PlayerKnowledgePoints += amount;
        }
    }
}

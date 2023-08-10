using System.Collections.Generic;
using UnityEngine;


namespace Possibilities
{
    public class PlayerStats : MonoBehaviour
    {
        private float _maxHealthPoints = 100f;
        private float _maxExperiencePoints = 100f;   // for new level
        private float _levelsBeforeScaleCounter = 0;

        [Header("Player Stats")]

        [SerializeField]
        private float _healthPoints = 100f;
        [SerializeField]
        private float _playerExperience = 0;
        [SerializeField]
        private int _level = 0;
        [SerializeField]
        private int _knowledgePoints = 1;
        [SerializeField]
        private float _damage = 1f;

        [Header("Attributes")]
        public List<PlayerAttributes> Attributes = new List<PlayerAttributes>();

        [Header("Skills")]
        public List<Skills> PlayerSkills = new List<Skills>();

        public float PlayerMaxHealthPoints
        {
            set { _maxHealthPoints = value; }
            get { return _maxHealthPoints; }
        }

        public float PlayerMaxExperiencePoints
        {
            set { _maxExperiencePoints = value; }
            get { return _maxExperiencePoints; }
        }

        public float LevelsBeforeScaleCounter
        {
            get { return _levelsBeforeScaleCounter; }
            set { _levelsBeforeScaleCounter = value; }
        }

        public float PlayerHealthPoints
        {
            get { return _healthPoints; }
            set { _healthPoints = value; }
        }

        public float PlayerExperiencePoints
        {
            get { return _playerExperience; }
            set
            {
                _playerExperience = value;

                if (onExperienceChange != null)
                    onExperienceChange();
            }
        }

        public int PlayerLevel
        {
            get { return _level; }
            set
            {
                _level = value;

                //  for subscribers
                if (onLevelChange != null)
                    onLevelChange();
            }
        }

        public int PlayerKnowledgePoints
        {
            get { return _knowledgePoints; }
            set { _knowledgePoints = value; }
        }

        public float PlayerDamage
        {
            get { return _damage; }
            set { _damage = value; }
        }

        // Start is called before the first frame update
        void Start()
        {
            _maxExperiencePoints = _healthPoints;
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

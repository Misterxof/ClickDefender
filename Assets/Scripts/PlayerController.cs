using Possibilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    Rigidbody2D Rigidbody;
    [SerializeField] FixedJoystick Joystick;
    private HealthBar _healthBar;
    private ExperienceBar _experienceBar;
    public PlayerStats PlayerStats;

    // Callbacks
    private GameCallbacks _gameCallbacks;

    // Player
    public ObjectType Type = ObjectType.Player;
    public float _walkSpeed = 2f;
    public float _speedLimiter = 0.7f;
    private float _inputHorizontal;
    private float _inputVertitcal;

    // Start is called before the first frame update 
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        PlayerStats = GetComponent<PlayerStats>();
        _healthBar = new HealthBar(PlayerStats.PlayerHealthPoints, PlayerStats.PlayerMaxHealthPoints);
        _experienceBar = new ExperienceBar(PlayerStats.PlayerExperiencePoints, PlayerStats.PlayerMaxExperiencePoints);
    }

    // Update is called once per frame
    void Update()
    {
        _inputHorizontal = Joystick.Horizontal;
        _inputVertitcal = Joystick.Vertical;

        if (PlayerStats.PlayerHealthPoints <= 0)
        {
            //Debug.Log("DEAD");
            _gameCallbacks.OnGameOver();
        }
    }

    private void FixedUpdate()
    {
        if (_inputHorizontal != 0 || _inputVertitcal != 0)
        {
            if (_inputHorizontal != 0 && _inputVertitcal != 0)
            {
                _inputHorizontal *= _speedLimiter;
                _inputVertitcal *= _speedLimiter;
            }

            Rigidbody.velocity = new Vector2(_inputHorizontal * _walkSpeed, _inputVertitcal * _walkSpeed);
        }
        else
        {
            Rigidbody.velocity = Vector2.zero;
        }
    }

    public void OnHealthDamage(float damage)
    {
        PlayerStats.PlayerHealthPoints -= damage;
        _healthBar.OnHealthtChange(PlayerStats.PlayerHealthPoints, PlayerStats.PlayerMaxHealthPoints);
    }

    /** Level system
     * 1 level - 150 xp
     * N level - same maxLevelMultiplier (250) for 3 levels
     * after 3 repits maxLevelMultiplier + 250
     */
    public void OnExperienceChange(float experience)
    {
        PlayerStats.PlayerExperiencePoints += experience;
        _experienceBar.OnExperienceChange(PlayerStats.PlayerExperiencePoints, PlayerStats.PlayerMaxExperiencePoints);

        if (PlayerStats.PlayerExperiencePoints >= PlayerStats.PlayerMaxExperiencePoints)
        {
            switch (PlayerStats.PlayerLevel)
            {
                case 0:
                    PlayerStats.PlayerLevel = 1;
                    PlayerStats.PlayerExperiencePoints = 0;
                    PlayerStats.PlayerMaxExperiencePoints = 250;
                    PlayerStats.LevelsBeforeScaleCounter = 2;
                    _experienceBar.OnExperienceChange(PlayerStats.PlayerMaxExperiencePoints, PlayerStats.PlayerMaxExperiencePoints);
                    break;
                default:
                    PlayerStats.PlayerLevel++;
                    PlayerStats.PlayerExperiencePoints = 0;

                    if (PlayerStats.LevelsBeforeScaleCounter != 0)
                    {
                        PlayerStats.LevelsBeforeScaleCounter--;
                    }
                    else
                    {
                        PlayerStats.LevelsBeforeScaleCounter = 2;
                        PlayerStats.PlayerMaxExperiencePoints += 250;
                    }
                    _experienceBar.OnExperienceChange(PlayerStats.PlayerMaxExperiencePoints, PlayerStats.PlayerMaxExperiencePoints);
                    break;
            }
        }
    }

    public void setGameCallbacks(GameCallbacks gameCallbacks)
    {
        this._gameCallbacks = gameCallbacks;
    }

    //
    // Getters & setters
    public float getPlayerDamage()
    {
        return PlayerStats.PlayerDamage;
    }
}

using Possibilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    Rigidbody2D _rigidbody;
    [SerializeField] FixedJoystick _joystick;
    private HealthBar healthBar;
    private ExperienceBar experienceBar;
    public PlayerStats playerStats;

    // Callbacks
    private GameCallbacks gameCallbacks;

    // Player
    public ObjectType type = ObjectType.Player;
    public float walkSpeed = 2f;
    public float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertitcal;

    // Start is called before the first frame update 
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
        healthBar = new HealthBar(playerStats.PlayerHealthPoints, playerStats.PlayerMaxHealthPoints);
        experienceBar = new ExperienceBar(playerStats.PlayerExperiencePoints, playerStats.PlayerMaxExperiencePoints);
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = _joystick.Horizontal;
        inputVertitcal = _joystick.Vertical;

        if (playerStats.PlayerHealthPoints <= 0)
        {
            //Debug.Log("DEAD");
            gameCallbacks.OnGameOver();
        }
    }

    private void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertitcal != 0)
        {
            if (inputHorizontal != 0 && inputVertitcal != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertitcal *= speedLimiter;
            }

            _rigidbody.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertitcal * walkSpeed);
        } else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    public void OnHealthDamage(float damage)
    {
        playerStats.PlayerHealthPoints -= damage;
        healthBar.OnHealthtChange(playerStats.PlayerHealthPoints, playerStats.PlayerMaxHealthPoints);
    }

    public void OnExperienceChange(float experience)
    {
        playerStats.PlayerExperiencePoints += experience;
        experienceBar.OnExperienceChange(playerStats.PlayerExperiencePoints, playerStats.PlayerMaxExperiencePoints);
    }

    public void setGameCallbacks(GameCallbacks gameCallbacks)
    {
        this.gameCallbacks = gameCallbacks;
    }

    //
    // Getters & setters
    public float getPlayerDamage()
    {
        return playerStats.PlayerDamage;
    }
}

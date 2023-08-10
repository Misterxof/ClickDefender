using Possibilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Components
    private Rigidbody2D _rigidbody2D;
    private GameObject _player;
    private Rigidbody2D _playerRigidBody;

    // Scripts
    private PlayerController _playerController;
    private EnemyBase _enemyStats;

    // Enemy
    private float _inputHorizontal;
    private float _inputVertitcal;

    public ObjectType Type = ObjectType.Enemy;
    public float HealthPoints = 0;
    public float Damage;
    public float WalkSpeed;
    public float SpeedLimiter;
    public float EnemyExp;
    

    // Start is called before the first frame update 
    void Start()
    {
        _enemyStats = GetComponent<EnemyBase>();
        _player = GameObject.Find("Player");

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
        _playerController = _player.GetComponent<PlayerController>();

        HealthPoints = _enemyStats.EnemyHealth;
        Damage = _enemyStats.EnemyDamage;
        EnemyExp = _enemyStats.EnemyExpierence;
        WalkSpeed = _enemyStats.EnemyMoveSpeed;
        SpeedLimiter = _enemyStats.EnemyMoveSpeedLimit;
    }

    // Update is called once per frame
    void Update()
    {
        float directitonX = _rigidbody2D.position.x - _playerRigidBody.position.x;
        float directitonY = _rigidbody2D.position.y - _playerRigidBody.position.y;

        if (directitonX > 0 && directitonY > 0)
        {
            _inputHorizontal = -1f;
            _inputVertitcal = -1f;
        } else if (directitonX < 0 && directitonY < 0)
        {
            _inputHorizontal = 1f;
            _inputVertitcal = 1f;
        } else if (directitonX > 0 && directitonY < 0)
        {
            _inputHorizontal = -1f;
            _inputVertitcal = 1f;
        }
        else if (directitonX < 0 && directitonY > 0)
        {
            _inputHorizontal = 1f;
            _inputVertitcal = -1f;
        }

    }

    private void FixedUpdate()
    {
        if (_inputHorizontal != 0 || _inputVertitcal != 0)
        {
            if (_inputHorizontal != 0 && _inputVertitcal != 0)
            {
                _inputHorizontal *= SpeedLimiter;
                _inputVertitcal *= SpeedLimiter;
            }

            _rigidbody2D.velocity = new Vector2(_inputHorizontal * WalkSpeed, _inputVertitcal * WalkSpeed);
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)){
            HealthPoints -= _playerController.getPlayerDamage();
            if (HealthPoints <= 0)
                Die();
        }
    }

    public void OnHealthDamage(float damage)
    {
        HealthPoints -= damage;
        Debug.Log("Hitted " + gameObject.name + " health " + HealthPoints);

        if (HealthPoints <= 0)
        {
            Debug.Log("Dead " + gameObject.name);
            Die();
        }
    }

    public void OnCollisionWithPlayer(Collider2D collision, GameObject impacter)
    {
        impacter.GetComponent<PlayerController>().OnHealthDamage(10);
        Debug.Log("Health " + impacter.GetComponent<PlayerController>().PlayerStats.PlayerHealthPoints);
    }

    void Die()
    {
        _player.GetComponent<PlayerController>().OnExperienceChange(EnemyExp);
        Destroy(this.gameObject);
        // animation

        // disable
       // this.enabled = false;
    }
}

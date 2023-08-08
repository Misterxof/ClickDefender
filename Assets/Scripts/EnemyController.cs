using Possibilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Components
    Rigidbody2D _rigidbody;
    GameObject player;
    Rigidbody2D playerRigidBody;

    // Scripts
    PlayerController playerController;
    EnemyBase enemyStats;

    // Enemy
    public ObjectType type = ObjectType.Enemy;
    public float healthPoints = 0;
    public float damage;
    public float walkSpeed;
    public float speedLimiter;
    public float enemyExp;
    float inputHorizontal;
    float inputVertitcal;

    // Start is called before the first frame update 
    void Start()
    {
        enemyStats = GetComponent<EnemyBase>();
        player = GameObject.Find("Player");

        _rigidbody = GetComponent<Rigidbody2D>();
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        playerController = player.GetComponent<PlayerController>();

        healthPoints = enemyStats.EnemyHealth;
        damage = enemyStats.EnemyDamage;
        enemyExp = enemyStats.EnemyExpierence;
        walkSpeed = enemyStats.EnemyMoveSpeed;
        speedLimiter = enemyStats.EnemyMoveSpeedLimit;
    }

    // Update is called once per frame
    void Update()
    {
        float directitonX = _rigidbody.position.x - playerRigidBody.position.x;
        float directitonY = _rigidbody.position.y - playerRigidBody.position.y;

        if (directitonX > 0 && directitonY > 0)
        {
            inputHorizontal = -1f;
            inputVertitcal = -1f;
        } else if (directitonX < 0 && directitonY < 0)
        {
            inputHorizontal = 1f;
            inputVertitcal = 1f;
        } else if (directitonX > 0 && directitonY < 0)
        {
            inputHorizontal = -1f;
            inputVertitcal = 1f;
        }
        else if (directitonX < 0 && directitonY > 0)
        {
            inputHorizontal = 1f;
            inputVertitcal = -1f;
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
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)){
            healthPoints -= playerController.getPlayerDamage();
            if (healthPoints <= 0)
                Die();
        }
    }

    public void OnHealthDamage(float damage)
    {
        healthPoints -= damage;
        Debug.Log("Hitted " + gameObject.name + " health " + healthPoints);

        if (healthPoints <= 0)
        {
            Debug.Log("Dead " + gameObject.name);
            Die();
        }
    }

    public void OnCollisionWithPlayer(Collider2D collision, GameObject impacter)
    {
        impacter.GetComponent<PlayerController>().OnHealthDamage(10);
        Debug.Log("Health " + impacter.GetComponent<PlayerController>().playerStats.PlayerHealthPoints);
    }

    void Die()
    {
        player.GetComponent<PlayerController>().OnExperienceChange(enemyExp);
        Destroy(this.gameObject);
        // animation

        // disable
       // this.enabled = false;
    }
}

using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    private float _health = 1f;
    private float _damage = 1f;
    private float _expierence = 10f;
    private float _moveSpeed = 1f;
    private float _moveSpeedLimit = 0.7f;

    private GameObject _prefab;

    public float EnemyHealth
    {
        get { return _health; }
        set { _health = value; }
    }

    public float EnemyDamage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public float EnemyExpierence
    {
        get { return _expierence; }
        set { _expierence = value; }
    }

    public float EnemyMoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    public float EnemyMoveSpeedLimit
    {
        get { return _moveSpeedLimit; }
        set { _moveSpeedLimit = value; }
    }

    public GameObject EnemyPrefab
    {
        get { return _prefab; }
        set { _prefab = value; }
    }
}

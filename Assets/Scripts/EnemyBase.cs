using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    private float health = 1f;
    private float damage = 1f;
    private float expierence = 10f;
    private float moveSpeed = 1f;
    private float moveSpeedLimit = 0.7f;

    private GameObject prefab;

    public float EnemyHealth
    {
        get { return health; }
        set { health = value; }
    }

    public float EnemyDamage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float EnemyExpierence
    {
        get { return expierence; }
        set { expierence = value; }
    }

    public float EnemyMoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public float EnemyMoveSpeedLimit
    {
        get { return moveSpeedLimit; }
        set { moveSpeedLimit = value; }
    }

    public GameObject EnemyPrefab
    {
        get { return prefab; }
        set { prefab = value; }
    }
}

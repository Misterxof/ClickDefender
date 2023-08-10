using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float _nextAttackTime = 0f;

    public Animator Animator;
    public Transform AttackPoint;
    public LayerMask EnemyLayers;

    public float AttackRange = 0.5f;
    public float Damage = 50f;

    public float AttackRate = 2f;


    // Update is called once per frame
    void Update()
    {
        Animator = gameObject.GetComponent<Animator>();
        AttackPoint = GameObject.Find("/Player/AttackPoint").transform;
    }

    public void AttackButtonOnCLick()
    {
        if (Time.time >= _nextAttackTime)
        {
            Attack();
            _nextAttackTime = Time.time + 1f / AttackRate;
        }
    }

    void Attack()
    {
        EnemyController enemyC = Utils.FindClosest(this.transform);
        Debug.Log("NEAREST " + Utils.FindClosest(this.transform).name);
        Vector3 newPos = Utils.LerpByDistance(this.transform.position, enemyC.transform.position, 0.1f);
        AttackPoint.transform.position = newPos;
        //attackPoint.transform.position = Vector3.Lerp(this.transform.position, enemyC.transform.position, 0.1f);
        Animator.SetTrigger("Attack");

        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

        foreach (Collider2D enemy in hittedEnemies)
        {
            enemy.GetComponent<EnemyController>().OnHealthDamage(Damage);
        }
    }

    private void OnDrawGizmosSelected()
    {

        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}

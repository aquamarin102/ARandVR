using UnityEditor;
using UnityEngine;

public class EnemyController : UnitController
{
    [SerializeField] private float maxDistance = 5f;

    protected override void Update()
    {
        base.Update();
        if (!isDead && UnitManager.player.health != null)
        {
            if (Vector3.Distance(UnitManager.player.transform.position, transform.position) <= maxDistance)
            {
                combat.Attack(UnitManager.player.health);
            }

            Vector3 playerPosition = UnitManager.player.transform.position;
            Vector3 direction = playerPosition - transform.position;

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    protected override void Die()
    {
        base.Die();

        UnitManager.enemy = null;
    }
}
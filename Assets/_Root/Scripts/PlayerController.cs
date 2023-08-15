using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitController
{
    [SerializeField] private float maxDistance = 5f;

    private VirtualButtonBehaviour virtualButton;

    private void Start()
    {
        virtualButton = gameObject.transform.parent.GetComponentInChildren<VirtualButtonBehaviour>();
        virtualButton.RegisterOnButtonPressed(OnButtonPressed);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (!isDead && UnitManager.enemy != null)
        {
            if (Vector3.Distance(UnitManager.enemy.transform.position, transform.position) <= maxDistance)
            {
                combat.Attack(UnitManager.enemy.health);
            }

            Vector3 enemyPosition = UnitManager.enemy.transform.position;
            Vector3 direction = enemyPosition - transform.position;

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    protected override void Die()
    {
        base.Die();
        UnitManager.player = null;
    }
}
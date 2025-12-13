using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float cooldownTimer;

    protected Player player;

    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
    }
    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public virtual bool TryUseSkill()
    {
        if (cooldownTimer < 0)
        {
            cooldownTimer = cooldown;
            UseSkiil();
            return true;
        }

        Debug.Log("skill is on cooldown");
        return false;
    }

    public virtual void UseSkiil()
    {

    }

    protected virtual Transform FindClosestEnemy(Transform _checkTransform)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_checkTransform.position, 25);
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                float diatanceToEnemy = Vector2.Distance(_checkTransform.position, hit.transform.position);
                if (diatanceToEnemy < closestDistance)
                {
                    closestDistance = diatanceToEnemy;
                    closestEnemy = hit.transform;
                }
            }
        }
        return closestEnemy;
    }
}

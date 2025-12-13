using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPool : ObjectPool<CrystalSkillController>
{
    public static CrystalPool Instance;

    protected override void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        base.Awake();
    }

    public CrystalSkillController SpawnCrystal(Vector3 position, float duration, bool canExplode, bool canMoveToEnemy, float moveSpeed)
    {
        CrystalSkillController crystal = Get();

        crystal.transform.position = position;
        crystal.transform.rotation = Quaternion.identity;

        crystal.SetupCrystal(duration, canExplode, canMoveToEnemy, moveSpeed);

        return crystal;
    }

    public void DespawnCrystal(CrystalSkillController crystal)
    {
        Release(crystal);
    }
}

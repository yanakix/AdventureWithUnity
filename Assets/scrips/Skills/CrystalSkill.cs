using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSkill : Skill
{
    [SerializeField] private float crystalDuration;
    private GameObject currentCrystal;


    [Header("Crystal mirage")]
    [SerializeField] private bool cloneInsteadOfCrystal;

    [Header("Explosive crystal")]
    [SerializeField] private bool canExplode;

    [Header("Move crystal")]
    [SerializeField] private bool canMoveToEnemy;
    [SerializeField] private float moveSpeed;

    [Header("Multi stacking crystal")]
    [SerializeField] private bool canUseMultiStacks;
    [SerializeField] private int amountOfStacks;
    [SerializeField] private float multiStakeCooldown;
    private int crystalLeft;

    private void Awake()
    {
        crystalLeft = amountOfStacks;
    }

    public override void UseSkiil()
    {
        base.UseSkiil();

        if (TryUseMultiCrystal())
        {
            return;
        }

        if (currentCrystal == null || currentCrystal.activeSelf == false)
        {
            CreateCrystal();
            if (cloneInsteadOfCrystal)
            {
                cooldownTimer = -1;
            }
        }
        else
        {
            if (canMoveToEnemy)
            {
                return;
            }

            Vector2 playerPos = player.transform.position;
            player.transform.position = currentCrystal.transform.position;
            currentCrystal.transform.position = playerPos;

            if (cloneInsteadOfCrystal)
            {
                SkillManager.instance.clone.CreateClone(currentCrystal.transform, Vector3.zero, false);
                CrystalPool.Instance.DespawnCrystal(currentCrystal.GetComponent<CrystalSkillController>());
            }
            else
            {
                currentCrystal.GetComponent<CrystalSkillController>()?.crystalCompleted();
            }
        }
    }

    public void CreateCrystal()
    {
        //get one from pool
        CrystalSkillController crystal = CrystalPool.Instance.SpawnCrystal(player.transform.position, crystalDuration, canExplode, canMoveToEnemy, moveSpeed);
        currentCrystal = crystal.gameObject;
    }

    private bool TryUseMultiCrystal()
    {
        if (!canUseMultiStacks )
        {
            return false;
        }

        if (crystalLeft > 0)
        {
            cooldown = 0;
            crystalLeft -= 1;

            CrystalSkillController crystal = CrystalPool.Instance.SpawnCrystal(player.transform.position, crystalDuration, canExplode, canMoveToEnemy, moveSpeed);


            if (crystalLeft <= 0)
            {
                cooldown = multiStakeCooldown;
                crystalLeft = amountOfStacks;
            }
        }
        return true;

    }


}

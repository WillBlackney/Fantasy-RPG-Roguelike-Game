﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGolem : Enemy
{
    public override void SetBaseProperties()
    {
        base.SetBaseProperties();
        mySpellBook.EnemyLearnAbility("Rock Toss");
        mySpellBook.EnemyLearnAbility("Move");
    }

    public override IEnumerator StartMyActivationCoroutine()
    {
        Ability rockToss = mySpellBook.GetAbilityByName("Rock Toss");
        Ability move = mySpellBook.GetAbilityByName("Move");
        

        ActionStart:
        
        if (IsAbleToTakeActions() == false)
        {
            EndMyActivation();
        }

        // Rock Toss
        else if (IsTargetInRange(EntityLogic.GetClosestEnemy(this), rockToss.abilityRange) &&
            HasEnoughAP(currentAP, rockToss.abilityAPCost) &&
            IsAbilityOffCooldown(rockToss.abilityCurrentCooldownTime)
            )
        {
            Debug.Log("Skeleton Archer using Impaling Bolt...");
            SetTargetDefender(EntityLogic.GetClosestEnemy(this));
            // VFX notification
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Rock Toss", false));
            yield return new WaitForSeconds(0.5f);
            Action action = AbilityLogic.Instance.PerformRockToss(this, myCurrentTarget);
            yield return new WaitUntil(() => action.ActionResolved() == true);
            yield return new WaitForSeconds(1f);
            goto ActionStart;

        }        

        EndMyActivation();
    }
}

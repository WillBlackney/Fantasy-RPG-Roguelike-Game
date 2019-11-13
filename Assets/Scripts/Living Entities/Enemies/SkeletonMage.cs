﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMage : Enemy
{
    public override void SetBaseProperties()
    {
        base.SetBaseProperties();
        mySpellBook.EnemyLearnAbility("Strike");
        mySpellBook.EnemyLearnAbility("Fire Ball");
        mySpellBook.EnemyLearnAbility("Move");
        mySpellBook.EnemyLearnAbility("Frost Bolt");

        myPassiveManager.ModifyQuickReflexes(1);
    }

    public override IEnumerator StartMyActivationCoroutine()
    {
        Ability fireBall = mySpellBook.GetAbilityByName("Fire Ball");
        Ability move = mySpellBook.GetAbilityByName("Move");
        Ability frostBolt = mySpellBook.GetAbilityByName("Frost Bolt");

        ActionStart:

        if (IsAbleToTakeActions() == false)
        {
            EndMyActivation();
        }

        // Frost Bolt
        else if (IsTargetInRange(EntityLogic.GetClosestEnemy(this), frostBolt.abilityRange) &&
            HasEnoughAP(currentAP, frostBolt.abilityAPCost) &&
            IsAbilityOffCooldown(frostBolt.abilityCurrentCooldownTime)
            )
        {            
            SetTargetDefender(EntityLogic.GetClosestEnemy(this));
            // VFX notification
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Frost Bolt", false));
            yield return new WaitForSeconds(0.5f);
            Action action = AbilityLogic.Instance.PerformFrostBolt(this, myCurrentTarget);
            yield return new WaitUntil(() => action.ActionResolved() == true);

            yield return new WaitForSeconds(1f);
            goto ActionStart;

        }


        // Fireball the most vulnerable target
        else if (IsTargetInRange(GetMostVulnerableDefender(), fireBall.abilityRange) &&
            //GetMostVulnerableDefender().isKnockedDown &&
            HasEnoughAP(currentAP, fireBall.abilityAPCost) &&
            IsAbilityOffCooldown(fireBall.abilityCurrentCooldownTime))
        {
            SetTargetDefender(GetMostVulnerableDefender());
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Fire Ball", false));
            yield return new WaitForSeconds(0.5f);
            Action action = AbilityLogic.Instance.PerformFireBall(this, myCurrentTarget);
            yield return new WaitUntil(() => action.ActionResolved() == true);

            yield return new WaitForSeconds(1f);
            goto ActionStart;

        }

        // Fireball the target with lowest current HP
        else if (IsTargetInRange(GetDefenderWithLowestCurrentHP(), fireBall.abilityRange) &&
            HasEnoughAP(currentAP, fireBall.abilityAPCost) &&
            IsAbilityOffCooldown(fireBall.abilityCurrentCooldownTime))
        {
            SetTargetDefender(GetDefenderWithLowestCurrentHP());
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Fire Ball", false));
            yield return new WaitForSeconds(0.5f);
            Action action = AbilityLogic.Instance.PerformFireBall(this, myCurrentTarget);
            yield return new WaitUntil(() => action.ActionResolved() == true);

            yield return new WaitForSeconds(1f);
            goto ActionStart;
        }

        // Fireball the closest target if the most vulnerable and the weakest cant be targetted
        else if (IsTargetInRange(EntityLogic.GetClosestEnemy(this), fireBall.abilityRange) &&
            HasEnoughAP(currentAP, fireBall.abilityAPCost) &&
            IsAbilityOffCooldown(fireBall.abilityCurrentCooldownTime))
        {
            SetTargetDefender(EntityLogic.GetClosestEnemy(this));
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Fire Ball", false));
            yield return new WaitForSeconds(0.5f);
            Action action = AbilityLogic.Instance.PerformFireBall(this, myCurrentTarget);
            yield return new WaitUntil(() => action.ActionResolved() == true);

            yield return new WaitForSeconds(1f);
            goto ActionStart;
        }
        
        // Move
        else if (
            IsTargetInRange(EntityLogic.GetClosestEnemy(this), fireBall.abilityRange) == false &&
            IsAbleToMove() && 
            HasEnoughAP(currentAP, move.abilityAPCost)
            )
        {
            SetTargetDefender(EntityLogic.GetClosestEnemy(this));
            
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Move", false));
            yield return new WaitForSeconds(0.5f);

            Tile destination = AILogic.GetBestValidMoveLocationBetweenMeAndTarget(this, myCurrentTarget, fireBall.abilityRange, currentMobility);
            Action movementAction = AbilityLogic.Instance.PerformMove(this, destination);
            yield return new WaitUntil(() => movementAction.ActionResolved() == true);

            // small delay here in order to seperate the two actions a bit.
            yield return new WaitForSeconds(1f);
            goto ActionStart;
        }

        EndMyActivation();
    }
}

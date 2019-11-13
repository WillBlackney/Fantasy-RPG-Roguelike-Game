﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Enemy
{
    public override void SetBaseProperties()
    {
        base.SetBaseProperties();

        mySpellBook.EnemyLearnAbility("Move");
        mySpellBook.EnemyLearnAbility("Strike");
        mySpellBook.EnemyLearnAbility("Twin Strike");
        mySpellBook.EnemyLearnAbility("Siphon Life");
        mySpellBook.EnemyLearnAbility("Dash");
        //mySpellBook.EnemyLearnAbility("Teleport");
        //mySpellBook.EnemyLearnAbility("Fire Ball");

        //myPassiveManager.LearnRegeneration(3);
        myPassiveManager.ModifyLifeSteal(1);

    }

    public override IEnumerator StartMyActivationCoroutine()
    {
        
        Ability move = mySpellBook.GetAbilityByName("Move");
        Ability siphonLife = mySpellBook.GetAbilityByName("Siphon Life");
        Ability twinStrike = mySpellBook.GetAbilityByName("Twin Strike");
        Ability strike = mySpellBook.GetAbilityByName("Strike");
        Ability dash = mySpellBook.GetAbilityByName("Dash");
       

        ChooseRandomTargetingLogic();

        ActionStart:     
        

        if(myCurrentTarget.currentHealth <= 0 || myCurrentTarget == null)
        {
            ChooseRandomTargetingLogic();
        }

        if (IsAbleToTakeActions() == false)
        {
            EndMyActivation();
        }

        // Siphon Life
        else if(IsAbilityOffCooldown(siphonLife.abilityCurrentCooldownTime) &&
            IsTargetInRange(myCurrentTarget, siphonLife.abilityRange) &&
            HasEnoughAP(currentAP, siphonLife.abilityAPCost)
            )
        {
            //SetTargetDefender(GetClosestDefender());
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Siphon Life", false));
            yield return new WaitForSeconds(0.5f);
            Action slAction = AbilityLogic.Instance.PerformSiphonLife(this, myCurrentTarget);
            yield return new WaitUntil(() => slAction.ActionResolved() == true);
            // brief delay between actions
            yield return new WaitForSeconds(1f);
            goto ActionStart;
        }

        // If unable to siphon life the ideal target, siphon the closest valid target
        else if (IsAbilityOffCooldown(siphonLife.abilityCurrentCooldownTime) &&
            IsTargetInRange(EntityLogic.GetClosestEnemy(this), siphonLife.abilityRange) &&
            HasEnoughAP(currentAP, siphonLife.abilityAPCost)
            )
        {
            SetTargetDefender(EntityLogic.GetClosestEnemy(this));
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Siphon Life", false));
            yield return new WaitForSeconds(0.5f);
            Action slAction = AbilityLogic.Instance.PerformSiphonLife(this, myCurrentTarget);
            yield return new WaitUntil(() => slAction.ActionResolved() == true);
            // brief delay between actions
            yield return new WaitForSeconds(1f);
            goto ActionStart;
        }

        // Twin Strike
        else if (IsTargetInRange(myCurrentTarget, currentMeleeRange) &&
            HasEnoughAP(currentAP, twinStrike.abilityAPCost) &&
            IsAbilityOffCooldown(twinStrike.abilityCurrentCooldownTime))
        {
            //SetTargetDefender(GetDefenderWithLowestCurrentHP());
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Twin Strike", false));
            yield return new WaitForSeconds(0.5f);
            Action twinStrikeAction = AbilityLogic.Instance.PerformTwinStrike(this, myCurrentTarget);
            yield return new WaitUntil(() => twinStrikeAction.ActionResolved() == true);
            yield return new WaitForSeconds(1f);
            goto ActionStart;
        }

        // Strike
        else if (IsTargetInRange(myCurrentTarget, currentMeleeRange) &&
            HasEnoughAP(currentAP, strike.abilityAPCost) &&
            IsAbilityOffCooldown(strike.abilityCurrentCooldownTime))
        {
            //SetTargetDefender(GetDefenderWithLowestCurrentHP());
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Strike", false));
            yield return new WaitForSeconds(0.5f);
            Action strikeAction = AbilityLogic.Instance.PerformStrike(this, myCurrentTarget);
            yield return new WaitUntil(() => strikeAction.ActionResolved() == true);
            yield return new WaitForSeconds(1f);
            goto ActionStart;
        }

        // Dash
        else if (IsTargetInRange(myCurrentTarget, currentMeleeRange) == false &&
            IsAbleToMove() &&
            HasEnoughAP(currentAP, dash.abilityAPCost) &&
            IsAbilityOffCooldown(dash.abilityCurrentCooldownTime)
            )
        {
            
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Dash", false));
            yield return new WaitForSeconds(0.5f);

            Tile destination = AILogic.GetBestValidMoveLocationBetweenMeAndTarget(this, myCurrentTarget, currentMeleeRange, dash.abilityPrimaryValue);
            Action dashAction = AbilityLogic.Instance.PerformDash(this, destination);
            yield return new WaitUntil(() => dashAction.ActionResolved() == true);

            // small delay here in order to seperate the two actions a bit.
            yield return new WaitForSeconds(1f);
            goto ActionStart;
        }

        // Move
        else if (IsTargetInRange(myCurrentTarget,currentMeleeRange) == false &&
            IsAbleToMove() &&
            HasEnoughAP(currentAP, move.abilityAPCost) &&
            IsAbilityOffCooldown(move.abilityCurrentCooldownTime)
            )
        {
            StartCoroutine(VisualEffectManager.Instance.CreateStatusEffect(transform.position, "Move", false));
            yield return new WaitForSeconds(0.5f);

            Tile destination = AILogic.GetBestValidMoveLocationBetweenMeAndTarget(this, myCurrentTarget, currentMeleeRange, currentMobility);
            Action movementAction = AbilityLogic.Instance.PerformMove(this, destination);
            yield return new WaitUntil(() => movementAction.ActionResolved() == true);

            // small delay here in order to seperate the two actions a bit.
            yield return new WaitForSeconds(1f);
            goto ActionStart;
        }       
       

        EndMyActivation();
    }

    public void ChooseRandomTargetingLogic()
    {
        Debug.Log("ChooseRandomTargetingLogic() called...");
        int randomNumber = Random.Range(0, 2);

        if(randomNumber == 0)
        {
            SetTargetDefender(EntityLogic.GetClosestEnemy(this));
        }

        else
        {
            SetTargetDefender(GetDefenderWithLowestCurrentHP());
        }

        Debug.Log("ChooseRandomTargetingLogic() set target as: " + myCurrentTarget.name);
    }

    public Tile GetBestTeleportLocation(Tile tileEscapingFrom)
    {
        Tile furthestTile = null;
        List <Tile> allTiles = LevelManager.Instance.GetAllTilesFromCurrentLevelDictionary();

        float largestDistance = 0;

        foreach(Tile tile in allTiles)
        {            
            if(tile.IsEmpty && tile.IsWalkable)
            {
                float distancefromThisTile = 0;

                distancefromThisTile = Vector2.Distance(tileEscapingFrom.WorldPosition, tile.WorldPosition);
                if (distancefromThisTile > largestDistance)
                {
                    furthestTile = tile;
                    largestDistance = distancefromThisTile;
                    Debug.Log("Furthest tile distance is now: " + largestDistance.ToString());
                }

            }          
        }

        return furthestTile;
    }

    
}

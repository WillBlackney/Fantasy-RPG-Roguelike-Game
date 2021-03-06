﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Defender : LivingEntity
{
    // Properties + Component References
    #region
    [Header("Defender Core GUI Component References ")]
    public GameObject myUIParent;
    public CanvasGroup myUIParentCg;
    public AbilityBar myAbilityBar;

    [Header("Defender Health Bar Component References ")]
    public Slider myHealthBarStatPanel;
    public TextMeshProUGUI myCurrentHealthTextStatBar;
    public TextMeshProUGUI myCurrentMaxHealthTextStatBar;
    
    [Header("Defender Energy Bar Component References ")]
    public Slider myEnergyBar;
    public TextMeshProUGUI myCurrentEnergyBarText;
    public TextMeshProUGUI myCurrentMaxEnergyBarText;

    [Header("Defender Properties")]
    public float uiFadeSpeed;
    [HideInInspector] public CharacterData myCharacterData;
    [HideInInspector] public bool fadingIn;
    [HideInInspector] public bool fadingOut;

    [Header("Ability Orders")]
    [HideInInspector] public bool awaitingAnOrder;
    [HideInInspector] public bool awaitingMoveOrder;
    [HideInInspector] public bool awaitingStrikeOrder;
    [HideInInspector] public bool awaitingChargeTargetOrder;
    [HideInInspector] public bool awaitingChargeLocationOrder;
    [HideInInspector] public bool awaitingInspireOrder;
    [HideInInspector] public bool awaitingGuardOrder;
    [HideInInspector] public bool awaitingShootOrder;
    [HideInInspector] public bool awaitingMeteorOrder;
    [HideInInspector] public bool awaitingTelekinesisTargetOrder;
    [HideInInspector] public bool awaitingTelekinesisLocationOrder;
    [HideInInspector] public bool awaitingFrostBoltOrder;
    [HideInInspector] public bool awaitingFireBallOrder;
    [HideInInspector] public bool awaitingRapidFireOrder;
    [HideInInspector] public bool awaitingImpalingBoltOrder;
    [HideInInspector] public bool awaitingForestMedicineOrder;
    [HideInInspector] public bool awaitingInvigorateOrder;
    [HideInInspector] public bool awaitingHolyFireOrder;
    [HideInInspector] public bool awaitingVoidBombOrder;
    [HideInInspector] public bool awaitingNightmareOrder;
    [HideInInspector] public bool awaitingTwinStrikeOrder;
    [HideInInspector] public bool awaitingDashOrder;
    [HideInInspector] public bool awaitingSliceAndDiceOrder;
    [HideInInspector] public bool awaitingPoisonDartOrder;
    [HideInInspector] public bool awaitingChemicalReactionOrder;
    [HideInInspector] public bool awaitingGetDownOrder;
    [HideInInspector] public bool awaitingDisengageOrder;
    [HideInInspector] public bool awaitingSmashOrder;
    [HideInInspector] public bool awaitingLightningShieldOrder;
    [HideInInspector] public bool awaitingChainLightningOrder;
    [HideInInspector] public bool awaitingPrimalBlastOrder;
    [HideInInspector] public bool awaitingPrimalRageOrder;
    [HideInInspector] public bool awaitingPhaseShiftOrder;
    [HideInInspector] public bool awaitingSanctityOrder;
    [HideInInspector] public bool awaitingBlessOrder;
    [HideInInspector] public bool awaitingSiphonLifeOrder;
    [HideInInspector] public bool awaitingChaosBoltOrder;
    [HideInInspector] public bool awaitingShadowBlastOrder;
    [HideInInspector] public bool awaitingMeltOrder;
    [HideInInspector] public bool awaitingKickToTheBallsOrder;
    [HideInInspector] public bool awaitingRamOrder;
    [HideInInspector] public bool awaitingDevastatingBlowOrder;
    [HideInInspector] public bool awaitingBladeFlurryOrder;
    [HideInInspector] public bool awaitingEvasionOrder;
    [HideInInspector] public bool awaitingShieldSlamOrder;
    [HideInInspector] public bool awaitingTendonSlashOrder;
    [HideInInspector] public bool awaitingShieldShatterOrder;
    [HideInInspector] public bool awaitingSwordAndBoardOrder;
    [HideInInspector] public bool awaitingPhoenixDiveOrder;
    [HideInInspector] public bool awaitingChillingBlowOrder;
    [HideInInspector] public bool awaitingIcyFocusOrder;
    [HideInInspector] public bool awaitingCombustionOrder;
    [HideInInspector] public bool awaitingDragonBreathOrder;
    [HideInInspector] public bool awaitingBlizzardOrder;
    [HideInInspector] public bool awaitingFrostArmourOrder;
    [HideInInspector] public bool awaitingThawOrder;
    [HideInInspector] public bool awaitingSnipeOrder;
    [HideInInspector] public bool awaitingHasteOrder;
    [HideInInspector] public bool awaitingSteadyHandsOrder;
    [HideInInspector] public bool awaitingTreeLeapOrder;
    [HideInInspector] public bool awaitingDimensionalBlastOrder;
    [HideInInspector] public bool awaitingMirageOrder;
    [HideInInspector] public bool awaitingBurstOfKnowledgeOrder;
    [HideInInspector] public bool awaitingBlinkOrder;
    [HideInInspector] public bool awaitingTimeWarpOrder;
    [HideInInspector] public bool awaitingDimensionalHexOrder;
    [HideInInspector] public bool awaitingBlindingLightOrder;
    [HideInInspector] public bool awaitingTranscendenceOrder;
    [HideInInspector] public bool awaitingJudgementOrder;
    [HideInInspector] public bool awaitingShroudOrder;
    [HideInInspector] public bool awaitingRainOfChaosOrder;
    [HideInInspector] public bool awaitingBlightOrder;
    [HideInInspector] public bool awaitingToxicSlashOrder;
    [HideInInspector] public bool awaitingToxicEruptionOrder;
    [HideInInspector] public bool awaitingDrainOrder;
    [HideInInspector] public bool awaitingLightningBoltOrder;
    [HideInInspector] public bool awaitingThunderStrikeOrder;
    [HideInInspector] public bool awaitingSpiritVisionOrder;
    [HideInInspector] public bool awaitingThunderStormOrder;
    [HideInInspector] public bool awaitingConcealingCloudsOrder;
    [HideInInspector] public bool awaitingHeadShotOrder;
    [HideInInspector] public bool awaitingHexOrder;
    [HideInInspector] public bool awaitingShankOrder;
    [HideInInspector] public bool awaitingCheapShotOrder;
    [HideInInspector] public bool awaitingAmbushOrder;
    [HideInInspector] public bool awaitingShadowStepOrder;
    [HideInInspector] public bool awaitingProvokeOrder;
    [HideInInspector] public bool awaitingDecapitateOrder;
    [HideInInspector] public bool awaitingDisarmOrder;
    [HideInInspector] public bool awaitingGoBerserkOrder;
    [HideInInspector] public bool awaitingFortifyOrder;
    [HideInInspector] public bool awaitingStoneFormOrder;
    [HideInInspector] public bool awaitingBackStabOrder;
    [HideInInspector] public bool awaitingChloroformBombOrder;
    [HideInInspector] public bool awaitingPinningShotOrder;
    [HideInInspector] public bool awaitingMarkTargetOrder;
    [HideInInspector] public bool awaitingSnowStasisOrder;
    [HideInInspector] public bool awaitingOverloadOrder;
    [HideInInspector] public bool awaitingBlazeOrder;
    [HideInInspector] public bool awaitingCreepingFrostOrder;
    [HideInInspector] public bool awaitingShadowWreathOrder;
    [HideInInspector] public bool awaitingDarkGiftOrder;
    [HideInInspector] public bool awaitingSuperConductorOrder;

    [Header("Update Related Properties")]
    [HideInInspector] public bool energyBarPositionCurrentlyUpdating;
    [HideInInspector] public bool healthBarPositionCurrentlyUpdating;

    #endregion

    // Initialization + Setup
    #region
    public override void InitializeSetup(Point startingGridPosition, Tile startingTile)
    {
        // Add to persistent defender data list
        DefenderManager.Instance.allDefenders.Add(this);

        // Set name
        myName = myCharacterData.myName;

        // Auto Get+Set World camera for UI canvas (helps with performance)
        myUIParent.GetComponent<Canvas>().worldCamera = CameraManager.Instance.unityCamera.mainCamera;

        // Hide UI
        myUIParent.SetActive(false);

        // Set parent to keep hierachy view clean
        transform.SetParent(DefenderManager.Instance.defendersParent.transform);

        // Perform standard LE setup
        base.InitializeSetup(startingGridPosition, startingTile);
    }
    public override void SetBaseProperties()
    {
        // Build view model
        CharacterModelController.BuildModelFromModelClone(myModel, myCharacterData.myCharacterModel);

        // Get and build from relevant character data values
        RunSetupFromCharacterData();

        // Perform standard LE setup
        base.SetBaseProperties();

        // Set up ability button descriptions
        mySpellBook.SetNewAbilityDescriptions();
        
    }
    public void RunSetupFromCharacterData()
    {
        Debug.Log("RunSetupFromCharacterData() called...");

        // Establish connection from defender script to character data
        myCharacterData.myDefenderGO = this;

        // Setup Core Stats
        baseMaxHealth = myCharacterData.maxHealth;
        baseStartingHealth = myCharacterData.currentHealth;
        baseStrength = myCharacterData.strength;
        baseWisdom = myCharacterData.wisdom;
        baseDexterity = myCharacterData.dexterity;
        baseMobility = myCharacterData.mobility;
        baseStamina = myCharacterData.stamina;
        baseInitiative = myCharacterData.initiative;

        // Setup Secondary Stats
        baseCriticalChance = myCharacterData.criticalChance;
        baseDodgeChance = myCharacterData.dodge;
        baseParryChance = myCharacterData.parry;
        baseAuraSize = myCharacterData.auraSize;
        baseMaxEnergy = myCharacterData.maxEnergy;
        baseMeleeRange = myCharacterData.meleeRange;

        // Setup Resistances
        basePhysicalResistance = myCharacterData.physicalResistance;
        baseFireResistance = myCharacterData.fireResistance;
        baseFrostResistance = myCharacterData.frostResistance;
        basePoisonResistance = myCharacterData.poisonResistance;
        baseShadowResistance = myCharacterData.shadowResistance;
        baseAirResistance = myCharacterData.airResistance;

        // Setup Passives
        if (myCharacterData.tenaciousStacks > 0)
        {
            myPassiveManager.ModifyTenacious(myCharacterData.tenaciousStacks);
        }
        if (myCharacterData.enrageStacks > 0)
        {
            myPassiveManager.ModifyEnrage(myCharacterData.enrageStacks);
        }
        if (myCharacterData.masochistStacks > 0)
        {
            myPassiveManager.ModifyMasochist(myCharacterData.masochistStacks);
        }
        if (myCharacterData.lastStandStacks > 0)
        {
            myPassiveManager.ModifyLastStand(myCharacterData.lastStandStacks);
        }
        if (myCharacterData.unstoppableStacks > 0)
        {
            myPassiveManager.ModifyUnstoppable(1);
        }
        if (myCharacterData.slipperyStacks > 0)
        {
            myPassiveManager.ModifySlippery(myCharacterData.slipperyStacks);
        }
        if (myCharacterData.riposteStacks > 0)
        {
            myPassiveManager.ModifyRiposte(myCharacterData.riposteStacks);
        }
        if (myCharacterData.virtuosoStacks > 0)
        {
            myPassiveManager.ModifyVirtuoso(myCharacterData.virtuosoStacks);
        }
        if (myCharacterData.perfectReflexesStacks > 0)
        {
            myPassiveManager.ModifyPerfectReflexes(myCharacterData.perfectReflexesStacks);
        }
        if (myCharacterData.opportunistStacks > 0)
        {
            myPassiveManager.ModifyOpportunist(myCharacterData.opportunistStacks);
        }
        if (myCharacterData.patientStalkerStacks > 0)
        {
            myPassiveManager.ModifyPatientStalker(myCharacterData.patientStalkerStacks);
        }
        if (myCharacterData.stealthStacks > 0)
        {
            myPassiveManager.ModifyStealth(myCharacterData.stealthStacks);
        }
        if (myCharacterData.cautiousStacks > 0)
        {
            myPassiveManager.ModifyCautious(myCharacterData.cautiousStacks);
        }
        if (myCharacterData.guardianAuraStacks > 0)
        {
            myPassiveManager.ModifyGuardianAura(myCharacterData.guardianAuraStacks);
        }
        if (myCharacterData.unwaveringStacks > 0)
        {
            myPassiveManager.ModifyUnwavering(myCharacterData.unwaveringStacks);
        }
        if (myCharacterData.fieryAuraStacks > 0)
        {
            myPassiveManager.ModifyFieryAura(myCharacterData.fieryAuraStacks);
        }
        if (myCharacterData.immolationStacks > 0)
        {
            myPassiveManager.ModifyImmolation(myCharacterData.immolationStacks);
        }
        if (myCharacterData.demonStacks > 0)
        {
            myPassiveManager.ModifyDemon(myCharacterData.demonStacks);
        }
        if (myCharacterData.shatterStacks > 0)
        {
            myPassiveManager.ModifyShatter(myCharacterData.shatterStacks);
        }
        if (myCharacterData.frozenHeartStacks > 0)
        {
            myPassiveManager.ModifyFrozenHeart(myCharacterData.frozenHeartStacks);
        }
        if (myCharacterData.predatorStacks > 0)
        {
            myPassiveManager.ModifyPredator(myCharacterData.predatorStacks);
        }
        if (myCharacterData.hawkEyeStacks > 0)
        {
            myPassiveManager.ModifyHawkEye(myCharacterData.hawkEyeStacks);
        }
        if (myCharacterData.thornsStacks > 0)
        {
            myPassiveManager.ModifyThorns(myCharacterData.thornsStacks);
        }
        if (myCharacterData.trueSightStacks > 0)
        {
            myPassiveManager.ModifyTrueSight(1);
        }
        if (myCharacterData.fluxStacks > 0)
        {
            myPassiveManager.ModifyFlux(myCharacterData.fluxStacks);
        }
        if (myCharacterData.quickDrawStacks > 0)
        {
            myPassiveManager.ModifyQuickDraw(myCharacterData.quickDrawStacks);
        }
        if (myCharacterData.phasingStacks > 0)
        {
            myPassiveManager.ModifyPhasing(myCharacterData.phasingStacks);
        }
        if (myCharacterData.etherealBeingStacks > 0)
        {
            myPassiveManager.ModifyEtherealBeing(myCharacterData.etherealBeingStacks);
        }
        if (myCharacterData.encouragingAuraStacks > 0)
        {
            myPassiveManager.ModifyEncouragingAura(myCharacterData.encouragingAuraStacks);
        }
        if (myCharacterData.radianceStacks > 0)
        {
            myPassiveManager.ModifyRadiance(myCharacterData.radianceStacks);
        }
        if (myCharacterData.sacredAuraStacks > 0)
        {
            myPassiveManager.ModifySacredAura(myCharacterData.sacredAuraStacks);
        }
        if (myCharacterData.shadowAuraStacks > 0)
        {
            myPassiveManager.ModifyShadowAura(myCharacterData.shadowAuraStacks);
        }
        if (myCharacterData.shadowFormStacks > 0)
        {
            myPassiveManager.ModifyShadowForm(myCharacterData.shadowFormStacks);
        }
        if (myCharacterData.poisonousStacks > 0)
        {
            myPassiveManager.ModifyPoisonous(myCharacterData.poisonousStacks);
        }
        if (myCharacterData.venomousStacks > 0)
        {
            myPassiveManager.ModifyVenomous(myCharacterData.venomousStacks);
        }
        if (myCharacterData.toxicityStacks > 0)
        {
            myPassiveManager.ModifyToxicity(myCharacterData.toxicityStacks);
        }
        if (myCharacterData.toxicAuraStacks > 0)
        {
            myPassiveManager.ModifyToxicAura(myCharacterData.toxicAuraStacks);
        }
        if (myCharacterData.stormAuraStacks > 0)
        {
            myPassiveManager.ModifyStormAura(myCharacterData.stormAuraStacks);
        }
        if (myCharacterData.stormLordStacks > 0)
        {
            myPassiveManager.ModifyStormLord(myCharacterData.stormLordStacks);
        }
        if (myCharacterData.fadingStacks > 0)
        {
            myPassiveManager.ModifyFading(myCharacterData.fadingStacks);
        }
        if (myCharacterData.lifeStealStacks > 0)
        {
            myPassiveManager.ModifyLifeSteal(myCharacterData.lifeStealStacks);
        }
        if (myCharacterData.growingStacks > 0)
        {
            myPassiveManager.ModifyGrowing(myCharacterData.growingStacks);
        }
        if (myCharacterData.fastLearnerStacks > 0)
        {
            myPassiveManager.ModifyFastLearner(myCharacterData.fastLearnerStacks);
        }
        if (myCharacterData.pierceStacks > 0)
        {
            myPassiveManager.ModifyPierce(myCharacterData.pierceStacks);
        }

        // Racial traits
        if (myCharacterData.forestWisdomStacks > 0)
        {
            myPassiveManager.ModifyForestWisdom(myCharacterData.forestWisdomStacks);
        }
        if (myCharacterData.satyrTrickeryStacks > 0)
        {
            myPassiveManager.ModifySatyrTrickery(myCharacterData.satyrTrickeryStacks);
        }
        if (myCharacterData.humanAmbitionStacks > 0)
        {
            myPassiveManager.ModifyHumanAmbition(myCharacterData.humanAmbitionStacks);
        }
        if (myCharacterData.orcishGritStacks > 0)
        {
            myPassiveManager.ModifyOrcishGrit(myCharacterData.orcishGritStacks);
        }
        if (myCharacterData.gnollishBloodLustStacks > 0)
        {
            myPassiveManager.ModifyGnollishBloodLust(myCharacterData.gnollishBloodLustStacks);
        }
        if (myCharacterData.freeFromFleshStacks > 0)
        {
            myPassiveManager.ModifyFreeFromFlesh(myCharacterData.freeFromFleshStacks);
        }
       

        // Set Weapons from character data
        ItemManager.Instance.SetUpDefenderWeaponsFromCharacterData(this);

    }    
   
    #endregion

    // Mouse + Click Events
    #region
    public void OnMouseDown()
    {
        Defender selectedDefender = DefenderManager.Instance.selectedDefender;

        // this statment prevents the user from clicking through UI elements and selecting a defender
        if (!EventSystem.current.IsPointerOverGameObject() == false &&
             ActivationManager.Instance.panelIsMousedOver == false)
        {
            Debug.Log("Clicked on the UI, returning...");
            return;
        }

        // Check for consumable orders first
        if (ConsumableManager.Instance.awaitingAdrenalinePotionTarget ||
            ConsumableManager.Instance.awaitingBottledBrillianceTarget ||
            ConsumableManager.Instance.awaitingBottledMadnessTarget ||
            ConsumableManager.Instance.awaitingPotionOfMightTarget ||
            ConsumableManager.Instance.awaitingPotionOfClarityTarget ||
            ConsumableManager.Instance.awaitingVanishPotionTarget)
        {
            ConsumableManager.Instance.ApplyConsumableToTarget(this);
        }

        else if (ConsumableManager.Instance.awaitingFireBombTarget ||
            ConsumableManager.Instance.awaitingDynamiteTarget ||
            ConsumableManager.Instance.awaitingPoisonGrenadeTarget ||
            ConsumableManager.Instance.awaitingBottledFrostTarget)
        {
            ConsumableManager.Instance.ApplyConsumableToTarget(tile);
        }

        else if (ConsumableManager.Instance.awaitingBlinkPotionCharacterTarget)
        {
            ConsumableManager.Instance.StartBlinkPotionLocationSettingProcess(this);
        }

        // Check ability orders second
        else if (selectedDefender != null && selectedDefender.awaitingGoBerserkOrder)
        {
            selectedDefender.StartGoBerserkProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingInspireOrder)
        {
            selectedDefender.StartInspireProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingIcyFocusOrder)
        {
            selectedDefender.StartIcyFocusProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingDarkGiftOrder)
        {
            selectedDefender.StartDarkGiftProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingStoneFormOrder)
        {
            selectedDefender.StartStoneFormProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingTranscendenceOrder)
        {
            selectedDefender.StartTranscendenceProcess(this);
            return;
        }        
        else if (selectedDefender != null && selectedDefender.awaitingTimeWarpOrder)
        {
            selectedDefender.StartTimeWarpProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingDragonBreathOrder)
        {
            selectedDefender.StartDragonBreathProcess(tile);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingSpiritVisionOrder)
        {
            selectedDefender.StartSpiritVisionProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingShroudOrder)
        {
            selectedDefender.StartShroudProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingHasteOrder)
        {
            selectedDefender.StartHasteProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingSteadyHandsOrder)
        {
            selectedDefender.StartSteadyHandsProcess(this);
            return;
        }

        else if (selectedDefender != null && selectedDefender.awaitingGuardOrder)
        {
            selectedDefender.StartGuardProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingFortifyOrder)
        {
            selectedDefender.StartFortifyProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingTelekinesisTargetOrder)
        {
            selectedDefender.StartTelekinesisLocationSettingProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingBurstOfKnowledgeOrder)
        {
            selectedDefender.StartBurstOfKnowledgeProcess(this);
            return;
        }

        else if (selectedDefender != null && selectedDefender.awaitingForestMedicineOrder)
        {
            selectedDefender.StartForestMedicineProcess(this);
            return;
        }

        else if (selectedDefender != null && selectedDefender.awaitingFrostArmourOrder)
        {
            selectedDefender.StartFrostArmourProcess(this);
            return;
        }

        else if (selectedDefender != null && selectedDefender.awaitingInvigorateOrder)
        {
            selectedDefender.StartInvigorateProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingBlazeOrder)
        {
            selectedDefender.StartBlazeProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingOverloadOrder)
        {
            selectedDefender.StartOverloadProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingCreepingFrostOrder)
        {
            selectedDefender.StartCreepingFrostProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingShadowWreathOrder)
        {
            selectedDefender.StartShadowWreathProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingSnowStasisOrder)
        {
            selectedDefender.StartSnowStasisProcess(this);
            return;
        }
        
        else if (selectedDefender != null && selectedDefender.awaitingHolyFireOrder)
        {
            selectedDefender.StartHolyFireProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingPrimalRageOrder)
        {
            selectedDefender.StartPrimalRageProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingPhaseShiftOrder)
        {
            selectedDefender.StartPhaseShiftProcess(this);
            return;
        }        
        else if (selectedDefender != null && selectedDefender.awaitingBlessOrder)
        {
            selectedDefender.StartBlessProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingEvasionOrder)
        {
            selectedDefender.StartEvasionProcess(this);
            return;
        }
        else if (selectedDefender != null && selectedDefender.awaitingMirageOrder)
        {
            selectedDefender.StartMirageProcess(this);
            return;
        }

        else
        {
            Debug.Log("Defender selection attempt detected");
            SelectDefender();            
        }

    }
    public void SelectDefender()
    {
        DefenderManager.Instance.SetSelectedDefender(this);
        myUIParent.SetActive(true);
        StartCoroutine(FadeInUICanvas());
    }
    public void UnselectDefender()
    {
        ClearAllOrders();
        StartCoroutine(FadeOutUICanvas());
    }
    public void ClearAllOrders()
    {
        awaitingAnOrder = false;

        awaitingMoveOrder = false;
        awaitingStrikeOrder = false;
        awaitingChargeTargetOrder = false;
        awaitingChargeLocationOrder = false;
        awaitingInspireOrder = false;
        awaitingGuardOrder = false;
        awaitingShootOrder = false;
        awaitingMeteorOrder = false;
        awaitingTelekinesisTargetOrder = false;
        awaitingTelekinesisLocationOrder = false;
        awaitingFrostBoltOrder = false;
        awaitingFireBallOrder = false;
        awaitingRapidFireOrder = false;
        awaitingImpalingBoltOrder = false;
        awaitingForestMedicineOrder = false;
        awaitingInvigorateOrder = false;
        awaitingHolyFireOrder = false;
        awaitingVoidBombOrder = false;
        awaitingNightmareOrder = false;
        awaitingTwinStrikeOrder = false;
        awaitingDashOrder = false;
        awaitingSliceAndDiceOrder = false;
        awaitingPoisonDartOrder = false;
        awaitingChemicalReactionOrder = false;
        awaitingGetDownOrder = false;
        awaitingSmashOrder = false;
        awaitingLightningShieldOrder = false;
        awaitingChainLightningOrder = false;
        awaitingPrimalBlastOrder = false;
        awaitingPrimalRageOrder = false;
        awaitingPhaseShiftOrder = false;
        awaitingSanctityOrder = false;
        awaitingBlessOrder = false;
        awaitingSiphonLifeOrder = false;
        awaitingChaosBoltOrder = false;
        awaitingKickToTheBallsOrder = false;
        awaitingDevastatingBlowOrder = false;
        awaitingBladeFlurryOrder = false;
        awaitingEvasionOrder = false;
        awaitingShieldSlamOrder = false;
        awaitingTendonSlashOrder = false;
        awaitingShieldShatterOrder = false;
        awaitingSwordAndBoardOrder = false;
        awaitingPhoenixDiveOrder = false;
        awaitingChillingBlowOrder = false;
        awaitingIcyFocusOrder = false;
        awaitingCombustionOrder = false;
        awaitingDragonBreathOrder = false;
        awaitingBlizzardOrder = false;
        awaitingFrostArmourOrder = false;
        awaitingThawOrder = false;
        awaitingSnipeOrder = false;
        awaitingHasteOrder = false;
        awaitingSteadyHandsOrder = false;
        awaitingTreeLeapOrder = false;
        awaitingDimensionalBlastOrder = false;
        awaitingMirageOrder = false;
        awaitingBurstOfKnowledgeOrder = false;
        awaitingBlinkOrder = false;
        awaitingTimeWarpOrder = false;
        awaitingDimensionalHexOrder = false;
        awaitingBlindingLightOrder = false;
        awaitingTranscendenceOrder = false;
        awaitingJudgementOrder = false;
        awaitingShroudOrder = false;
        awaitingRainOfChaosOrder = false;
        awaitingBlightOrder = false;
        awaitingToxicSlashOrder = false;
        awaitingToxicEruptionOrder = false;
        awaitingDrainOrder = false;
        awaitingLightningBoltOrder = false;
        awaitingThunderStrikeOrder = false;
        awaitingSpiritVisionOrder = false;
        awaitingThunderStormOrder = false;
        awaitingConcealingCloudsOrder = false;
        awaitingHeadShotOrder = false;
        awaitingHexOrder = false;
        awaitingShankOrder = false;
        awaitingCheapShotOrder = false;
        awaitingAmbushOrder = false;
        awaitingShadowStepOrder = false;
        awaitingProvokeOrder = false;
        awaitingDecapitateOrder = false;
        awaitingDisarmOrder = false;
        awaitingShadowBlastOrder = false;
        awaitingGoBerserkOrder = false;
        awaitingFortifyOrder = false;
        awaitingStoneFormOrder = false;
        awaitingBackStabOrder = false;
        awaitingChloroformBombOrder = false;
        awaitingPinningShotOrder = false;
        awaitingMarkTargetOrder = false;
        awaitingSnowStasisOrder = false;
        awaitingShadowWreathOrder = false;
        awaitingBlazeOrder = false;
        awaitingCreepingFrostOrder = false;
        awaitingOverloadOrder = false;
        awaitingDarkGiftOrder = false;
        awaitingSuperConductorOrder = false;
        awaitingMeltOrder = false;
        awaitingRamOrder = false;
        awaitingDisengageOrder = false;

        TileHover.Instance.SetVisibility(false);
        LevelManager.Instance.UnhighlightAllTiles();
        PathRenderer.Instance.DeactivatePathRenderer();
        TargetingPathRenderer.Instance.DeactivatePathRenderer();
        InstructionHover.Instance.DisableInstructionHover();

        myCurrentTarget = null;
    }
    #endregion

    // Ability Button Click Events
    #region
    public bool IsAwaitingOrder()
    {
        return awaitingAnOrder;
    }
    public void OnAbilityButtonClicked(string abilityName)
    {
        // Prevent player from using character abilities when it is not their turn
        if(ActivationManager.Instance.IsEntityActivated(this) == false)
        {
            // to do in future: warning message to player here "Not this characters activation!"
            InvalidActionManager.Instance.ShowNewErrorMessage("It is not this character's activation.");
            return;
        }

        // Prevent player from making moves while there are unresolved ability events
        if (ActionManager.Instance.UnresolvedCombatActions())
        {
            Debug.Log("Defender.OnAbilityButtonClicked() cancelling: there are unresolved combat events in the Action queue");
            return;
        }

        // Clear all previous view settings and defender orders
        bool enableTileHover = true;        
        LevelManager.Instance.UnhighlightAllTiles();
        ClearAllOrders();
        awaitingAnOrder = true;
        ConsumableManager.Instance.ClearAllConsumableOrders();

        // Enable tile hover if ability is usable, and requires targetting
        Ability ability = mySpellBook.GetAbilityByName(abilityName);
        if (!EntityLogic.IsAbilityUseable(this, ability))
        {
            awaitingAnOrder = false;
            enableTileHover = false;
        }
        if(
            (ability.abilityName == "Move" ||
            ability.abilityName == "Charge" ||
            ability.abilityName == "Dash" ||
            ability.abilityName == "Get Down!") &&
            !EntityLogic.IsAbleToMove(this)
            )
        {
            awaitingAnOrder = false;
            enableTileHover = false;
        }

        if (EntityLogic.IsAbleToTakeActions(this) == false)
        {
            awaitingAnOrder = false;
            TileHover.Instance.SetVisibility(false);
            return;
        }

        else if (abilityName == "Move")
        {
            OnMoveButtonClicked();
        }
        else if (abilityName == "Strike")
        {
            OnStrikeButtonClicked();
        }
        else if (abilityName == "Disarm")
        {
            OnDisarmButtonClicked();
        }
        else if (abilityName == "Back Stab")
        {
            OnBackStabButtonClicked();
        }
        else if (abilityName == "Defend")
        {
            OnDefendButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        
        else if (abilityName == "Frost Armour")
        {
            OnFrostArmourButtonClicked();
        }
        else if (abilityName == "Transcendence")
        {
            OnTranscendenceButtonClicked();
        }
        else if (abilityName == "Glacial Burst")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnGlacialBurstButtonClicked();
        }
        else if (abilityName == "Challenging Shout")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnChallengingShoutButtonClicked();
        }
        else if (abilityName == "Thaw")
        {
            OnThawButtonClicked();
        }
        else if (abilityName == "Blizzard")
        {
            OnBlizzardButtonClicked();
        }
        else if (abilityName == "Snipe")
        {
            OnSnipeButtonClicked();
        }
        else if (abilityName == "Haste")
        {
            OnHasteButtonClicked();
        }
        else if (abilityName == "Steady Hands")
        {
            OnSteadyHandsButtonClicked();
        }
        else if (abilityName == "Head Shot")
        {
            OnHeadShotButtonClicked();
        }
        else if (abilityName == "Combustion")
        {
            OnCombustionButtonClicked();
        }
        else if (abilityName == "Forest Medicine")
        {
            OnForestMedicineButtonClicked();
        }
        else if (abilityName == "Tree Leap")
        {
            OnTreeLeapButtonClicked();
        }
        else if (abilityName == "Rapid Fire")
        {
            OnRapidFireButtonClicked();
        }
        else if (abilityName == "Overwatch")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnOverwatchButtonClicked();
        }
        else if (abilityName == "Moon Infusion")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnMoonInfusionButtonClicked();
        }
        else if (abilityName == "Dimensional Blast")
        {
            OnDimensionalBlastButtonClicked();
        }
        else if (abilityName == "Mirage")
        {
            OnMirageButtonClicked();
        }
        else if (abilityName == "Burst Of Knowledge")
        {
            OnBurstOfKnowledgeButtonClicked();
        }
        else if (abilityName == "Blink")
        {
            OnBlinkButtonClicked();
        }
        else if (abilityName == "Disengage")
        {
            OnDisengageButtonClicked();
        }
        else if (abilityName == "Time Warp")
        {
            OnTimeWarpButtonClicked();
        }
        else if (abilityName == "Dimensional Hex")
        {
            OnDimensionalHexButtonClicked();
        }
        else if (abilityName == "Consecrate")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnConsecrateButtonClicked();
        }
        else if (abilityName == "Blinding Light")
        {
            OnBlindingLightButtonClicked();
        }
        else if (abilityName == "Transcendence")
        {
            //OnTranscendenceButtonClicked();
        }
        else if (abilityName == "Judgement")
        {
            OnJudgementButtonClicked();
        }
        else if (abilityName == "Shroud")
        {
            OnShroudButtonClicked();
        }
        else if (abilityName == "Hex")
        {
            OnHexButtonClicked();
        }
        else if (abilityName == "Mark Target")
        {
            OnMarkTargetButtonClicked();
        }
        else if (abilityName == "Rain Of Chaos")
        {
            OnRainOfChaosButtonClicked();
        }
        else if (abilityName == "Unbridled Chaos")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnUnbridledChaosButtonClicked();
        }
        else if (abilityName == "Blight")
        {
            OnBlightButtonClicked();
        }
        else if (abilityName == "Provoke")
        {
            OnProvokeButtonClicked();
        }
        else if (abilityName == "Blood Offering")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnBloodOfferingButtonClicked();
        }
        else if (abilityName == "Frenzy")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnFrenzyButtonClicked();
        }
        else if (abilityName == "Horrify")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnHorrifyButtonClicked();
        }
        else if (abilityName == "Toxic Slash")
        {
            OnToxicSlashButtonClicked();
        }
        else if (abilityName == "Decapitate")
        {
            OnDecapitateButtonClicked();
        }
        else if (abilityName == "Cheap Shot")
        {
            OnCheapShotButtonClicked();
        }
        else if (abilityName == "Shank")
        {
            OnShankButtonClicked();
        }
        else if (abilityName == "Shadow Step")
        {
            OnShadowStepButtonClicked();
        }
        else if (abilityName == "Ambush")
        {
            OnAmbushButtonClicked();
        }
        else if (abilityName == "Sharpen Blade")
        {
            OnSharpenBladeButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Noxious Fumes")
        {
            enableTileHover = false;
            awaitingAnOrder = false;
            OnNoxiousFumesButtonClicked();
        }
        else if (abilityName == "Toxic Eruption")
        {
            OnToxicEruptionButtonClicked();
        }
        else if (abilityName == "Drain")
        {
            OnDrainButtonClicked();
        }
        
        else if (abilityName == "Lightning Bolt")
        {
            OnLightningBoltButtonClicked();
        }
        else if (abilityName == "Thunder Strike")
        {
            OnThunderStrikeButtonClicked();
        }
        else if (abilityName == "Spirit Vision")
        {
            OnSpiritVisionButtonClicked();
        }
        else if (abilityName == "Dragon Breath")
        {
            OnDragonBreathButtonClicked();
        }
        else if (abilityName == "Thunder Storm")
        {
            OnThunderStormButtonClicked();
        }
        else if (abilityName == "Concealing Clouds")
        {
            OnConcealingCloudsButtonClicked();
        }
        else if (abilityName == "Super Conductor")
        {
            OnSuperConductorButtonClicked();
        }       
       
        else if (abilityName == "Charge")
        {
            OnChargeButtonClicked();
        }
        else if (abilityName == "Go Berserk")
        {
            OnGoBerserkButtonClicked();
        }
        else if (abilityName == "Inspire")
        {
            OnInspireButtonClicked();
        }
        else if (abilityName == "Icy Focus")
        {
            OnIcyFocusButtonClicked();
        }
        else if (abilityName == "Stone Form")
        {
            OnStoneFormButtonClicked();
        }
        else if (abilityName == "Dark Gift")
        {
            OnDarkGiftButtonClicked();
        }
        else if (abilityName == "Guard")
        {
            OnGuardButtonClicked();
        }
        else if (abilityName == "Fortify")
        {
            OnFortifyButtonClicked();
        }
        else if (abilityName == "Meteor")
        {
            OnMeteorButtonClicked();
        }
        else if (abilityName == "Chloroform Bomb")
        {
            OnChloroformBombButtonClicked();
        }
        else if (abilityName == "Blinding Light")
        {
            OnBlindingLightButtonClicked();
        }
        else if (abilityName == "Toxic Eruption")
        {
            OnToxicEruptionButtonClicked();
        }
        else if (abilityName == "Thunder Storm")
        {
            OnThunderStormButtonClicked();
        }
        else if (abilityName == "Rain Of Chaos")
        {
            OnRainOfChaosButtonClicked();
        }
        else if (abilityName == "Telekinesis")
        {
            OnTelekinesisButtonClicked();
        }
        else if (abilityName == "Frost Bolt")
        {
            OnFrostBoltButtonClicked();
        }
        else if (abilityName == "Fire Ball")
        {
            OnFireBallButtonClicked();
        }
        else if (abilityName == "Melt")
        {
            OnMeltButtonClicked();
        }
        else if (abilityName == "Shadow Blast")
        {
            OnShadowBlastButtonClicked();
        }
        else if (abilityName == "Thaw")
        {
            OnThawButtonClicked();
        }
        else if (abilityName == "Shoot")
        {
            OnShootButtonClicked();
        }
        else if (abilityName == "Pinning Shot")
        {
            OnPinningShotButtonClicked();
        }
        else if (abilityName == "Impaling Bolt")
        {
            OnImpalingBoltButtonClicked();
        }        
        else if (abilityName == "Whirlwind")
        {
            OnWhirlwindButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Spirit Surge")
        {
            OnSpritSurgeButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Encourage")
        {
            OnEncourageButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Toxic Rain")
        {
            OnToxicRainButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Pure Hate")
        {
            OnPureHateButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Global Cooling")
        {
            OnGlobalCoolingButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Second Wind")
        {
            OnSecondWindButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Infuse")
        {
            OnInfuseButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Purity")
        {
            OnPurityButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Shadow Wreath")
        {
            OnShadowWreathButtonClicked();
        }
        else if (abilityName == "Overload")
        {
            OnOverloadButtonClicked();
        }
        else if (abilityName == "Recklessness")
        {
            OnRecklessnessButtonClicked();
        }
        else if (abilityName == "Rapid Cloaking")
        {
            OnRapidCloakingButtonClicked();
        }
        else if (abilityName == "Concentration")
        {
            OnConcentrationButtonClicked();
        }
        else if (abilityName == "Testudo")
        {
            OnTestudoButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Blaze")
        {
            OnBlazeButtonClicked();
        }
        else if (abilityName == "Creeping Frost")
        {
            OnCreepingFrostButtonClicked();
        }
        else if (abilityName == "Shadow Wreath")
        {
            OnShadowWreathButtonClicked();
        }
        else if (abilityName == "Overload")
        {
            OnOverloadButtonClicked();
        }
        else if (abilityName == "Fire Nova")
        {
            OnFireNovaButtonClicked();
            enableTileHover = false;
        }
        else if (abilityName == "Frost Nova")
        {
            OnFrostNovaButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Reactive Armour")
        {
            OnReactiveArmourButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Vanish")
        {
            OnVanishButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }       

        else if (abilityName == "Invigorate")
        {
            OnInvigorateButtonClicked();
        }
        else if (abilityName == "Snow Stasis")
        {
            OnSnowStasisButtonClicked();
        }

        else if (abilityName == "Holy Fire")
        {
            OnHolyFireButtonClicked();
        }

        else if (abilityName == "Void Bomb")
        {
            OnVoidBombButtonClicked();
        }

        else if (abilityName == "Nightmare")
        {
            OnNightmareButtonClicked();
        }

        else if (abilityName == "Twin Strike")
        {
            OnTwinStrikeButtonClicked();
        }
        else if (abilityName == "Shield Slam")
        {
            OnShieldSlamButtonClicked();
        }

        else if (abilityName == "Dash")
        {
            OnDashButtonClicked();
        }
        else if (abilityName == "Phoenix Dive")
        {
            OnPhoenixDiveButtonClicked();
        }

        else if (abilityName == "Preparation")
        {
            OnPreparationButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }

        else if (abilityName == "Slice And Dice")
        {
            OnSliceAndDiceButtonClicked();
        }

        else if (abilityName == "Poison Dart")
        {
            OnPoisonDartButtonClicked();
        }
        else if (abilityName == "Chemical Reaction")
        {
            OnChemicalReactionButtonClicked();
        }       
        else if (abilityName == "Get Down!")
        {
            OnGetDownButtonClicked();
        }
        else if (abilityName == "Smash")
        {
            OnSmashButtonClicked();
        }
        else if (abilityName == "Lightning Shield")
        {
            OnLightningShieldClicked();
        }

        else if (abilityName == "Electrical Discharge")
        {
            OnElectricalDischargeButtonClicked();
        }
        else if (abilityName == "Chain Lightning")
        {
            OnChainLightningButtonClicked();
        }

        else if (abilityName == "Primal Blast")
        {
            OnPrimalBlastButtonClicked();
        }

        else if (abilityName == "Primal Rage")
        {
            OnPrimalRageButtonClicked();
        }       
        else if (abilityName == "Phase Shift")
        {
            OnPhaseShiftButtonClicked();
        }
        else if (abilityName == "Sanctity")
        {
            OnSanctityButtonClicked();
        }
        else if (abilityName == "Bless")
        {
            OnBlessButtonClicked();
        }
        else if (abilityName == "Siphon Life")
        {
            OnSiphonLifeButtonClicked();
        }
        else if (abilityName == "Chaos Bolt")
        {
            OnChaosBoltButtonClicked();
        }
        else if (abilityName == "Blade Flurry")
        {
            OnBladeFlurryButtonClicked();
            enableTileHover = false;
            awaitingAnOrder = false;
        }
        else if (abilityName == "Kick To The Balls")
        {
            OnKickToTheBallsButtonClicked();
        }
        else if (abilityName == "Ram")
        {
            OnRamButtonClicked();
        }
        else if (abilityName == "Devastating Blow")
        {
            OnDevastatingBlowButtonClicked();
        }
        else if (abilityName == "Evasion")
        {
            OnEvasionButtonClicked();
        }
        else if (abilityName == "Tendon Slash")
        {
            OnTendonSlashButtonClicked();
        }
        else if (abilityName == "Chilling Blow")
        {
            OnChillingBlowButtonClicked();
        }
        else if (abilityName == "Shield Shatter")
        {
            OnShieldShatterButtonClicked();
        }
        else if (abilityName == "Sword And Board")
        {
            OnSwordAndBoardButtonClicked();
        }
        else if (abilityName == "Shield Slam")
        {
            OnShieldSlamButtonClicked();
        }

        if (enableTileHover)
        {
            TileHover.Instance.SetVisibility(true);

            if(
            ability.abilityName != "Move" &&
            ability.abilityName != "Dash" &&
            ability.abilityName != "Get Down!"
                )
            {
                TargetingPathRenderer.Instance.ActivatePathRenderer();
            }

            
        }
        else if (!enableTileHover)
        {
            TileHover.Instance.SetVisibility(false);
        }
    }
    public void OnMoveButtonClicked()
    {
        Ability move = mySpellBook.GetAbilityByName("Move");

        if(EntityLogic.IsAbleToMove(this) &&
           EntityLogic.IsAbilityUseable(this, move))
        {
            Debug.Log("Move button clicked, awaiting move order");
            awaitingMoveOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetValidMoveableTilesWithinRange(EntityLogic.GetTotalMobility(this), tile));
            PathRenderer.Instance.ActivatePathRenderer();
            InstructionHover.Instance.EnableInstructionHover("Choose a tile");
        }

        
    }
    public void OnStrikeButtonClicked()
    {
        Ability strike = mySpellBook.GetAbilityByName("Strike");

        if (EntityLogic.IsAbilityUseable(this, strike))
        {
            Debug.Log("Strike button clicked, awaiting strike order");
            awaitingStrikeOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }       

    }
    public void OnBackStabButtonClicked()
    {
        Ability backStab = mySpellBook.GetAbilityByName("Back Stab");

        if (EntityLogic.IsAbilityUseable(this, backStab))
        {
            Debug.Log("Back Stab button clicked, awaiting Back Stab order");
            awaitingBackStabOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnDisarmButtonClicked()
    {
        Ability disarm = mySpellBook.GetAbilityByName("Disarm");

        if (EntityLogic.IsAbilityUseable(this, disarm))
        {
            Debug.Log("Disarm button clicked, awaiting disarm order");
            awaitingDisarmOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnSmashButtonClicked()
    {
        Ability smash = mySpellBook.GetAbilityByName("Smash");

        if (EntityLogic.IsAbilityUseable(this, smash))
        {
            Debug.Log("Smash button clicked, awaiting smash order");
            awaitingSmashOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }       

    }
    public void OnInspireButtonClicked()
    {
        Ability inspire = mySpellBook.GetAbilityByName("Inspire");

        if (EntityLogic.IsAbilityUseable(this, inspire))
        {
            Debug.Log("Inspire button clicked, awaiting inspire order");
            awaitingInspireOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(inspire.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }        
    }
    public void OnBlazeButtonClicked()
    {
        Ability blaze = mySpellBook.GetAbilityByName("Blaze");

        if (EntityLogic.IsAbilityUseable(this, blaze))
        {
            Debug.Log("Blaze button clicked, awaiting Blaze order");
            awaitingBlazeOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(blaze.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnCreepingFrostButtonClicked()
    {
        Ability creepingFrost = mySpellBook.GetAbilityByName("Creeping Frost");

        if (EntityLogic.IsAbilityUseable(this, creepingFrost))
        {
            Debug.Log("Creeping Frost button clicked, awaiting Creeping Frost order");
            awaitingCreepingFrostOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(creepingFrost.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnShadowWreathButtonClicked()
    {
        Ability shadowWreath = mySpellBook.GetAbilityByName("Shadow Wreath");

        if (EntityLogic.IsAbilityUseable(this, shadowWreath))
        {
            Debug.Log("Shadow Wreath button clicked, awaiting Shadow Wreath order");
            awaitingShadowWreathOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(shadowWreath.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnOverloadButtonClicked()
    {
        Ability overload = mySpellBook.GetAbilityByName("Overload");

        if (EntityLogic.IsAbilityUseable(this, overload))
        {
            Debug.Log("Overload button clicked, awaiting Overload order");
            awaitingOverloadOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(overload.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnGoBerserkButtonClicked()
    {
        Ability goBerserk = mySpellBook.GetAbilityByName("Go Berserk");

        if (EntityLogic.IsAbilityUseable(this, goBerserk))
        {
            Debug.Log("Go Berserk button clicked, awaiting Go Berserk order");
            awaitingGoBerserkOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(goBerserk.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }   
    public void OnSpiritVisionButtonClicked()
    {
        Ability spiritVision = mySpellBook.GetAbilityByName("Spirit Vision");

        if (EntityLogic.IsAbilityUseable(this, spiritVision))
        {
            Debug.Log("Spirit Vision button clicked, awaiting Spirit Vision order");
            awaitingSpiritVisionOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(spiritVision.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnDragonBreathButtonClicked()
    {
        Ability dragonBreath = mySpellBook.GetAbilityByName("Dragon Breath");

        if (EntityLogic.IsAbilityUseable(this, dragonBreath))
        {
            Debug.Log("Dragon Breath button clicked, awaiting Dragon Breath order");
            awaitingDragonBreathOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(dragonBreath.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile");
        }
    }
    public void OnShroudButtonClicked()
    {
        Ability shroud = mySpellBook.GetAbilityByName("Shroud");

        if (EntityLogic.IsAbilityUseable(this, shroud))
        {
            Debug.Log("Shroud button clicked, awaiting Shroud order");
            awaitingShroudOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(shroud.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnHexButtonClicked()
    {
        Ability hex = mySpellBook.GetAbilityByName("Hex");

        if (EntityLogic.IsAbilityUseable(this, hex))
        {
            Debug.Log("Hex button clicked, awaiting Hex order");
            awaitingHexOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(hex.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnMarkTargetButtonClicked()
    {
        Ability mt = mySpellBook.GetAbilityByName("Mark Target");

        if (EntityLogic.IsAbilityUseable(this, mt))
        {
            Debug.Log("Mark Target button clicked, awaiting Mark Target order");
            awaitingMarkTargetOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(mt.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnIcyFocusButtonClicked()
    {
        Ability icyFocus = mySpellBook.GetAbilityByName("Icy Focus");

        if (EntityLogic.IsAbilityUseable(this, icyFocus))
        {
            Debug.Log("Icy Focus button clicked, awaiting Icy Focus order");
            awaitingIcyFocusOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(icyFocus.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnDarkGiftButtonClicked()
    {
        Ability darkGift = mySpellBook.GetAbilityByName("Dark Gift");

        if (EntityLogic.IsAbilityUseable(this, darkGift))
        {
            Debug.Log("Dark Gift button clicked, awaiting Dark Gift order");
            awaitingDarkGiftOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(darkGift.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnStoneFormButtonClicked()
    {
        Ability stoneForm = mySpellBook.GetAbilityByName("Stone Form");

        if (EntityLogic.IsAbilityUseable(this, stoneForm))
        {
            Debug.Log("Stone Form button clicked, awaiting Stone Form order");
            awaitingStoneFormOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(stoneForm.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnChargeButtonClicked()
    {
        Ability charge = mySpellBook.GetAbilityByName("Charge");

        if (EntityLogic.IsAbilityUseable(this, charge) &&
            EntityLogic.IsAbleToMove(this))           
        {
            Debug.Log("Charge button clicked, awaiting charge target");
            awaitingChargeTargetOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(charge.abilityPrimaryValue + EntityLogic.GetTotalMobility(this), LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }      

    }
    public void OnGetDownButtonClicked()
    {
        Ability getDown = mySpellBook.GetAbilityByName("Get Down!");

        if (EntityLogic.IsAbilityUseable(this, getDown) &&
            EntityLogic.IsAbleToMove(this))            
        {
            Debug.Log("Get Down! button clicked, awaiting Get Down! target");
            awaitingGetDownOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetValidMoveableTilesWithinRange(getDown.abilityPrimaryValue + EntityLogic.GetTotalMobility(this), LevelManager.Instance.Tiles[gridPosition]));
            PathRenderer.Instance.ActivatePathRenderer();
            InstructionHover.Instance.EnableInstructionHover("Choose a tile");
        }        

    }
    public void OnLightningShieldClicked()
    {
        Ability lightningShield = mySpellBook.GetAbilityByName("Lightning Shield");

        if (EntityLogic.IsAbilityUseable(this, lightningShield))
        {
            Debug.Log("Lightning Shield button clicked, awaiting Lightning Shield target");
            awaitingLightningShieldOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(lightningShield.abilityRange, LevelManager.Instance.Tiles[gridPosition],true, false));
        }
    }
    public void OnGuardButtonClicked()
    {
        Ability guard = mySpellBook.GetAbilityByName("Guard");

        if (EntityLogic.IsAbilityUseable(this, guard))
        {
            Debug.Log("Guard button clicked, awaiting guard target");
            awaitingGuardOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(guard.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }        
    }
    public void OnFortifyButtonClicked()
    {
        Ability fortify = mySpellBook.GetAbilityByName("Fortify");

        if (EntityLogic.IsAbilityUseable(this, fortify))
        {
            Debug.Log("Fortify button clicked, awaiting Fortify target");
            awaitingFortifyOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(fortify.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnForestMedicineButtonClicked()
    {
        Ability forestMedicine = mySpellBook.GetAbilityByName("Forest Medicine");

        if (EntityLogic.IsAbilityUseable(this, forestMedicine))
        {
            Debug.Log("Forest Medicine button clicked, awaiting forest medicine target");
            awaitingForestMedicineOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(forestMedicine.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnTreeLeapButtonClicked()
    {
        Ability treeLeap = mySpellBook.GetAbilityByName("Tree Leap");

        if (EntityLogic.IsAbilityUseable(this, treeLeap))
        {
            Debug.Log("Tree Leap button clicked, awaiting Tree Leap target");
            awaitingTreeLeapOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(treeLeap.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a grass tile");
        }
    }
    public void OnFrostArmourButtonClicked()
    {
        Ability frostArmour = mySpellBook.GetAbilityByName("Frost Armour");

        if (EntityLogic.IsAbilityUseable(this, frostArmour))
        {
            Debug.Log("Frost Armour button clicked, awaiting Frost Armour target");
            awaitingFrostArmourOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(frostArmour.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnTranscendenceButtonClicked()
    {
        Ability transcendence = mySpellBook.GetAbilityByName("Transcendence");

        if (EntityLogic.IsAbilityUseable(this, transcendence))
        {
            Debug.Log("Transcendence button clicked, awaiting Transcendence target");
            awaitingTranscendenceOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(transcendence.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnMeteorButtonClicked()
    {
        Ability meteor = mySpellBook.GetAbilityByName("Meteor");

        if (EntityLogic.IsAbilityUseable(this, meteor))
        {
            Debug.Log("Meteor button clicked, awaiting Meteor target");
            awaitingMeteorOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, meteor), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile or enemy");
        }
    }
    public void OnChloroformBombButtonClicked()
    {
        Ability cb = mySpellBook.GetAbilityByName("Chloroform Bomb");

        if (EntityLogic.IsAbilityUseable(this, cb))
        {
            Debug.Log("Chloroform Bomb button clicked, awaiting Chloroform Bomb target");
            awaitingChloroformBombOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, cb), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile or enemy");
        }
    }
    public void OnBlizzardButtonClicked()
    {
        Ability blizzard = mySpellBook.GetAbilityByName("Blizzard");

        if (EntityLogic.IsAbilityUseable(this, blizzard))
        {
            Debug.Log("Blizzard button clicked, awaiting Blizzard target");
            awaitingBlizzardOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, blizzard), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile or enemy");
        }        
    }
    public void OnBlindingLightButtonClicked()
    {
        Ability blindingLight = mySpellBook.GetAbilityByName("Blinding Light");

        if (EntityLogic.IsAbilityUseable(this, blindingLight))
        {
            Debug.Log("Blinding Light button clicked, awaiting Blinding Light target");
            awaitingBlindingLightOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, blindingLight), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile or enemy");
        }
    }
    public void OnToxicEruptionButtonClicked()
    {
        Ability toxicEruption = mySpellBook.GetAbilityByName("Toxic Eruption");

        if (EntityLogic.IsAbilityUseable(this, toxicEruption))
        {
            Debug.Log("Toxic Eruption button clicked, awaiting Toxic Eruption target");
            awaitingToxicEruptionOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this,toxicEruption), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile or enemy");
        }
    }
    public void OnDrainButtonClicked()
    {
        Ability drain = mySpellBook.GetAbilityByName("Drain");

        if (EntityLogic.IsAbilityUseable(this, drain))
        {
            Debug.Log("Drain button clicked, awaiting Drain target");
            awaitingDrainOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(drain.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnLightningBoltButtonClicked()
    {
        Ability lightningBolt = mySpellBook.GetAbilityByName("Lightning Bolt");

        if (EntityLogic.IsAbilityUseable(this, lightningBolt))
        {
            Debug.Log("Lightning Bolt clicked, awaiting Lightning Bolt target");
            awaitingLightningBoltOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, lightningBolt), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnSuperConductorButtonClicked()
    {
        Ability superConductor = mySpellBook.GetAbilityByName("Super Conductor");

        if (EntityLogic.IsAbilityUseable(this, superConductor))
        {
            Debug.Log("Super Conductor clicked, awaiting Super Conductor target");
            awaitingSuperConductorOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, superConductor), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnRainOfChaosButtonClicked()
    {
        Ability rainOfChaos = mySpellBook.GetAbilityByName("Rain Of Chaos");

        if (EntityLogic.IsAbilityUseable(this, rainOfChaos))
        {
            Debug.Log("Rain Of Chaos button clicked, awaiting Rain Of Chaos target");
            awaitingRainOfChaosOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, rainOfChaos), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile or enemy");
        }
    }
    public void OnThunderStormButtonClicked()
    {
        Ability thunderStorm = mySpellBook.GetAbilityByName("Thunder Storm");

        if (EntityLogic.IsAbilityUseable(this, thunderStorm))
        {
            Debug.Log("Thunder Storm button clicked, awaiting Thunder Storm target");
            awaitingThunderStormOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, thunderStorm), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile or enemy");
        }
    }
    public void OnConcealingCloudsButtonClicked()
    {
        Ability concealingClouds = mySpellBook.GetAbilityByName("Concealing Clouds");

        if (EntityLogic.IsAbilityUseable(this, concealingClouds))
        {
            Debug.Log("Concealing Clouds button clicked, awaiting Concealing Clouds target");
            awaitingConcealingCloudsOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(concealingClouds.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile");
        }
    }
    public void OnTelekinesisButtonClicked()
    {
        Ability telekinesis = mySpellBook.GetAbilityByName("Telekinesis");        

        if (EntityLogic.IsAbilityUseable(this, telekinesis))
        {
            Debug.Log("Telekinesis button clicked, awaiting telekinesis target");
            awaitingTelekinesisTargetOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(telekinesis.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy or friendly character");
        }

    }
    public void OnFrostBoltButtonClicked()
    {
        Ability frostbolt = mySpellBook.GetAbilityByName("Frost Bolt");

        if (EntityLogic.IsAbilityUseable(this, frostbolt))
        {
            Debug.Log("Frost Bolt button clicked, awaiting Frost Bolt target");
            awaitingFrostBoltOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, frostbolt), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }        
    }
    public void OnChainLightningButtonClicked()
    {
        Ability chainLightning = mySpellBook.GetAbilityByName("Chain Lightning");

        if (EntityLogic.IsAbilityUseable(this, chainLightning))
        {
            Debug.Log("Chain Lightning button clicked, awaiting Frost Bolt target");
            awaitingChainLightningOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, chainLightning), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }      
    }
    public void OnDashButtonClicked()
    {
        Ability dash = mySpellBook.GetAbilityByName("Dash");

        if (EntityLogic.IsAbilityUseable(this, dash) &&
            EntityLogic.IsAbleToMove(this))
        {
            Debug.Log("Dash button clicked, awaiting Dash tile target");
            awaitingDashOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetValidMoveableTilesWithinRange(dash.abilityPrimaryValue + EntityLogic.GetTotalMobility(this), LevelManager.Instance.Tiles[gridPosition]));
            PathRenderer.Instance.ActivatePathRenderer();
            InstructionHover.Instance.EnableInstructionHover("Choose a tile");
        }        
    }
    public void OnPhoenixDiveButtonClicked()
    {
        Ability phoenixDive = mySpellBook.GetAbilityByName("Phoenix Dive");

        if (EntityLogic.IsAbilityUseable(this, phoenixDive))
        {
            Debug.Log("Phoenix Dive button clicked, awaiting Phoenix Dive tile target");
            awaitingPhoenixDiveOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(phoenixDive.abilityRange, LevelManager.Instance.Tiles[gridPosition], false));
            InstructionHover.Instance.EnableInstructionHover("Choose an tile");
        }


    }
    public void OnFireBallButtonClicked()
    {
        Ability fireball = mySpellBook.GetAbilityByName("Fire Ball");

        if (EntityLogic.IsAbilityUseable(this, fireball))
        {
            Debug.Log("Fire Ball button clicked, awaiting Shadow Blast target");
            awaitingFireBallOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, fireball), LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }       
    }
    public void OnMeltButtonClicked()
    {
        Ability melt = mySpellBook.GetAbilityByName("Melt");

        if (EntityLogic.IsAbilityUseable(this, melt))
        {
            Debug.Log("Melt button clicked, awaiting Melt target");
            awaitingMeltOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, melt), LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnShadowBlastButtonClicked()
    {
        Ability fireball = mySpellBook.GetAbilityByName("Shadow Blast");

        if (EntityLogic.IsAbilityUseable(this, fireball))
        {
            Debug.Log("Shadow Blast button clicked, awaiting Shadow Blast target");
            awaitingShadowBlastOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, fireball), LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnBlightButtonClicked()
    {
        Ability blight = mySpellBook.GetAbilityByName("Blight");

        if (EntityLogic.IsAbilityUseable(this, blight))
        {
            Debug.Log("Blight button clicked, awaiting Blight target");
            awaitingBlightOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(blight.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnProvokeButtonClicked()
    {
        Ability provoke = mySpellBook.GetAbilityByName("Provoke");

        if (EntityLogic.IsAbilityUseable(this, provoke))
        {
            Debug.Log("Provoke button clicked, awaiting Provoke target");
            awaitingProvokeOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(provoke.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnDimensionalBlastButtonClicked()
    {
        Ability dimensionalBlast = mySpellBook.GetAbilityByName("Dimensional Blast");

        if (EntityLogic.IsAbilityUseable(this, dimensionalBlast))
        {
            Debug.Log("Dimensional Blast button clicked, awaiting Dimensional Blast target");
            awaitingDimensionalBlastOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, dimensionalBlast), LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnMirageButtonClicked()
    {
        Ability mirage = mySpellBook.GetAbilityByName("Mirage");

        if (EntityLogic.IsAbilityUseable(this, mirage))
        {
            Debug.Log("Mirage button clicked, awaiting Mirage target");
            awaitingMirageOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(mirage.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnBurstOfKnowledgeButtonClicked()
    {
        Ability burstOfKnowledge = mySpellBook.GetAbilityByName("Burst Of Knowledge");

        if (EntityLogic.IsAbilityUseable(this, burstOfKnowledge))
        {
            Debug.Log("Burst Of Knowledge button clicked, awaiting Burst Of Knowledge target");
            awaitingBurstOfKnowledgeOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(burstOfKnowledge.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnBlinkButtonClicked()
    {
        Ability blink = mySpellBook.GetAbilityByName("Blink");

        if (EntityLogic.IsAbilityUseable(this, blink))
        {
            Debug.Log("Blink button clicked, awaiting Blink location target");
            awaitingBlinkOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(blink.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile");
        }
    }
    public void OnDisengageButtonClicked()
    {
        Ability disengage = mySpellBook.GetAbilityByName("Disengage");

        if (EntityLogic.IsAbilityUseable(this, disengage))
        {
            Debug.Log("Disengage button clicked, awaiting Disengage location target");
            awaitingDisengageOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(disengage.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a tile");
        }
    }
    public void OnTimeWarpButtonClicked()
    {
        Ability timeWarp = mySpellBook.GetAbilityByName("Time Warp");

        if (EntityLogic.IsAbilityUseable(this, timeWarp))
        {
            Debug.Log("Time Warp button clicked, awaiting Time Warp target");
            awaitingTimeWarpOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(timeWarp.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnDimensionalHexButtonClicked()
    {
        Ability dimensionalHex = mySpellBook.GetAbilityByName("Dimensional Hex");

        if (EntityLogic.IsAbilityUseable(this, dimensionalHex))
        {
            Debug.Log("Dimensional Hex button clicked, awaiting Dimensional Hex target");
            awaitingDimensionalHexOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(dimensionalHex.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnThawButtonClicked()
    {
        Ability thaw = mySpellBook.GetAbilityByName("Thaw");

        if (EntityLogic.IsAbilityUseable(this, thaw))
        {
            Debug.Log("Thaw button clicked, awaiting Thaw target");
            awaitingThawOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, thaw), LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnShootButtonClicked()
    {
        Ability shoot = mySpellBook.GetAbilityByName("Shoot");

        if (EntityLogic.IsAbilityUseable(this, shoot))
        {
            Debug.Log("Shoot button clicked, awaiting Shoot target");
            awaitingShootOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, shoot), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }       
    }
    public void OnPinningShotButtonClicked()
    {
        Ability ps = mySpellBook.GetAbilityByName("Pinning Shot");

        if (EntityLogic.IsAbilityUseable(this, ps))
        {
            Debug.Log("Pinning Shot button clicked, awaiting Pinning Shot target");
            awaitingPinningShotOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, ps), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnSnipeButtonClicked()
    {
        Ability snipe = mySpellBook.GetAbilityByName("Snipe");

        if (EntityLogic.IsAbilityUseable(this, snipe))
        {
            Debug.Log("Snipe button clicked, awaiting Snipe target");
            awaitingSnipeOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, snipe), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnHeadShotButtonClicked()
    {
        Ability headShot = mySpellBook.GetAbilityByName("Head Shot");

        if (EntityLogic.IsAbilityUseable(this, headShot))
        {
            Debug.Log("Head Shot button clicked, awaiting Head Shot target");
            awaitingHeadShotOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, headShot), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnCombustionButtonClicked()
    {
        Ability combustion = mySpellBook.GetAbilityByName("Combustion");

        if (EntityLogic.IsAbilityUseable(this, combustion))
        {
            Debug.Log("Combustion button clicked, awaiting Combustion target");
            awaitingCombustionOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, combustion), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnRapidFireButtonClicked()
    {
        Ability rapidFire = mySpellBook.GetAbilityByName("Rapid Fire");

        if (EntityLogic.IsAbilityUseable(this, rapidFire) && currentEnergy >= 10)
        {
            Debug.Log("Rapid Fire button clicked, awaiting Rapid Fire target");
            awaitingRapidFireOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, rapidFire), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }        
    }
    public void OnSliceAndDiceButtonClicked()
    {
        Ability sliceAndDice = mySpellBook.GetAbilityByName("Slice And Dice");

        if (EntityLogic.IsAbilityUseable(this, sliceAndDice))
        {
            Debug.Log("Slice And Dice button clicked, awaiting Slice and Dice target");
            awaitingSliceAndDiceOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

        
    }
    public void OnPoisonDartButtonClicked()
    {
        Ability poisonDart = mySpellBook.GetAbilityByName("Poison Dart");

        if (EntityLogic.IsAbilityUseable(this, poisonDart))
        {
            Debug.Log("Poison Dart button clicked, awaiting Poison Dart target");
            awaitingPoisonDartOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, poisonDart), LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }        
    }
    public void OnChemicalReactionButtonClicked()
    {
        Ability chemicalReaction = mySpellBook.GetAbilityByName("Chemical Reaction");

        if (EntityLogic.IsAbilityUseable(this, chemicalReaction))
        {
            Debug.Log("Chemical Reaction button clicked, awaiting Chemical Reaction target");
            awaitingChemicalReactionOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(chemicalReaction.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

        
    }
    public void OnImpalingBoltButtonClicked()
    {
        Ability imaplingBolt = mySpellBook.GetAbilityByName("Impaling Bolt");

        if (EntityLogic.IsAbilityUseable(this, imaplingBolt))
        {
            Debug.Log("Impaling Bolt button clicked, awaiting Impaling Bolt target");
            awaitingImpalingBoltOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, imaplingBolt), LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
       
    }
    
    public void OnInvigorateButtonClicked()
    {
        Ability invigorate = mySpellBook.GetAbilityByName("Invigorate");

        if (EntityLogic.IsAbilityUseable(this, invigorate))
        {
            Debug.Log("Invigorate button clicked, awaiting Invigorate target");
            awaitingInvigorateOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(invigorate.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }        
    }
    public void OnSnowStasisButtonClicked()
    {
        Ability st = mySpellBook.GetAbilityByName("Snow Stasis");

        if (EntityLogic.IsAbilityUseable(this, st))
        {
            Debug.Log("Snow Stasis button clicked, awaiting Snow Stasis target");
            awaitingSnowStasisOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(st.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnHasteButtonClicked()
    {
        Ability haste = mySpellBook.GetAbilityByName("Haste");

        if (EntityLogic.IsAbilityUseable(this, haste))
        {
            Debug.Log("Haste button clicked, awaiting Haste target");
            awaitingHasteOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(haste.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnSteadyHandsButtonClicked()
    {
        Ability steadyHands = mySpellBook.GetAbilityByName("Steady Hands");

        if (EntityLogic.IsAbilityUseable(this, steadyHands))
        {
            Debug.Log("Steady Hands button clicked, awaiting Steady Hands target");
            awaitingSteadyHandsOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(steadyHands.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnHolyFireButtonClicked()
    {
        Ability holyFire = mySpellBook.GetAbilityByName("Holy Fire");

        if (EntityLogic.IsAbilityUseable(this, holyFire))
        {
            Debug.Log("Holy Fire button clicked, awaiting Holy Fire target");
            awaitingHolyFireOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(holyFire.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy or friendly character");
        }       
    }
    public void OnPrimalBlastButtonClicked()
    {
        Ability primalBlast = mySpellBook.GetAbilityByName("Primal Blast");

        if (EntityLogic.IsAbilityUseable(this, primalBlast))
        {
            Debug.Log("Primal Blast button clicked, awaiting Primal Blast target");
            awaitingPrimalBlastOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, primalBlast), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a enemy");
        }

        
    }
    public void OnPrimalRageButtonClicked()
    {
        Ability primalRage = mySpellBook.GetAbilityByName("Primal Rage");

        if (EntityLogic.IsAbilityUseable(this, primalRage))
        {
            Debug.Log("Primal Rage button clicked, awaiting Primal Rage target");
            awaitingPrimalRageOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(primalRage.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }    
    public void OnPhaseShiftButtonClicked()
    {
        Ability phaseShift = mySpellBook.GetAbilityByName("Phase Shift");

        if (EntityLogic.IsAbilityUseable(this, phaseShift))
        {
            Debug.Log("Phase Shift button clicked, awaiting Phase Shift target");
            awaitingPhaseShiftOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(phaseShift.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy or friendly character");
        }

       
    }
    public void OnSanctityButtonClicked()
    {
        Ability sanctity = mySpellBook.GetAbilityByName("Sanctity");

        if (EntityLogic.IsAbilityUseable(this, sanctity))
        {
            Debug.Log("Sanctity button clicked, awaiting Sanctity target");
            awaitingSanctityOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(sanctity.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }

        
    }
    public void OnBlessButtonClicked()
    {
        Ability bless = mySpellBook.GetAbilityByName("Bless");

        if (EntityLogic.IsAbilityUseable(this, bless))
        {
            Debug.Log("Bless button clicked, awaiting Bless target");
            awaitingBlessOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(bless.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }
    }
    public void OnSiphonLifeButtonClicked()
    {
        Ability siphonLife = mySpellBook.GetAbilityByName("Siphon Life");

        if (EntityLogic.IsAbilityUseable(this, siphonLife))
        {
            Debug.Log("Siphon Life button clicked, awaiting Siphon Life target");
            awaitingSiphonLifeOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(siphonLife.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }        
    }
    public void OnVoidBombButtonClicked()
    {
        Ability voidBomb = mySpellBook.GetAbilityByName("Void Bomb");

        if (EntityLogic.IsAbilityUseable(this, voidBomb))
        {
            Debug.Log("Void Bomb button clicked, awaiting Void Bomb target");
            awaitingVoidBombOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, voidBomb), LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }        
    }
    public void OnNightmareButtonClicked()
    {
        Ability nightmare = mySpellBook.GetAbilityByName("Nightmare");

        if (EntityLogic.IsAbilityUseable(this, nightmare))
        {
            Debug.Log("Nightmare button clicked, awaiting Nightmare target");
            awaitingNightmareOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(nightmare.abilityRange, LevelManager.Instance.Tiles[gridPosition], false, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

        
    }
    public void OnWhirlwindButtonClicked()
    {
        Debug.Log("Whirlwind button clicked");

        Ability whirlwind = mySpellBook.GetAbilityByName("Whirlwind");

        if (EntityLogic.IsAbilityUseable(this, whirlwind))
        {
            AbilityLogic.Instance.PerformWhirlwind(this);
        }
    }
    public void OnSpritSurgeButtonClicked()
    {
        Debug.Log("Spirit Surge button clicked");

        Ability spiritSurge = mySpellBook.GetAbilityByName("Spirit Surge");

        if (EntityLogic.IsAbilityUseable(this, spiritSurge))
        {
            AbilityLogic.Instance.PerformSpiritSurge(this);
        }
    }
    public void OnEncourageButtonClicked()
    {
        Debug.Log("Encourage button clicked");

        Ability encourage = mySpellBook.GetAbilityByName("Encourage");

        if (EntityLogic.IsAbilityUseable(this, encourage))
        {
            AbilityLogic.Instance.PerformEncourage(this);
        }
    }
    public void OnToxicRainButtonClicked()
    {
        Debug.Log("Toxic Rain button clicked");

        Ability toxicRain = mySpellBook.GetAbilityByName("Toxic Rain");

        if (EntityLogic.IsAbilityUseable(this, toxicRain))
        {
            AbilityLogic.Instance.PerformToxicRain(this);
        }
    }
    public void OnPureHateButtonClicked()
    {
        Debug.Log("Pure Hate button clicked");

        Ability pureHate = mySpellBook.GetAbilityByName("Pure Hate");

        if (EntityLogic.IsAbilityUseable(this, pureHate))
        {
            AbilityLogic.Instance.PerformPureHate(this);
        }
    }
    public void OnGlobalCoolingButtonClicked()
    {
        Debug.Log("Global Cooling button clicked");

        Ability globalCooling = mySpellBook.GetAbilityByName("Global Cooling");

        if (EntityLogic.IsAbilityUseable(this, globalCooling))
        {
            AbilityLogic.Instance.PerformGlobalCooling(this);
        }
    }
    public void OnSecondWindButtonClicked()
    {
        Debug.Log("Second Wind button clicked");

        Ability secondWind = mySpellBook.GetAbilityByName("Second Wind");

        if (EntityLogic.IsAbilityUseable(this, secondWind))
        {
            AbilityLogic.Instance.PerformSecondWind(this);
        }
    }
    public void OnInfuseButtonClicked()
    {
        Debug.Log("Infuse button clicked");

        Ability infuse = mySpellBook.GetAbilityByName("Infuse");

        if (EntityLogic.IsAbilityUseable(this, infuse))
        {
            AbilityLogic.Instance.PerformInfuse(this);
        }
    }
    public void OnPurityButtonClicked()
    {
        Debug.Log("Purity button clicked");

        Ability purity = mySpellBook.GetAbilityByName("Purity");

        if (EntityLogic.IsAbilityUseable(this, purity))
        {
            AbilityLogic.Instance.PerformPurity(this);
        }
    }
   
    public void OnRecklessnessButtonClicked()
    {
        Debug.Log("Recklessness button clicked");

        Ability recklessness = mySpellBook.GetAbilityByName("Recklessness");

        if (EntityLogic.IsAbilityUseable(this, recklessness))
        {
            AbilityLogic.Instance.PerformRecklessness(this);
        }
    }
    public void OnRapidCloakingButtonClicked()
    {
        Debug.Log("Rapid Cloaking button clicked");

        Ability rapidCloaking = mySpellBook.GetAbilityByName("Rapid Cloaking");

        if (EntityLogic.IsAbilityUseable(this, rapidCloaking))
        {
            AbilityLogic.Instance.PerformRapidCloaking(this);
        }
    }
    public void OnTestudoButtonClicked()
    {
        Debug.Log("Testudo button clicked");

        Ability testudo = mySpellBook.GetAbilityByName("Testudo");

        if (EntityLogic.IsAbilityUseable(this, testudo))
        {
            AbilityLogic.Instance.PerformTestudo(this);
        }
    }    
    
    public void OnConcentrationButtonClicked()
    {
        Debug.Log("Concentration button clicked");

        Ability concentration = mySpellBook.GetAbilityByName("Concentration");

        if (EntityLogic.IsAbilityUseable(this, concentration))
        {
            AbilityLogic.Instance.PerformConcentration(this);
        }
    }    
    
    public void OnNoxiousFumesButtonClicked()
    {
        Debug.Log("Noxious Fumes button clicked");

        Ability noxiousFumes = mySpellBook.GetAbilityByName("Noxious Fumes");

        if (EntityLogic.IsAbilityUseable(this, noxiousFumes))
        {
            AbilityLogic.Instance.PerformNoxiousFumes(this);
        }
    }
    public void OnSharpenBladeButtonClicked()
    {
        Debug.Log("Sharpen Blade button clicked");

        Ability sharpenBlade = mySpellBook.GetAbilityByName("Sharpen Blade");

        if (EntityLogic.IsAbilityUseable(this, sharpenBlade))
        {
            AbilityLogic.Instance.PerformSharpenBlade(this);
        }
    }
    public void OnBloodOfferingButtonClicked()
    {
        Debug.Log("Blood Offering button clicked");

        Ability bloodOffering = mySpellBook.GetAbilityByName("Blood Offering");

        if (EntityLogic.IsAbilityUseable(this, bloodOffering))
        {
            AbilityLogic.Instance.PerformBloodOffering(this);
        }
    }
    public void OnFrenzyButtonClicked()
    {
        Debug.Log("Frenzy button clicked");

        Ability frenzy = mySpellBook.GetAbilityByName("Frenzy");

        if (EntityLogic.IsAbilityUseable(this, frenzy))
        {
            AbilityLogic.Instance.PerformFrenzy(this);
        }
    }
    public void OnHorrifyButtonClicked()
    {
        Debug.Log("Horrify button clicked");

        Ability horrify = mySpellBook.GetAbilityByName("Horrify");

        if (EntityLogic.IsAbilityUseable(this, horrify))
        {
            AbilityLogic.Instance.PerformHorrify(this);
        }
    }
    public void OnUnbridledChaosButtonClicked()
    {
        Debug.Log("Unbridled Chaos button clicked");

        Ability unbridledChaos = mySpellBook.GetAbilityByName("Unbridled Chaos");

        if (EntityLogic.IsAbilityUseable(this, unbridledChaos))
        {
            AbilityLogic.Instance.PerformUnbridledChaos(this);
        }

    }
    public void OnConsecrateButtonClicked()
    {
        Debug.Log("Consecrate button clicked");

        Ability consecrate = mySpellBook.GetAbilityByName("Consecrate");

        if (EntityLogic.IsAbilityUseable(this, consecrate))
        {
            AbilityLogic.Instance.PerformConsecrate(this);
        }
    }
    public void OnOverwatchButtonClicked()
    {
        Debug.Log("Overwatch button clicked");

        Ability overwatch = mySpellBook.GetAbilityByName("Overwatch");

        if (EntityLogic.IsAbilityUseable(this, overwatch))
        {
            AbilityLogic.Instance.PerformOverwatch(this);
        }

    }
    public void OnMoonInfusionButtonClicked()
    {
        Debug.Log("Moon Infusion button clicked");

        Ability moonInfusion = mySpellBook.GetAbilityByName("Moon Infusion");

        if (EntityLogic.IsAbilityUseable(this, moonInfusion))
        {
            AbilityLogic.Instance.PerformMoonInfusion(this);
        }

    }
    public void OnFireNovaButtonClicked()
    {
        Debug.Log("Fire Nova button clicked");

        Ability fireNova = mySpellBook.GetAbilityByName("Fire Nova");

        if (EntityLogic.IsAbilityUseable(this, fireNova))
        {
            AbilityLogic.Instance.PerformFireNova(this);
        }

    }
    public void OnFrostNovaButtonClicked()
    {
        Debug.Log("Frost Nova button clicked");

        Ability frostNova = mySpellBook.GetAbilityByName("Frost Nova");

        if (EntityLogic.IsAbilityUseable(this, frostNova))
        {
            AbilityLogic.Instance.PerformFrostNova(this);
        }

    }
    public void OnReactiveArmourButtonClicked()
    {
        Debug.Log("Reactive Armor button clicked");

        Ability reactiveArmour = mySpellBook.GetAbilityByName("Reactive Armour");

        if (EntityLogic.IsAbilityUseable(this, reactiveArmour))
        {
            AbilityLogic.Instance.PerformReactiveArmour(this);
        }

    }
    public void OnVanishButtonClicked()
    {
        Debug.Log("Vanish button clicked");

        Ability vanish = mySpellBook.GetAbilityByName("Vanish");

        if (EntityLogic.IsAbilityUseable(this, vanish))
        {
            AbilityLogic.Instance.PerformVanish(this);
        }

    }   
    public void OnElectricalDischargeButtonClicked()
    {
        Debug.Log("Electrical Discharge button clicked");

        Ability electricalDischarge = mySpellBook.GetAbilityByName("Electrical Discharge");

        if (!EntityLogic.IsAbilityUseable(this, electricalDischarge))
        {
            return;
        }

        // damage enemies
        //CombatLogic.Instance.CreateAoEAttackEvent(this, electricalDischarge, tile, currentMeleeRange, true, false);

        // give block to allies
        List<Tile> tilesInMyMeleeRange = LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, tile);
        foreach(Defender defender in DefenderManager.Instance.allDefenders)
        {
            if (tilesInMyMeleeRange.Contains(defender.tile))
            {
                defender.ModifyCurrentBlock(CombatLogic.Instance.CalculateBlockGainedByEffect(electricalDischarge.abilityPrimaryValue, this));
            }
        }

       // OnAbilityUsed(electricalDischarge, this);

    }
    public void OnDefendButtonClicked()
    {
        Debug.Log("Defend button clicked");

        Ability block = mySpellBook.GetAbilityByName("Defend");

        if (EntityLogic.IsAbilityUseable(this, block))
        {
            AbilityLogic.Instance.PerformDefend(this);
        }

    }
    
    public void OnPreparationButtonClicked()
    {
        Debug.Log("Preparation button clicked");

        Ability preparation = mySpellBook.GetAbilityByName("Preparation");

        if (EntityLogic.IsAbilityUseable(this, preparation))
        {
            AbilityLogic.Instance.PerformPreparation(this);
        }       

    }
    public void OnTwinStrikeButtonClicked()
    {
        Ability twinStrike = mySpellBook.GetAbilityByName("Twin Strike");

        if (EntityLogic.IsAbilityUseable(this, twinStrike))
        {
            Debug.Log("Twin Strike button clicked, awaiting Twin Strike target");
            awaitingTwinStrikeOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
       
    }
    public void OnShieldSlamButtonClicked()
    {
        Ability shieldSlam = mySpellBook.GetAbilityByName("Shield Slam");

        if (EntityLogic.IsAbilityUseable(this, shieldSlam))
        {
            Debug.Log("Shield Slam button clicked, awaiting Shield Slam target");
            awaitingShieldSlamOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnDevastatingBlowButtonClicked()
    {
        Ability devastatingBlow = mySpellBook.GetAbilityByName("Devastating Blow");

        if (EntityLogic.IsAbilityUseable(this, devastatingBlow))
        {
            Debug.Log("Devastating Blow button clicked, awaiting Devastating Blow target");
            awaitingDevastatingBlowOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnToxicSlashButtonClicked()
    {
        Ability toxicSlash = mySpellBook.GetAbilityByName("Toxic Slash");

        if (EntityLogic.IsAbilityUseable(this, toxicSlash))
        {
            Debug.Log("Toxic Slash button clicked, awaiting Toxic Slash target");
            awaitingToxicSlashOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnDecapitateButtonClicked()
    {
        Ability decapitate = mySpellBook.GetAbilityByName("Decapitate");

        if (EntityLogic.IsAbilityUseable(this, decapitate))
        {
            Debug.Log("Decapitate button clicked, awaiting Decapitate target");
            awaitingDecapitateOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnShankButtonClicked()
    {
        Ability shank = mySpellBook.GetAbilityByName("Shank");

        if (EntityLogic.IsAbilityUseable(this, shank))
        {
            Debug.Log("Shank button clicked, awaiting Shank target");
            awaitingShankOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnCheapShotButtonClicked()
    {
        Ability cheapShot = mySpellBook.GetAbilityByName("Cheap Shot");

        if (EntityLogic.IsAbilityUseable(this, cheapShot))
        {
            Debug.Log("Cheap Shot button clicked, awaiting Cheap Shot target");
            awaitingCheapShotOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnAmbushButtonClicked()
    {
        Ability ambush = mySpellBook.GetAbilityByName("Ambush");

        if (EntityLogic.IsAbilityUseable(this, ambush))
        {
            Debug.Log("Ambush button clicked, awaiting Ambush target");
            awaitingAmbushOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }
    public void OnShadowStepButtonClicked()
    {
        Ability shadowStep = mySpellBook.GetAbilityByName("Shadow Step");

        if (EntityLogic.IsAbilityUseable(this, shadowStep))
        {
            Debug.Log("Shadow Step button clicked, awaiting Shadow Step target");
            awaitingShadowStepOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(shadowStep.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }
    }  
    public void OnThunderStrikeButtonClicked()
    {
        Ability thunderStrike = mySpellBook.GetAbilityByName("Thunder Strike");

        if (EntityLogic.IsAbilityUseable(this, thunderStrike))
        {
            Debug.Log("Thunder Strike button clicked, awaiting Thunder strike target");
            awaitingThunderStrikeOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnJudgementButtonClicked()
    {
        Ability judgement = mySpellBook.GetAbilityByName("Judgement");

        if (EntityLogic.IsAbilityUseable(this, judgement))
        {
            Debug.Log("Judgement button clicked, awaiting Judgement target");
            awaitingJudgementOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnEvasionButtonClicked()
    {
        Ability evasion = mySpellBook.GetAbilityByName("Evasion");

        if (EntityLogic.IsAbilityUseable(this, evasion))
        {
            Debug.Log("Evasion button clicked, awaiting Evasion target");
            awaitingEvasionOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(evasion.abilityRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose a friendly character");
        }

    }
    public void OnTendonSlashButtonClicked()
    {
        Ability tendonSlash = mySpellBook.GetAbilityByName("Tendon Slash");

        if (EntityLogic.IsAbilityUseable(this, tendonSlash))
        {
            Debug.Log("Tendon Slash button clicked, awaiting Tendon Slash target");
            awaitingTendonSlashOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnChillingBlowButtonClicked()
    {
        Ability chillingBlow = mySpellBook.GetAbilityByName("Chilling Blow");

        if (EntityLogic.IsAbilityUseable(this, chillingBlow))
        {
            Debug.Log("Chilling Blow button clicked, awaiting Chilling Blow target");
            awaitingChillingBlowOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnShieldShatterButtonClicked()
    {
        Ability shieldShatter = mySpellBook.GetAbilityByName("Shield Shatter");

        if (EntityLogic.IsAbilityUseable(this, shieldShatter))
        {
            Debug.Log("Shield Shatter button clicked, awaiting Shield Shatter target");
            awaitingShieldShatterOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnSwordAndBoardButtonClicked()
    {
        Ability swordAndBoard = mySpellBook.GetAbilityByName("Sword And Board");

        if (EntityLogic.IsAbilityUseable(this, swordAndBoard))
        {
            Debug.Log("Sword And Board button clicked, awaiting Sword And Board target");
            awaitingSwordAndBoardOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnKickToTheBallsButtonClicked()
    {
        Ability kickToTheBalls = mySpellBook.GetAbilityByName("Kick To The Balls");

        if (EntityLogic.IsAbilityUseable(this, kickToTheBalls))
        {
            Debug.Log("Kick To The Balls button clicked, awaiting Kick To The Bals target");
            awaitingKickToTheBallsOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnRamButtonClicked()
    {
        Ability kickToTheBalls = mySpellBook.GetAbilityByName("Ram");

        if (EntityLogic.IsAbilityUseable(this, kickToTheBalls))
        {
            Debug.Log("Ram button clicked, awaiting Ram target");
            awaitingRamOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(currentMeleeRange, LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }

    }
    public void OnBladeFlurryButtonClicked()
    {
        Debug.Log("Blade Flurry button clicked");

        Ability bladeFlurry = mySpellBook.GetAbilityByName("Blade Flurry");

        if (EntityLogic.IsAbilityUseable(this, bladeFlurry))
        {
            AbilityLogic.Instance.PerformBladeFlurry(this);
        }
    }
    public void OnGlacialBurstButtonClicked()
    {
        Debug.Log("Glacial Burst button clicked");

        Ability glacialBurst = mySpellBook.GetAbilityByName("Glacial Burst");

        if (EntityLogic.IsAbilityUseable(this, glacialBurst))
        {
            AbilityLogic.Instance.PerformGlacialBurst(this);
        }
    }
    public void OnChallengingShoutButtonClicked()
    {
        Debug.Log("Challenging Shout button clicked");

        Ability challenginShout = mySpellBook.GetAbilityByName("Challenging Shout");

        if (EntityLogic.IsAbilityUseable(this, challenginShout))
        {
            AbilityLogic.Instance.PerformChallengingShout(this);
        }
    }
    public void OnChaosBoltButtonClicked()
    {
        Ability chaosBolt = mySpellBook.GetAbilityByName("Chaos Bolt");

        if (EntityLogic.IsAbilityUseable(this, chaosBolt))
        {
            Debug.Log("Chaos Bolt button clicked, awaiting Chaos Bolt target");
            awaitingChaosBoltOrder = true;
            LevelManager.Instance.HighlightTiles(LevelManager.Instance.GetTilesWithinRange(EntityLogic.GetTotalRangeOfRangedAttack(this, chaosBolt), LevelManager.Instance.Tiles[gridPosition], true, false));
            InstructionHover.Instance.EnableInstructionHover("Choose an enemy");
        }       
    }
    #endregion

    // Text + UI Component Updates
    #region  
   
    public float CalculateEnergyBarPosition()
    {
        float currentAPFloat = currentEnergy;
        float currentMaxAPFloat = currentMaxEnergy;

        return currentAPFloat / currentMaxAPFloat;
    }
    public void UpdateEnergyBarPosition()
    {
        float finalValue = CalculateEnergyBarPosition();
        myCurrentEnergyBarText.text = currentEnergy.ToString();
        myCurrentMaxEnergyBarText.text = currentMaxEnergy.ToString();
        energyBarPositionCurrentlyUpdating = false;
        StartCoroutine(UpdateEnergyBarPositionCoroutine(finalValue));

    }    
    public IEnumerator UpdateHealthBarPanelPosition(float finalValue)
    {
        float needleMoveSpeed = 0.02f;
        healthBarPositionCurrentlyUpdating = true;

        while (myHealthBarStatPanel.value != finalValue && healthBarPositionCurrentlyUpdating == true)
        {
            if (myHealthBarStatPanel.value > finalValue)
            {
                myHealthBarStatPanel.value -= needleMoveSpeed;
                if (myHealthBarStatPanel.value < finalValue)
                {
                    myHealthBarStatPanel.value = finalValue;
                }
            }
            else if (myHealthBarStatPanel.value < finalValue)
            {
                myHealthBarStatPanel.value += needleMoveSpeed;
                if (myHealthBarStatPanel.value > finalValue)
                {
                    myHealthBarStatPanel.value = finalValue;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator UpdateEnergyBarPositionCoroutine(float finalValue)
    {
        float needleMoveSpeed = 0.04f;
        energyBarPositionCurrentlyUpdating = true;

        while (myEnergyBar.value != finalValue && energyBarPositionCurrentlyUpdating == true)
        {
            if(myEnergyBar.value > finalValue)
            {
                myEnergyBar.value -= needleMoveSpeed;
                if(myEnergyBar.value < finalValue)
                {
                    myEnergyBar.value = finalValue;
                }
            }
            else if (myEnergyBar.value < finalValue)
            {
                myEnergyBar.value += needleMoveSpeed;
                if (myEnergyBar.value > finalValue)
                {
                    myEnergyBar.value = finalValue;
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }   

    public IEnumerator FadeInUICanvas()
    {
        myUIParentCg.alpha = 0;

        fadingOut = false;
        fadingIn = true;

        while (fadingIn && myUIParentCg.alpha < 1)
        {
            myUIParentCg.alpha += 0.1f * uiFadeSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();            
        }
    }
    public IEnumerator FadeOutUICanvas()
    {
        myUIParentCg.alpha = 1;

        fadingIn = false;
        fadingOut = true;

        while (fadingOut && myUIParentCg.alpha > 0)
        {
            myUIParentCg.alpha -= 0.1f * uiFadeSpeed * Time.deltaTime;

            if(myUIParentCg.alpha == 0)
            {
                myUIParent.SetActive(false);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    #endregion

    // Perform Abilities 
    #region
    public void StartMoveAbilityProcess(Tile destination)
    {
        // If the selected tile is within our movement range, is walkable, and unoccupied, the attempted move is valid: start moving
        if (MovementLogic.Instance.IsLocationMoveable(destination, this, EntityLogic.GetTotalMobility(this)))
        {
            Debug.Log("Selected tile is valid, starting move...");
            awaitingMoveOrder = false;
            AbilityLogic.Instance.PerformMove(this, destination);
            
        }
    }
    public void StartDashProcess(Tile destination)
    {
        Ability dash = mySpellBook.GetAbilityByName("Dash");

        // If the selected tile is within our movement range, is walkable, and unoccupied, the attempted move is valid: start moving
        if (MovementLogic.Instance.IsLocationMoveable(destination, this, dash.abilityPrimaryValue + EntityLogic.GetTotalMobility(this)))
        {
            Debug.Log("Selected tile is valid, starting move...");
            awaitingDashOrder = false;
            AbilityLogic.Instance.PerformDash(this, destination);
        }
    }
    public void StartTreeLeapProcess(Tile destination)
    {
        Ability treeLeap = mySpellBook.GetAbilityByName("Tree Leap");

        // If the selected tile is within range AND a grass tile, start teleport
        if (MovementLogic.Instance.IsLocationMoveable(destination, this, treeLeap.abilityRange) &&
            destination.myTileType == Tile.TileType.Grass)
        {
            awaitingTreeLeapOrder = false;
            AbilityLogic.Instance.PerformTreeLeap(this, destination);
        }
    }
    public void StartGetDownProcess(Tile destination)
    {
        Ability getDown = mySpellBook.GetAbilityByName("Get Down!");

        // If the selected tile is within our movement range, is walkable, and unoccupied, the attempted move is valid: start moving
        if (MovementLogic.Instance.IsLocationMoveable(destination, this, getDown.abilityPrimaryValue + EntityLogic.GetTotalMobility(this)))
        {
            Debug.Log("Selected tile is valid, starting move...");
            awaitingGetDownOrder = false;
            AbilityLogic.Instance.PerformGetDown(this, destination);
        }
    }
    public void StartStrikeProcess()
    {
        Debug.Log("Defender.StartStrikeProcess() called");
        Enemy enemyTarget = EnemyManager.Instance.selectedEnemy;
        Ability strike = mySpellBook.GetAbilityByName("Strike");

        if (EntityLogic.IsTargetInRange(this, enemyTarget, currentMeleeRange) 
            && EntityLogic.IsAbilityUseable(this, strike, enemyTarget))
        {
            awaitingStrikeOrder = false;
            AbilityLogic.Instance.PerformStrike(this, enemyTarget);
        }
    }
    public void StartBackStabProcess()
    {
        Debug.Log("Defender.StartBackStabProcess() called");
        Enemy enemyTarget = EnemyManager.Instance.selectedEnemy;
        Ability backstab = mySpellBook.GetAbilityByName("Back Stab");

        if (EntityLogic.IsTargetInRange(this, enemyTarget, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, backstab, enemyTarget))
        {
            awaitingBackStabOrder = false;
            AbilityLogic.Instance.PerformBackStab(this, enemyTarget);
        }
    }
    public void StartDisarmProcess()
    {
        Debug.Log("Defender.StartDisarmProcess() called");
        Enemy enemyTarget = EnemyManager.Instance.selectedEnemy;
        Ability disarm = mySpellBook.GetAbilityByName("Disarm");

        if (EntityLogic.IsTargetInRange(this, enemyTarget, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, disarm, enemyTarget))
        {
            awaitingDisarmOrder = false;
            AbilityLogic.Instance.PerformDisarm(this, enemyTarget);
        }
    }
    public void StartSmashProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartSmashProcess() called");
        Ability smash = mySpellBook.GetAbilityByName("Smash");
        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, smash, target))
        {
            awaitingSmashOrder = false;            
            AbilityLogic.Instance.PerformSmash(this, target);
        }
    }
    public void StartShankProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartShankProcess() called");
        Ability shank = mySpellBook.GetAbilityByName("Shank");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, shank, target))
        {
            awaitingShankOrder = false;
            AbilityLogic.Instance.PerformShank(this, target);
        }
    }
    public void StartAmbushProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartAmbushProcess() called");
        Ability ambush = mySpellBook.GetAbilityByName("Ambush");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, ambush, target))
        {
            awaitingAmbushOrder = false;
            AbilityLogic.Instance.PerformAmbush(this, target);
        }
    }
    public void StartCheapShotProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartCheapShotProcess() called");
        Ability cheapShot = mySpellBook.GetAbilityByName("Cheap Shot");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
             && EntityLogic.IsAbilityUseable(this, cheapShot, target))
        {
            awaitingCheapShotOrder = false;
            AbilityLogic.Instance.PerformCheapShot(this, target);
        }
    }
    public void StartDecapitateProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartDecapitateProcess() called");
        Ability decapitate = mySpellBook.GetAbilityByName("Decapitate");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, decapitate, target))
        {
            awaitingDecapitateOrder = false;
            AbilityLogic.Instance.PerformDecapitate(this, target);
        }
    }
    public void StartShadowStepProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartShadowStepProcess() called");       

        Tile targetsBackTile = PositionLogic.Instance.GetTargetsBackArcTile(target);
        Ability shadowStep = mySpellBook.GetAbilityByName("Shadow Step");
   
        if (EntityLogic.IsTargetInRange(this, target, shadowStep.abilityRange) &&
            EntityLogic.IsAbilityUseable(this, shadowStep, target) &&
            targetsBackTile.IsEmpty &&
            targetsBackTile.IsWalkable)
        {
            awaitingShadowStepOrder = false;
            AbilityLogic.Instance.PerformShadowStep(this, targetsBackTile);
        }
    }
    public void StartKickToTheBallsProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartKickToTheBallsProcess() called");
        Ability kttb = mySpellBook.GetAbilityByName("Kick To The Balls");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, kttb, target))
        {
            awaitingKickToTheBallsOrder = false;
            AbilityLogic.Instance.PerformKickToTheBalls(this, target);
        }

    }
    public void StartRamProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartRamProcess() called");
        Ability ram = mySpellBook.GetAbilityByName("Ram");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, ram, target))
        {
            awaitingRamOrder = false;
            AbilityLogic.Instance.PerformRam(this, target);
        }

    }
    public void StartDevastatingBlowProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartDevastatingBlowProcess() called");
        Ability db = mySpellBook.GetAbilityByName("Devastating Blow");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, db, target))
        {
            awaitingDevastatingBlowOrder = false;
            AbilityLogic.Instance.PerformDevastatingBlow(this, target);
        }
    }
    public void StartToxicSlashProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartToxicSlashProcess() called");
        Ability toxicSlash = mySpellBook.GetAbilityByName("Toxic Slash");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, toxicSlash, target))
        {
            awaitingToxicSlashOrder = false;
            AbilityLogic.Instance.PerformToxicSlash(this, target);
        }
    }
    public void StartThunderStrikeProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartThunderStrikeProcess() called");
        Ability thunderStrike = mySpellBook.GetAbilityByName("Thunder Strike");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
             && EntityLogic.IsAbilityUseable(this, thunderStrike, target))
        {
            awaitingThunderStrikeOrder = false;
            AbilityLogic.Instance.PerformThunderStrike(this, target);
        }
    }
    public void StartJudgementProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartDevastatingBlowProcess() called");
        Ability judgement = mySpellBook.GetAbilityByName("Judgement");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, judgement, target))
        {
            awaitingJudgementOrder = false;
            AbilityLogic.Instance.PerformJudgement(this, target);
        }

    }
    public void StartShieldSlamProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartShieldSlamProcess() called");
        Ability shieldSlam = mySpellBook.GetAbilityByName("Shield Slam");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, shieldSlam, target))
        {
            awaitingShieldSlamOrder = false;
            AbilityLogic.Instance.PerformShieldSlam(this, target);
        }

    }
    public void StartShieldShatterProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartShieldShatterProcess() called");
        Ability shieldShatter = mySpellBook.GetAbilityByName("Shield Shatter");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, shieldShatter, target))
        {
            awaitingShieldShatterOrder = false;
            AbilityLogic.Instance.PerformShieldShatter(this, target);
        }

    }
    public void StartTendonSlashProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartTendonSlashProcess() called");
        Ability tendonSlash = mySpellBook.GetAbilityByName("Tendon Slash");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, tendonSlash, target))
        {
            awaitingTendonSlashOrder = false;
            AbilityLogic.Instance.PerformTendonSlash(this, target);
        }

    }
    public void StartChillingBlowProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartChillingBlowProcess() called");
        Ability chillingBlow = mySpellBook.GetAbilityByName("Chilling Blow");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, chillingBlow, target))
        {
            awaitingChillingBlowOrder = false;
            AbilityLogic.Instance.PerformChillingBlow(this, target);
        }

    }
    public void StartSwordAndBoardProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartSwordAndBoardProcess() called");
        Ability swordAndBoard = mySpellBook.GetAbilityByName("Sword And Board");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
             && EntityLogic.IsAbilityUseable(this, swordAndBoard, target))
        {
            awaitingSwordAndBoardOrder = false;
            AbilityLogic.Instance.PerformSwordAndBoard(this, target);
        }

    }
    public void StartChainLightningProcess(LivingEntity target)
    {
        Debug.Log("Defender.ChainLightningProcess() called");

        Ability chainLightning = mySpellBook.GetAbilityByName("Chain Lightning");
        
        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, chainLightning))
            && EntityLogic.IsAbilityUseable(this, chainLightning, target))
        {
            awaitingChainLightningOrder = false;      
            AbilityLogic.Instance.PerformChainLightning(this, target);
        }
    }   
    public void StartMeteorProcess(Tile targetTile)
    {
        Ability meteor = mySpellBook.GetAbilityByName("Meteor");

        if(LevelManager.Instance.IsTileYWithinRangeOfTileX(tile, targetTile, EntityLogic.GetTotalRangeOfRangedAttack(this, meteor)))
        {
            awaitingMeteorOrder = false;
            AbilityLogic.Instance.PerformMeteor(this, targetTile);
        }              
    }
    public void StartChloroformBombProcess(Tile targetTile)
    {
        Ability cb = mySpellBook.GetAbilityByName("Chloroform Bomb");

        if (LevelManager.Instance.IsTileYWithinRangeOfTileX(tile, targetTile, EntityLogic.GetTotalRangeOfRangedAttack(this, cb)))
        {
            awaitingChloroformBombOrder = false;
            AbilityLogic.Instance.PerformChloroformBomb(this, targetTile);
        }
    }
    public void StartDragonBreathProcess(Tile targetTile)
    {
        Ability dragonBreath = mySpellBook.GetAbilityByName("Dragon Breath");

        if (LevelManager.Instance.IsTileYWithinRangeOfTileX(tile, targetTile, dragonBreath.abilityRange))
        {
            awaitingDragonBreathOrder = false;
            AbilityLogic.Instance.PerformDragonBreath(this, targetTile);
        }
    }
    public void StartBlizzardProcess(Tile targetTile)
    {
        Ability blizzard = mySpellBook.GetAbilityByName("Blizzard");

        if (LevelManager.Instance.IsTileYWithinRangeOfTileX(tile, targetTile, EntityLogic.GetTotalRangeOfRangedAttack(this, blizzard)))
        {
            awaitingBlizzardOrder = false;
            AbilityLogic.Instance.PerformBlizzard(this, targetTile);
        }

    }
    public void StartBlindingLightProcess(Tile targetTile)
    {
        Ability blindingLight = mySpellBook.GetAbilityByName("Blinding Light");

        if (LevelManager.Instance.IsTileYWithinRangeOfTileX(tile, targetTile, EntityLogic.GetTotalRangeOfRangedAttack(this, blindingLight)))
        {
            awaitingBlindingLightOrder = false;
            AbilityLogic.Instance.PerformBlindingLight(this, targetTile);
        }
    }
    public void StartConcealingCloudsProcess(Tile targetTile)
    {
        Ability concealingClouds = mySpellBook.GetAbilityByName("Concealing Clouds");

        if (LevelManager.Instance.IsTileYWithinRangeOfTileX(tile, targetTile, concealingClouds.abilityRange))
        {
            awaitingConcealingCloudsOrder = false;
            AbilityLogic.Instance.PerformConcealingClouds(this, targetTile);
        }

    }
    public void StartToxicEruptionProcess(Tile targetTile)
    {
        Ability toxicEruption = mySpellBook.GetAbilityByName("Toxic Eruption");

        if (LevelManager.Instance.IsTileYWithinRangeOfTileX(tile, targetTile, EntityLogic.GetTotalRangeOfRangedAttack(this, toxicEruption)))
        {
            awaitingToxicEruptionOrder = false;
            AbilityLogic.Instance.PerformToxicEruption(this, targetTile);
        }

    }
    public void StartThunderStormProcess(Tile targetTile)
    {
        Ability thunderStorm = mySpellBook.GetAbilityByName("Thunder Storm");

        if (LevelManager.Instance.IsTileYWithinRangeOfTileX(tile, targetTile, EntityLogic.GetTotalRangeOfRangedAttack(this, thunderStorm)))
        {
            awaitingThunderStormOrder = false;
            AbilityLogic.Instance.PerformThunderStorm(this, targetTile);
        }

    }
    public void StartRainOfChaosProcess(Tile targetTile)
    {
        Ability rainOfChaos = mySpellBook.GetAbilityByName("Rain Of Chaos");

        if (LevelManager.Instance.IsTileYWithinRangeOfTileX(tile, targetTile, EntityLogic.GetTotalRangeOfRangedAttack(this, rainOfChaos)))
        {
            awaitingRainOfChaosOrder = false;
            AbilityLogic.Instance.PerformRainOfChaos(this, targetTile);
        }

    }    
    public void StartInspireProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartInspireProcess() called");
        Ability inspire = mySpellBook.GetAbilityByName("Inspire");

        if (EntityLogic.IsTargetInRange(this, target, inspire.abilityRange)
            && EntityLogic.IsAbilityUseable(this, inspire, target))
        {
            awaitingInspireOrder = false;
            AbilityLogic.Instance.PerformInspire(this, target);
        }
    }
    public void StartStoneFormProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartStoneFormProcess() called");
        Ability stoneForm = mySpellBook.GetAbilityByName("Stone Form");

        if (EntityLogic.IsTargetInRange(this, target, stoneForm.abilityRange)
            && EntityLogic.IsAbilityUseable(this, stoneForm, target))
        {
            awaitingStoneFormOrder = false;
            AbilityLogic.Instance.PerformStoneForm(this, target);
        }
    }
    public void StartGoBerserkProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartGoBerserkProcess() called");
        Ability inspire = mySpellBook.GetAbilityByName("Go Berserk");

        if (EntityLogic.IsTargetInRange(this, target, inspire.abilityRange)
            && EntityLogic.IsAbilityUseable(this, inspire, target))
        {
            awaitingGoBerserkOrder = false;
            AbilityLogic.Instance.PerformGoBerserk(this, target);
        }
    }
    public void StartTranscendenceProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartTranscendenceProcess() called");
        Ability transcendence = mySpellBook.GetAbilityByName("Transcendence");

        if (EntityLogic.IsTargetInRange(this, target, transcendence.abilityRange)
            && EntityLogic.IsAbilityUseable(this, transcendence, target))
        {
            awaitingTranscendenceOrder = false;
            AbilityLogic.Instance.PerformTranscendence(this, target);
        }
    }
    public void StartProvokeProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartProvokeProcess() called");
        Ability provoke = mySpellBook.GetAbilityByName("Provoke");

        if (EntityLogic.IsTargetInRange(this, target, provoke.abilityRange)
            && EntityLogic.IsAbilityUseable(this, provoke, target))
        {
            awaitingProvokeOrder = false;
            AbilityLogic.Instance.PerformProvoke(this, target);
        }
    }
    public void StartHexProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartHexProcess() called");
        Ability hex = mySpellBook.GetAbilityByName("Hex");

        if (EntityLogic.IsTargetInRange(this, target, hex.abilityRange)
            && EntityLogic.IsAbilityUseable(this, hex, target))
        {
            awaitingHexOrder = false;
            AbilityLogic.Instance.PerformHex(this, target);
        }
    }
    public void StartMarkTargetProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartMarkTargetProcess() called");
        Ability mt = mySpellBook.GetAbilityByName("Mark Target");

        if (EntityLogic.IsTargetInRange(this, target, mt.abilityRange)
            && EntityLogic.IsAbilityUseable(this, mt, target))
        {
            awaitingMarkTargetOrder = false;
            AbilityLogic.Instance.PerformMarkTarget(this, target);
        }
    }
    public void StartBlightProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartBlightProcess() called");
        Ability blight = mySpellBook.GetAbilityByName("Blight");

        if (EntityLogic.IsTargetInRange(this, target, blight.abilityRange)
            && EntityLogic.IsAbilityUseable(this, blight, target))
        {
            awaitingBlightOrder = false;
            AbilityLogic.Instance.PerformBlight(this, target);
        }
    }
    public void StartShroudProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartShroudProcess() called");
        Ability shroud = mySpellBook.GetAbilityByName("Shroud");

        if (EntityLogic.IsTargetInRange(this, target, shroud.abilityRange)
            && EntityLogic.IsAbilityUseable(this, shroud, target))
        {
            awaitingShroudOrder = false;
            AbilityLogic.Instance.PerformShroud(this, target);
        }
    }
    public void StartIcyFocusProcess(Defender target)
    {
        Debug.Log("Defender.StartIcyFocusProcess() called");
        Ability icyFocus = mySpellBook.GetAbilityByName("Icy Focus");

        if (EntityLogic.IsTargetInRange(this, target, icyFocus.abilityRange)
            && EntityLogic.IsAbilityUseable(this, icyFocus, target))
        {
            awaitingIcyFocusOrder = false;
            AbilityLogic.Instance.PerformIcyFocus(this, target);
        }
    }
    public void StartDarkGiftProcess(Defender target)
    {
        Debug.Log("Defender.StartDarkGiftProcess() called");
        Ability icyFocus = mySpellBook.GetAbilityByName("Dark Gift");

        if (EntityLogic.IsTargetInRange(this, target, icyFocus.abilityRange)
            && EntityLogic.IsAbilityUseable(this, icyFocus, target))
        {
            awaitingDarkGiftOrder = false;
            AbilityLogic.Instance.PerformDarkGift(this, target);
        }
    }    
    public void StartTimeWarpProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartTimeWarpProcess() called");
        Ability timeWarp = mySpellBook.GetAbilityByName("Time Warp");

        if (EntityLogic.IsTargetInRange(this, target, timeWarp.abilityRange)
            && EntityLogic.IsAbilityUseable(this, timeWarp, target))
        {
            awaitingTimeWarpOrder = false;
            AbilityLogic.Instance.PerformTimeWarp(this, target);
        }
    }
    public void StartSpiritVisionProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartSpiritVisionProcess() called");
        Ability spiritVision = mySpellBook.GetAbilityByName("Spirit Vision");

        if (EntityLogic.IsTargetInRange(this, target, spiritVision.abilityRange)
            && EntityLogic.IsAbilityUseable(this, spiritVision, target))
        {
            awaitingSpiritVisionOrder = false;
            AbilityLogic.Instance.PerformSpiritVision(this, target);
        }
    }
    public void StartHasteProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartHasteProcess() called");
        Ability haste = mySpellBook.GetAbilityByName("Haste");

        if (EntityLogic.IsTargetInRange(this, target, haste.abilityRange)
            && EntityLogic.IsAbilityUseable(this, haste, target))
        {
            awaitingHasteOrder = false;
            AbilityLogic.Instance.PerformHaste(this, target);
        }
    }
    public void StartSteadyHandsProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartSteadyHandsProcess() called");
        Ability steadyHands = mySpellBook.GetAbilityByName("Steady Hands");

        if (EntityLogic.IsTargetInRange(this, target, steadyHands.abilityRange)
            && EntityLogic.IsAbilityUseable(this, steadyHands, target))
        {
            awaitingSteadyHandsOrder = false;
            AbilityLogic.Instance.PerformSteadyHands(this, target);
        }
    }
    public void StartEvasionProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartEvasionProcess() called");
        Ability evasion = mySpellBook.GetAbilityByName("Evasion");

        if (EntityLogic.IsTargetInRange(this, target, evasion.abilityRange)
            && EntityLogic.IsAbilityUseable(this, evasion, target))
        {
            awaitingEvasionOrder = false;
            AbilityLogic.Instance.PerformEvasion(this, target);
        }
    }
    public void StartBurstOfKnowledgeProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartBurstOfKnowledgeProcess() called");
        Ability burstOfKnowledge = mySpellBook.GetAbilityByName("Burst Of Knowledge");

        if (EntityLogic.IsTargetInRange(this, target, burstOfKnowledge.abilityRange)
            && EntityLogic.IsAbilityUseable(this, burstOfKnowledge, target))
        {
            awaitingBurstOfKnowledgeOrder = false;
            AbilityLogic.Instance.PerformBurstOfKnowledge(this, target);
        }
    }
    public void StartMirageProcess(Defender targetOfEvasion)
    {
        Debug.Log("Defender.StartMirageProcess() called");
        Ability mirage = mySpellBook.GetAbilityByName("Mirage");

        if (EntityLogic.IsTargetInRange(this, targetOfEvasion, mirage.abilityRange)
            && EntityLogic.IsAbilityUseable(this, mirage, targetOfEvasion))
        {
            awaitingMirageOrder = false;
            AbilityLogic.Instance.PerformMirage(this, targetOfEvasion);
        }
    }
    public void StartChargeLocationSettingProcess()
    {
        Ability charge = mySpellBook.GetAbilityByName("Charge");

        TargetingPathRenderer.Instance.DeactivatePathRenderer();
        PathRenderer.Instance.ActivatePathRenderer();

        Debug.Log("Defender.StartChargeLocationSettingProcess() called");
        Enemy enemyTarget = EnemyManager.Instance.selectedEnemy;
        if (EntityLogic.IsTargetInRange(this, enemyTarget, charge.abilityPrimaryValue + EntityLogic.GetTotalMobility(this))
            && EntityLogic.IsAbilityUseable(this, charge, enemyTarget))
        {
            awaitingChargeLocationOrder = true;
            awaitingChargeTargetOrder = false;

            List<Tile> tilesWithinChargeRangeOfCharacter = LevelManager.Instance.GetValidMoveableTilesWithinRange(charge.abilityPrimaryValue + EntityLogic.GetTotalMobility(this), tile);
            List<Tile> tilesWithinMeleeRangeOfTarget = LevelManager.Instance.GetValidMoveableTilesWithinRange(currentMeleeRange, enemyTarget.tile);
            List<Tile> validChargeLocationTiles = new List<Tile>();

            foreach (Tile tile in tilesWithinMeleeRangeOfTarget)
            {
                if (tilesWithinChargeRangeOfCharacter.Contains(tile))
                {
                    validChargeLocationTiles.Add(tile);
                }
            }

            LevelManager.Instance.UnhighlightAllTiles();
            LevelManager.Instance.HighlightTiles(validChargeLocationTiles);

        }
    }
    public void StartChargeProcess(Tile destination)
    {
        Enemy enemyTarget = EnemyManager.Instance.selectedEnemy;
        Ability charge = mySpellBook.GetAbilityByName("Charge");

        List<Tile> tilesWithinChargeRangeOfCharacter = LevelManager.Instance.GetValidMoveableTilesWithinRange(charge.abilityPrimaryValue + EntityLogic.GetTotalMobility(this), tile, true);
        List<Tile> tilesWithinMeleeRangeOfTarget = LevelManager.Instance.GetValidMoveableTilesWithinRange(currentMeleeRange, enemyTarget.tile);
        List<Tile> validChargeLocationTiles = new List<Tile>();

        foreach (Tile tile in tilesWithinMeleeRangeOfTarget)
        {
            if (tilesWithinChargeRangeOfCharacter.Contains(tile))
            {
                validChargeLocationTiles.Add(tile);
            }
        }

        if (validChargeLocationTiles.Contains(destination))
        {
            awaitingChargeLocationOrder = false;
            awaitingChargeTargetOrder = false;
            AbilityLogic.Instance.PerformCharge(this, enemyTarget, destination);
        }
        else
        {
            InvalidActionManager.Instance.ShowNewErrorMessage("Location is out of range");
        }
        
    }
    public void StartGuardProcess(LivingEntity targetOfGuard)
    {
        Ability guard = mySpellBook.GetAbilityByName("Guard");

        if (EntityLogic.IsTargetInRange(this, targetOfGuard, guard.abilityRange)
            && EntityLogic.IsAbilityUseable(this, guard, targetOfGuard))
        {
            awaitingGuardOrder = false;
            AbilityLogic.Instance.PerformGuard(this, targetOfGuard);
        }
    }
    public void StartFortifyProcess(LivingEntity targetOfGuard)
    {
        Ability fortify = mySpellBook.GetAbilityByName("Fortify");

        if (EntityLogic.IsTargetInRange(this, targetOfGuard, fortify.abilityRange)
            && EntityLogic.IsAbilityUseable(this, fortify, targetOfGuard))
        {
            awaitingFortifyOrder = false;
            AbilityLogic.Instance.PerformFortify(this, targetOfGuard);
        }
    }
    public void StartFrostArmourProcess(LivingEntity target)
    {
        Ability frostArmour = mySpellBook.GetAbilityByName("Frost Armour");

        if (EntityLogic.IsTargetInRange(this, target, frostArmour.abilityRange)
            && EntityLogic.IsAbilityUseable(this, frostArmour, target))
        {
            awaitingFrostArmourOrder = false;
            AbilityLogic.Instance.PerformFrostArmour(this, target);
        }
    }
    public void StartForestMedicineProcess(LivingEntity target)
    {
        Ability forestMedicine = mySpellBook.GetAbilityByName("Forest Medicine");

        if (EntityLogic.IsTargetInRange(this, target, forestMedicine.abilityRange)
            && EntityLogic.IsAbilityUseable(this, forestMedicine, target))
        {
            awaitingForestMedicineOrder = false;
            AbilityLogic.Instance.PerformForestMedicine(this, target);
        }
    }
    public void StartTelekinesisProcess(LivingEntity target, Tile destination)
    {        
        Ability telekinesis = mySpellBook.GetAbilityByName("Telekinesis");
        
        List<Tile> validTeleportLocations = LevelManager.Instance.GetValidMoveableTilesWithinRange(telekinesis.abilityPrimaryValue, target.tile, true);

        if (validTeleportLocations.Contains(destination))
        {
            awaitingTelekinesisTargetOrder = false;
            awaitingTelekinesisLocationOrder = false;
            AbilityLogic.Instance.PerformTelekinesis(this, target, destination);
        }
    }
    public void StartBlinkProcess(Tile destination)
    {
        Ability blink = mySpellBook.GetAbilityByName("Blink");

        List<Tile> validTeleportLocations = LevelManager.Instance.GetValidMoveableTilesWithinRange(blink.abilityRange, tile, true);

        if (validTeleportLocations.Contains(destination))
        {
            awaitingBlinkOrder = false;
            AbilityLogic.Instance.PerformBlink(this, destination);
        }
    }
    public void StartDisengageProcess(Tile destination)
    {
        Ability disengage = mySpellBook.GetAbilityByName("Disengage");

        List<Tile> validTeleportLocations = LevelManager.Instance.GetValidMoveableTilesWithinRange(disengage.abilityRange, tile, true);

        if (validTeleportLocations.Contains(destination))
        {
            awaitingDisengageOrder = false;
            AbilityLogic.Instance.PerformDisengage(this, destination);
        }
    }
    public void StartPhoenixDiveProcess(Tile destination)
    {
        Ability phoenixDive = mySpellBook.GetAbilityByName("Phoenix Dive");

        List<Tile> validTeleportLocations = LevelManager.Instance.GetValidMoveableTilesWithinRange(phoenixDive.abilityRange, tile, true);

        if (validTeleportLocations.Contains(destination))
        {
            awaitingPhoenixDiveOrder = false;
            AbilityLogic.Instance.PerformPhoenixDive(this, destination);
        }

    }
    public void StartTelekinesisLocationSettingProcess(LivingEntity targetBeingTeleported)
    {
        Ability telekinesis = mySpellBook.GetAbilityByName("Telekinesis");

        Debug.Log("Defender.StartTelekinesisLocationSettingProcess() called");
        //Enemy target = EnemyManager.Instance.selectedEnemy;
        LivingEntity target = targetBeingTeleported;
        if (EntityLogic.IsTargetInRange(this, target, telekinesis.abilityRange)
            && EntityLogic.IsAbilityUseable(this, telekinesis, target))
        {
            awaitingTelekinesisTargetOrder = false;
            awaitingTelekinesisLocationOrder = true;

            List<Tile> tilesWithinTeleportingRangeOfTarget = LevelManager.Instance.GetValidMoveableTilesWithinRange(telekinesis.abilityPrimaryValue, target.tile);

            LevelManager.Instance.UnhighlightAllTiles();
            LevelManager.Instance.HighlightTiles(tilesWithinTeleportingRangeOfTarget);
            myCurrentTarget = target;
        }
    }
    public void StartFrostBoltProcess(LivingEntity target)
    {
        Ability frostbolt = mySpellBook.GetAbilityByName("Frost Bolt");
        Debug.Log("Defender.StartFrostBoltProcess() called");

        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, frostbolt))
            && EntityLogic.IsAbilityUseable(this, frostbolt, target))
        {                      
            awaitingFrostBoltOrder = false;            
            AbilityLogic.Instance.PerformFrostBolt(this, target);
        }
    }
    public void StartThawProcess(LivingEntity target)
    {
        Ability thaw = mySpellBook.GetAbilityByName("Thaw");
        Debug.Log("Defender.StartThawProcess() called");

        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this,thaw))
            && EntityLogic.IsAbilityUseable(this, thaw, target))
        {
            awaitingThawOrder = false;
            AbilityLogic.Instance.PerformThaw(this, target);
        }
    }
    public void StartFireBallProcess(LivingEntity target)
    {
        Ability fireball = mySpellBook.GetAbilityByName("Fire Ball");
        Debug.Log("Defender.StartFireBallProcess() called");        
        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, fireball))
            && EntityLogic.IsAbilityUseable(this, fireball, target))
        {
            awaitingFireBallOrder = false;
            AbilityLogic.Instance.PerformFireBall(this, target);                       
        }
    }
    public void StartMeltProcess(LivingEntity target)
    {
        Ability melt = mySpellBook.GetAbilityByName("Melt");
        Debug.Log("Defender.StartMeltProcess() called");
        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, melt))
            && EntityLogic.IsAbilityUseable(this, melt, target))
        {
            awaitingMeltOrder = false;
            AbilityLogic.Instance.PerformMelt(this, target);
        }
    }
    public void StartShadowBlastProcess(LivingEntity target)
    {
        Ability shadowBlast = mySpellBook.GetAbilityByName("Shadow Blast");
        Debug.Log("Defender.StartShadowBlastProcess() called");
        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, shadowBlast))
            && EntityLogic.IsAbilityUseable(this, shadowBlast, target))
        {
            awaitingShadowBlastOrder = false;
            AbilityLogic.Instance.PerformShadowBlast(this, target);
        }
    }
    public void StartLightningBoltProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartLightningBoltProcess() called");
        Ability lightningBolt = mySpellBook.GetAbilityByName("Lightning Bolt");
        
        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, lightningBolt))
            && EntityLogic.IsAbilityUseable(this, lightningBolt, target))
        {
            awaitingLightningBoltOrder = false;
            AbilityLogic.Instance.PerformLightningBolt(this, target);
        }
    }
    public void StartDimensionalBlastProcess(LivingEntity target)
    {
        Debug.Log("Defender.DimesionalBlastProcess() called");

        Ability dimensionalBlast = mySpellBook.GetAbilityByName("Dimensional Blast");        
        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, dimensionalBlast))
            && EntityLogic.IsAbilityUseable(this, dimensionalBlast, target))
        {
            awaitingDimensionalBlastOrder = false;
            AbilityLogic.Instance.PerformDimensionalBlast(this, target);
        }
    }
    public void StartShootProcess()
    {
        Debug.Log("Defender.StartShootProcess() called");

        Ability shoot = mySpellBook.GetAbilityByName("Shoot");
        Enemy enemyTarget = EnemyManager.Instance.selectedEnemy;

        if (EntityLogic.IsTargetInRange(this, enemyTarget, EntityLogic.GetTotalRangeOfRangedAttack(this, shoot))
            && EntityLogic.IsAbilityUseable(this, shoot, enemyTarget))
        {
            awaitingShootOrder = false;
            AbilityLogic.Instance.PerformShoot(this, enemyTarget);
        }
    }
    public void StartPinningShotProcess()
    {        
        Debug.Log("Defender.StartPinningShotProcess() called");

        Ability ps = mySpellBook.GetAbilityByName("Pinning Shot");
        Enemy enemyTarget = EnemyManager.Instance.selectedEnemy;

        if (EntityLogic.IsTargetInRange(this, enemyTarget, EntityLogic.GetTotalRangeOfRangedAttack(this, ps))
            && EntityLogic.IsAbilityUseable(this, ps, enemyTarget))
        {
            awaitingPinningShotOrder = false;
            AbilityLogic.Instance.PerformPinningShot(this, enemyTarget);
        }
    }
    public void StartSnipeProcess()
    {
        Ability snipe = mySpellBook.GetAbilityByName("Snipe");
        Debug.Log("Defender.StartSnipeProcess() called");
        Enemy enemyTarget = EnemyManager.Instance.selectedEnemy;
        if (EntityLogic.IsTargetInRange(this, enemyTarget, EntityLogic.GetTotalRangeOfRangedAttack(this, snipe))
            && EntityLogic.IsAbilityUseable(this, snipe, enemyTarget))
        {
            awaitingSnipeOrder = false;
            AbilityLogic.Instance.PerformSnipe(this, enemyTarget);
        }
    }
    public void StartHeadShotProcess(LivingEntity target)
    {
        Ability headShot = mySpellBook.GetAbilityByName("Head Shot");
        Debug.Log("Defender.HeadShotProcess() called");
        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, headShot))
            && EntityLogic.IsAbilityUseable(this, headShot, target))
        {
            awaitingHeadShotOrder = false;
            AbilityLogic.Instance.PerformHeadShot(this, target);
        }
    }
    public void StartRapidFireProcess(LivingEntity target)
    {
        Ability rapidFire = mySpellBook.GetAbilityByName("Rapid Fire");
        Debug.Log("Defender.HeadShotProcess() called");

        // if target is in range and shooter has enough energy to make at least 1 shot
        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, rapidFire)) &&
            currentEnergy >= 10
            && EntityLogic.IsAbilityUseable(this, rapidFire, target))
        {
            awaitingRapidFireOrder = false;
            AbilityLogic.Instance.PerformRapidFire(this, target);
        }
    }
    public void StartSuperConductorProcess(LivingEntity target)
    {
        Ability superConductor = mySpellBook.GetAbilityByName("Super Conductor");
        Debug.Log("Defender.SuperConductorProcess() called");

        // if target is in range and shooter has enough energy to make at least 1 shot
        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, superConductor)) &&
            currentEnergy >= 10
            && EntityLogic.IsAbilityUseable(this, superConductor, target))
        {
            awaitingSuperConductorOrder = false;
            AbilityLogic.Instance.PerformSuperConductor(this, target);
        }
    }
    public void StartDimensionalHexProcess(LivingEntity target)
    {
        Ability dimensionalHex = mySpellBook.GetAbilityByName("Dimensional Hex");
        Debug.Log("Defender.DimensionalHexProcess() called");

        if (EntityLogic.IsTargetInRange(this, target, dimensionalHex.abilityRange)
            && EntityLogic.IsAbilityUseable(this, dimensionalHex, target)) 
        {
            awaitingDimensionalHexOrder = false;
            AbilityLogic.Instance.PerformDimensionalHex(this, target);
        }
    }
    public void StartCombustionProcess(LivingEntity target)
    {
        Ability combustion = mySpellBook.GetAbilityByName("Combustion");
        Debug.Log("Defender.CombustionProcess() called");

        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, combustion))
            && EntityLogic.IsAbilityUseable(this, combustion, target))
        {
            awaitingCombustionOrder = false;
            AbilityLogic.Instance.PerformCombustion(this, target);
        }
    }
    public void StartSliceAndDiceProcess(LivingEntity target)
    {
        Debug.Log("Defender.StartSliceAndDiceProcess() called");
        Ability sliceAndDice = mySpellBook.GetAbilityByName("Slice And Dice");

        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, sliceAndDice, target))
        {
            awaitingSliceAndDiceOrder = false;
            AbilityLogic.Instance.PerformSliceAndDice(this, target);
        }
    }
   
    public void StartChemicalReactionProcess(LivingEntity target)
    {
        Debug.Log("Defender.ChemicalReactionProcess() called");

        Ability chemicalReaction = mySpellBook.GetAbilityByName("Chemical Reaction");   

        if (EntityLogic.IsTargetInRange(this, target, chemicalReaction.abilityRange)
            && EntityLogic.IsAbilityUseable(this, chemicalReaction, target))
        {
            awaitingChemicalReactionOrder = false;
            AbilityLogic.Instance.PerformChemicalReaction(this, target);
        }
    }
    public void StartDrainProcess(LivingEntity target)
    {
        Debug.Log("Defender.DrainProcess() called");

        Ability drain = mySpellBook.GetAbilityByName("Drain");

        if (EntityLogic.IsTargetInRange(this, target, drain.abilityRange)
            && EntityLogic.IsAbilityUseable(this, drain, target))
        {
            awaitingDrainOrder = false;
            AbilityLogic.Instance.PerformDrain(this, target);
        }
    }
    public void StartImpalingBoltProcess(LivingEntity target)
    {
        Ability impalingBolt = mySpellBook.GetAbilityByName("Impaling Bolt");

        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, impalingBolt))
            && EntityLogic.IsAbilityUseable(this, impalingBolt, target))
        {
            awaitingImpalingBoltOrder = false;            
            AbilityLogic.Instance.PerformImpalingBolt(this, target);
        }
    }   
    public void StartInvigorateProcess(LivingEntity target)
    {
        Ability invigorate = mySpellBook.GetAbilityByName("Invigorate");
        if (EntityLogic.IsTargetInRange(this, target, invigorate.abilityRange)
            && EntityLogic.IsAbilityUseable(this, invigorate, target))
        {
            awaitingInvigorateOrder = false;
            AbilityLogic.Instance.PerformInvigorate(this, target);
        }        
    }
    public void StartCreepingFrostProcess(LivingEntity target)
    {
        Ability creepingFrost = mySpellBook.GetAbilityByName("Creeping Frost");
        if (EntityLogic.IsTargetInRange(this, target, creepingFrost.abilityRange)
            && EntityLogic.IsAbilityUseable(this, creepingFrost, target))
        {
            awaitingCreepingFrostOrder = false;
            AbilityLogic.Instance.PerformCreepingFrost(this, target);
        }
    }
    public void StartBlazeProcess(LivingEntity target)
    {
        Ability blaze = mySpellBook.GetAbilityByName("Blaze");
        if (EntityLogic.IsTargetInRange(this, target, blaze.abilityRange)
            && EntityLogic.IsAbilityUseable(this, blaze, target))
        {
            awaitingBlazeOrder = false;
            AbilityLogic.Instance.PerformBlaze(this, target);
        }
    }
    public void StartOverloadProcess(LivingEntity target)
    {
        Ability overload = mySpellBook.GetAbilityByName("Overload");
        if (EntityLogic.IsTargetInRange(this, target, overload.abilityRange)
            && EntityLogic.IsAbilityUseable(this, overload, target))
        {
            awaitingOverloadOrder = false;
            AbilityLogic.Instance.PerformOverload(this, target);
        }
    }
    public void StartShadowWreathProcess(LivingEntity target)
    {
        Ability shadowWreath = mySpellBook.GetAbilityByName("Shadow Wreath");
        if (EntityLogic.IsTargetInRange(this, target, shadowWreath.abilityRange)
            && EntityLogic.IsAbilityUseable(this, shadowWreath, target))
        {
            awaitingShadowWreathOrder = false;
            AbilityLogic.Instance.PerformShadowWreath(this, target);
        }
    }
    public void StartSnowStasisProcess(LivingEntity target)
    {
        Ability st = mySpellBook.GetAbilityByName("Snow Stasis");
        if (EntityLogic.IsTargetInRange(this, target, st.abilityRange)
            && EntityLogic.IsAbilityUseable(this, st, target))
        {
            awaitingSnowStasisOrder = false;
            AbilityLogic.Instance.PerformSnowStasis(this, target);
        }
    }
   
    public void StartHolyFireProcess(LivingEntity target)
    {   
        Ability holyFire = mySpellBook.GetAbilityByName("Holy Fire");

        if (EntityLogic.IsTargetInRange(this, target, holyFire.abilityRange)
            && EntityLogic.IsAbilityUseable(this, holyFire, target))
        {
            awaitingHolyFireOrder = false;
            AbilityLogic.Instance.PerformHolyFire(this, target);
        }
    }
    public void StartPrimalRageProcess(LivingEntity target)
    {        
        Ability primalRage = mySpellBook.GetAbilityByName("Primal Rage");

        if (EntityLogic.IsTargetInRange(this, target, primalRage.abilityRange)
            && EntityLogic.IsAbilityUseable(this, primalRage, target))
        {
            awaitingPrimalRageOrder = false;
            AbilityLogic.Instance.PerformPrimalRage(this, target);
        }                
    }
    public void StartPhaseShiftProcess(LivingEntity target)
    {
        Ability phaseShift = mySpellBook.GetAbilityByName("Phase Shift");

        if (EntityLogic.IsTargetInRange(this, target, phaseShift.abilityRange)
            && EntityLogic.IsAbilityUseable(this, phaseShift, target))
        {
            awaitingPhaseShiftOrder = false;
            AbilityLogic.Instance.PerformPhaseShift(this, target);
        }       
          
    }
 
    public void StartChaosBoltProcess(LivingEntity target)
    {
        Ability chaosBolt = mySpellBook.GetAbilityByName("Chaos Bolt");

        if (EntityLogic.IsTargetInRange(this, target, EntityLogic.GetTotalRangeOfRangedAttack(this, chaosBolt))
            && EntityLogic.IsAbilityUseable(this, chaosBolt, target))
        {
            awaitingChaosBoltOrder = false;
            AbilityLogic.Instance.PerformChaosBolt(this, target);
        }
    }
    
    public void StartBlessProcess(LivingEntity target)
    {
        Ability bless = mySpellBook.GetAbilityByName("Bless");

        if (EntityLogic.IsTargetInRange(this, target, bless.abilityRange)
            && EntityLogic.IsAbilityUseable(this, bless, target))
        {
            awaitingBlessOrder = false;
            AbilityLogic.Instance.PerformBless(this, target);
        }
    }
    
    public void StartNightmareProcess(LivingEntity target)
    {
        Ability nightmare = mySpellBook.GetAbilityByName("Nightmare");
        if (EntityLogic.IsTargetInRange(this, target, nightmare.abilityRange)
            && EntityLogic.IsAbilityUseable(this, nightmare, target))
        {
            awaitingNightmareOrder = false;
            AbilityLogic.Instance.PerformNightmare(this, target);
        }
        
    }
    public void StartTwinStrikeProcess(LivingEntity target)
    {        
        Debug.Log("Defender.StartTwinStrikeProcess() called");
        Ability twinStrike = mySpellBook.GetAbilityByName("Twin Strike");

        //Enemy enemyTarget = EnemyManager.Instance.selectedEnemy;
        if (EntityLogic.IsTargetInRange(this, target, currentMeleeRange)
            && EntityLogic.IsAbilityUseable(this, twinStrike, target))
        {
            awaitingTwinStrikeOrder = false;
            AbilityLogic.Instance.PerformTwinStrike(this, target);
        }
    }
    #endregion








}

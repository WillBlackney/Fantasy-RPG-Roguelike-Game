﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New AbilityDataSO", menuName = "AbilityDataSO", order = 53)]
[Serializable]
public class AbilityDataSO : ScriptableObject
{
    public enum DamageType { None, Physical, Magic, Poison, Frost, Fire, Shadow, Air};
    public enum AbilityType { None, Skill, MeleeAttack, RangedAttack, Power};
    public enum AbilitySchool { None, Brawler, Duelist, Assassination, Guardian, Pyromania, Cyromancy, Ranger, Manipulation,
    Divinity, Shadowcraft, Corruption, Naturalism};


    [Header("Ability Type Properties")]
    public DamageType damageType;
    public AbilityType abilityType;
    public AbilitySchool abilitySchool;
    public UniversalCharacterModel.ModelRace abilityRace;
    public int tier;

    [Header("Ability Properties")]
    public Sprite sprite;
    public string abilityName;
    public string description;    
    public int baseCooldownTime;    
    public int energyCost;
    public int range;
    public int primaryValue;
    public int secondaryValue;

    [Header("Ability Requirments")]
    public bool requiresMeleeWeapon;
    public bool requiresRangedWeapon;
    public bool requiresShield;

    [Header("Attack Specific Properties")]
    public float weaponDamagePercentage;

  
}

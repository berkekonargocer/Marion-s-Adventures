using System;
using NOJUMPO.AudioEventSystem;
using NOJUMPO.DamageableSystem;
using UnityEngine;

namespace NOJUMPO.WeaponSystem
{
    [Serializable]
    public struct WeaponData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public int MinDamage { get; private set; }
        [field: SerializeField] public int MaxDamage { get; private set; }
        [field: SerializeField] public DamageTypeSO DamageType { get; private set; }
        [field: SerializeField] public bool DoesKnockback { get; private set; }
        [field: SerializeField] public float KnockbackForce { get; private set; }
        [field: SerializeField] public SimpleAudioEventSO AttackAudioEvent { get; private set; }
        [field: SerializeField] public SimpleAudioEventSO AttackHitAudioEvent { get; private set; }
    }
}
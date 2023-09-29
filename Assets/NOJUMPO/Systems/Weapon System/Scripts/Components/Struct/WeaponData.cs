using System;
using Nojumpo.AudioEventSystem;
using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    [Serializable]
    public struct WeaponData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public int MinDamage { get; private set; }
        [field: SerializeField] public int MaxDamage { get; private set; }
        [field: SerializeField] public DamageTypeSO DamageType { get; private set; }
        [field: SerializeField] public SimpleAudioEventSO AttackAudioEvent { get; private set; }
    }
}
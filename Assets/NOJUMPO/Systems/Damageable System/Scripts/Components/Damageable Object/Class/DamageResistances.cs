using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nojumpo.DamageableSystem
{
    [Serializable]
    public class DamageResistances
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] List<DamageResistance> resistances;


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public float CalculateDamageWithResistances(float damageAmount, DamageTypeSO damageType) {
            for (int i = resistances.Count - 1; i >= 0; i--)
            {
                if (resistances[i].DamageType == damageType)
                {
                    return damageAmount * resistances[i].PercentageToTake / 100;
                }
            }

            return damageAmount;
        }
    }
}
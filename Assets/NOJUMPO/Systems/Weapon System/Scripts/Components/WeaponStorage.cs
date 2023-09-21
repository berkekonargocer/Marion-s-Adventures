using System;

namespace Nojumpo.WeaponSystem
{
    /// <summary>
    /// Add a list of weapons?
    /// </summary>
    public class WeaponStorage
    {
        // -------------------------------- FIELDS --------------------------------
        public int WeaponCount { get; private set; }

        // ----------------------------- CONSTRUCTORS -----------------------------


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public WeaponSO GetCurrentWeapon() {
            throw new NotImplementedException();
        }

        public WeaponSO SwapWeapon() {
            throw new NotImplementedException();
        }
        
        public void AddWeapon(WeaponSO weaponSO) {
            throw new NotImplementedException();
        }
    }
}
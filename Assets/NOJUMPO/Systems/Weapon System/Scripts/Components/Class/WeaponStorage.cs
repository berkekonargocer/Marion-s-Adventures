using System.Collections.Generic;
using UnityEngine;

namespace NOJUMPO.WeaponSystem
{
    public class WeaponStorage
    {
        // -------------------------------- FIELDS --------------------------------
        List<WeaponSO> _weaponList = new List<WeaponSO>();
        int _currentWeaponIndex = -1;
        bool _swapWeaponOnPickUp = true;

        public int WeaponCount { get { return _weaponList.Count; } }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public WeaponSO GetCurrentWeapon() {
            return _currentWeaponIndex <= -1 ? null : _weaponList[_currentWeaponIndex];
        }

        public WeaponSO SwapWeapon() {
            if (_currentWeaponIndex <= -1)
                return null;

            _currentWeaponIndex++;

            if (_currentWeaponIndex >= _weaponList.Count)
                _currentWeaponIndex = 0;

            return _weaponList[_currentWeaponIndex];
        }

        public bool AddWeapon(WeaponSO weaponSO) {
            if (_weaponList.Contains(weaponSO))
                return false;

            _weaponList.Add(weaponSO);

            if (_swapWeaponOnPickUp)
            {
                _currentWeaponIndex = _weaponList.Count - 1;
            }

            Debug.Log($"Weapon {weaponSO} added to weapons");
            return true;
        }

        public List<string> GetPlayerWeaponNames() {
            List<string> weaponNames = new List<string>();

            for (int i = 0; i < _weaponList.Count; i++)
            {
                weaponNames.Add(_weaponList[i].name);
            }

            return weaponNames;
        }
    }
}
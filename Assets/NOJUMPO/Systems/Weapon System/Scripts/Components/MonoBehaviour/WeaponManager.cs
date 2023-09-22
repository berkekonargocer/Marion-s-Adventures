using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.WeaponSystem
{
    public class WeaponManager : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        SpriteRenderer _spriteRenderer;

        WeaponStorage _weaponStorage;

        public UnityEvent<Sprite> OnWeaponSwap;
        public UnityEvent OnMultipleWeapons;
        public UnityEvent OnWeaponPickUp;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _weaponStorage = new WeaponStorage();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            ToggleWeaponVisibility(false);
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void ToggleWeaponVisibility(bool isVisible) {
            if (isVisible)
            {
                SwapWeaponSprite(GetCurrentWeapon().WeaponData.WeaponSprite);
            }

            _spriteRenderer.enabled = isVisible;
        }

        void SwapWeaponSprite(Sprite weaponSprite) {
            _spriteRenderer.sprite = weaponSprite;
            OnWeaponSwap?.Invoke(weaponSprite);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public WeaponSO GetCurrentWeapon() {
            return _weaponStorage.GetCurrentWeapon();
        }

        public void SwapWeapon() {
            if (_weaponStorage.WeaponCount <= 0)
                return;

            SwapWeaponSprite(_weaponStorage.SwapWeapon().WeaponData.WeaponSprite);
        }

        public void AddWeapon(WeaponSO weaponSO) {
            if (_weaponStorage.AddWeapon(weaponSO) == false)
                return;

            if (_weaponStorage.WeaponCount == 2)
            {
                OnMultipleWeapons?.Invoke();
            }

            SwapWeaponSprite(weaponSO.WeaponData.WeaponSprite);
        }

        public void PickUpWeapon(WeaponSO weaponSO) {
            AddWeapon(weaponSO);
            OnWeaponPickUp?.Invoke();
        }

        public bool CanUseWeapone(bool isGrounded) {
            if (_weaponStorage.WeaponCount <= 0)
                return false;

            return _weaponStorage.GetCurrentWeapon().CanBeUsed(isGrounded);
        }

        public List<string> GetPlayerWeaponNames() {
            return _weaponStorage.GetPlayerWeaponNames();
        }
    }
}
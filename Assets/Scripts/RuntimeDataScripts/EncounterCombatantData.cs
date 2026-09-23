using UnityEngine;
using System.Collections.Generic;

namespace Encounter
{
    public sealed class EncounterCombatantData
    {
        private bool _isPlayer;
        private bool _health;
        private List<EncounterStatusEffect> _activeStatusEffects;

        //===================
        // PUBLIC PROPERTIES
        //===================
        public bool IsPlayer {  get { return _isPlayer; } private set { _isPlayer = value; } }
        public bool Health { get { return _health; } set { _health = value; } }
        // ^^if _health < 0, then -_health indicates the amount of overkill

        public IReadOnlyList<EncounterStatusEffect> ActiveStatusEffects { get { return _activeStatusEffects; } }

        //================
        // PUBLIC METHODS
        //================
        public void AddStatusEffect(EncounterStatusEffect addedEffect)
        {
            // if addedEffect is already added, don't add it again,
            // but *do* refresh its duration
            for (int i = 0; i < _activeStatusEffects.Count; i++)
            {
                EncounterStatusEffect effect = _activeStatusEffects[i];
                if (effect.EffectTag == addedEffect.EffectTag)
                {
                    effect.Duration = (addedEffect.Duration > effect.Duration)? addedEffect.Duration : effect.Duration;
                    return;
                }
            }
        }

        public bool TryRemoveStatusEffect(EncounterStatusEffect removedEffect)
        {
            for (int i = _activeStatusEffects.Count - 1; i >= 0 ; i--)
            {
                EncounterStatusEffect effect = _activeStatusEffects[i];
                if (effect.EffectTag == removedEffect.EffectTag)
                {
                    _activeStatusEffects.RemoveAt(i);
                    return true;
                }
            }
            return false;
            // false --> the effect is not in the list and cannot be removed
        }
    }
}


using UnityEngine;
using System.Collections.Generic;

namespace Encounter
{

    public interface ICombatantObject
    {
        // a standardized API surface here to tell it things like
        // PlayReact(), PlayAttack(), PlayDie(), etc.
        // with varying implementation from one combatant to
        // the next.
        //...
    }

    public sealed class EncounterCombatantData
    {
        /*
        This is the information provided to the EncounterManager when the 
        encounter begins, and is manipulated by the EncounterManager as
        the encounter progresses to conclusion. It should contain *ONLY* 
        and *ANY* information about this combatant that will be needed
        during the encounter, and an API surface for manipulating its
        internal contents.
         */

        private string _displayName;

        private string _combatantUUID;

        private int _health;
        // if _health is < 0, then the combatant is dead, and
        // (health * -1) indicates the amount of "overkill"

        private int _armor;


        private ICombatantObject _combatantObject;

        private CombatantVariant _variant = CombatantVariant.NONE;
        // ^^NONE, PLAYER, MINION, HEAVY, BIG_BOSS

        private DiceCollection _drawBag;
        // If this combatant is CombatantVariant.PLAYER, then this will contain
        //   the dice they chose from their persistent collection for this
        //   encounter.
        // Otherwise, (i.e. if this some variety of NPC), then this will contain
        //   the dice assigned 

        private DiceCollection _inHand;
        private DiceCollection _discardBag;

        private List<EncounterStatusEffect> _activeStatusEffects;

        // Public getters and setters for ^^above
        //...



        //===================
        // PUBLIC PROPERTIES
        //===================
        //public bool IsPlayer {  get { return _isPlayer; } private set { _isPlayer = value; } }
        public int Health { get { return _health; } set { _health = value; } }
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

    public sealed class ResolverCombatantData
    {
        // the resolver doesn't need the GameObject.
        // just the integer value and the tags. So this
        // is just a lightweight version of the above

        private CombatantVariant _variant;
        private int _health;
        private List<EncounterStatusEffect> _activeStatusEffects;

        public CombatantVariant Varient {  get { return _variant; } }
        public int Health { get { return _health; } }
        public IReadOnlyList<EncounterStatusEffect> ActiveStatusEffects {  get { return _activeStatusEffects; } }

        public ResolverCombatantData(CombatantVariant variant, int health, List<EncounterStatusEffect> activeStatusEffects)
        {
            _variant = variant;
            _health = health;
            _activeStatusEffects = activeStatusEffects;
        }
    }
}


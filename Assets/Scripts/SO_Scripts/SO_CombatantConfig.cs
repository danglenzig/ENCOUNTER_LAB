using UnityEngine;
using System.Collections.Generic;
using Dice;

namespace Encounter
{
    //====================
    // PLACEHOLDER CLASSES: Delete later...
    //====================
    public class SO_StatusEffect { }
    public class SO_DiceBag { }
    //====================



    [CreateAssetMenu(fileName = "SO_CombatantConfig", menuName = "Combatants/Combatant Config")]
    public class SO_CombatantConfig : ScriptableObject
    {

        [SerializeField] private string _displayName = "Namey Nameson";
        [SerializeField] private string _combatantID = "";
        [SerializeField] private int _health = 20;
        [SerializeField] private int _armor = 0;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private CombatantVariant _variant = CombatantVariant.NONE;
        
        // TODO...
        [SerializeField] private List<SO_StatusEffect> _activeStatusEffects = new List<SO_StatusEffect>();
        
        // TODO...
        [SerializeField] private SO_DiceBag _drawBag;

        private DiceCollection _inHand = new DiceCollection();
        private DiceCollection _discardBag = new DiceCollection();

        public EncounterCombatantData GetRuntimeData()
        {
            EncounterCombatantData data = new EncounterCombatantData();
            data.DisplayName   = _displayName;
            data.CombatantUUID = _combatantID;
            data.Variant       = _variant;
            data.Health        = _health;
            data.Armor         = _armor;
            //data.DrawBag = _drawBag.GetRuntimeData()
            // ^^TODO

            foreach(SO_StatusEffect sO_Effect in _activeStatusEffects)
            {
                // TODO
                //data.ActiveStatusEffects.Add(sO_Effect.GetRuntimeData());
            }
            return data;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;


namespace Encounter
{
    public class EncounterOutcomeData
    {
        public bool PlayerDied { get; set; } = false;
        public int TurnsPlayed { get; set; } = 0;
        public int TotalDamageDealt { get; set; } = 0;
        public int TotalDamageTaken { get; set; } = 0;
        public int TotalAmountHealed { get; set; } = 0;
        public int EnemyStrength { get; set; } = 0;
        public int DurationSeconds { get; set; } = 0;
        public List<string> PersistentStatusEffectTags {  get; private set; } = new List<string>();
    }
}


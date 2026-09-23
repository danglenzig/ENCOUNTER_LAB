using UnityEngine;
using System.Collections.Generic;
using Encounter;

namespace Dice
{
    public interface IResolver
    {
        public TurnOutcome GetTurnOutcome(ResolverInput resolverInput);
    }
    public sealed class CombatantOutcome
    {
        public string CombatantUUID { get; set; } = string.Empty;
        public int HealthAdjust { get; set; } = 0;
        public int ArmorAdjust { get; set; } = 0;
        public List<EncounterStatusEffect> AddedStatusEffects { get; private set; } = new List<EncounterStatusEffect>();
        public List<EncounterStatusEffect> RemovedStatusEffects { get; private set; } = new List<EncounterStatusEffect>();
    }

    public sealed class TurnOutcome
    {
        public CombatantOutcome PlayerOutcome { get; private set; } = new CombatantOutcome();
        public CombatantOutcome EnemyOutcome { get; private set; } = new CombatantOutcome();
    }

    public sealed class ResolverInput
    {
        public ResolverCombatantData PlayerResolverCombatantData { get; private set; }
        public List<ResolverDieFaceData> PlayerRollResult { get; private set; }
        public ResolverCombatantData EnemyResolverCombatantData { get; private set; }
        public List<ResolverDieFaceData> EnemyRollResult { get; private set; }

        public ResolverInput(
            ResolverCombatantData playerResolverCombatantData,
            ResolverCombatantData enemyResolverCombatantData,
            List<ResolverDieFaceData> playerRollResult,
            List<ResolverDieFaceData> enemyRollResult
            )
        {
            PlayerResolverCombatantData = playerResolverCombatantData;
            EnemyResolverCombatantData = enemyResolverCombatantData;
            PlayerRollResult = playerRollResult;
            EnemyRollResult = enemyRollResult;
        }
    }


    public sealed class DoNothingResolver : IResolver
    {
        public TurnOutcome GetTurnOutcome(ResolverInput resolverInput)
        {
            TurnOutcome blankOutcome = new TurnOutcome();
            return blankOutcome;
        }
    }
}

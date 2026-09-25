using UnityEngine;

namespace Encounter
{
    public sealed class DrawupStateBehaviors : IStateBehaviors
    {
        public void DoStateEnteredBehavior(EncounterManager em)
        {
            //
            EncounterCombatantData playerData = em.PlayerData;
        }
        public void DoStateExitedBehavior(EncounterManager em)
        {
            //...
        }
        public void DoUpdateBehavior(EncounterManager em)
        {
            //...
        }
    }
}


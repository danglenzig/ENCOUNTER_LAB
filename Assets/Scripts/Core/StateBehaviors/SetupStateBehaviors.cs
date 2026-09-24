using UnityEngine;

namespace Encounter
{
    
    public sealed class SetupStateBehaviors : IStateBehaviors
    {

        public void DoStateEnteredBehavior(EncounterManager em)
        {
            SetupEncounter(em);
        }
        public void DoStateExitedBehavior(EncounterManager em)
        {
            //...
        }
        public void DoUpdateBehavior(EncounterManager em)
        {
            //...
        }

        private void SetupEncounter(EncounterManager em)
        {
            // set everything up
            // - get the Current encounter data from the GameData singleton
            // - if no GameData singleton, get placeholder data from TestRig

            EncounterData data = new EncounterData(); // PLACEHOLDER
            // TODO: Replace ^^this with actual data from one of the two sources above

            em.Resolver = data.Resolver;
            em.PlayerData = data.PlayerData;
            em.EnemyDatas.AddRange(data.EnemyDatas);
            em.EncounterEnvironent = data.EncounterEnvironment;

            // finally...
            if (!em.StateMachine.TryTakeTransition(EncounterStates.DRAWUP))
            {
                Debug.LogError($"### {em.name}: Failed to transition to first Drawup state...");
            }
        }



    }
}


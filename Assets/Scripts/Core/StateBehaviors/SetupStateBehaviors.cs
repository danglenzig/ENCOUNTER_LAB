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
            //test that the resolver is set up
            Debug.Log($"### SetupStateBehaviors.DoStateExitedBehavior: {em.Resolver.SayHello()}");
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

            EncounterData data = null;

            if (false) // replace with null-check on GameData instance
            {
                // Get the data from the GameData instance
            }
            else
            {
                // Get the data from the test rig
                data = em.TestRig.GetEncounterData();
            }

            if (data == null)
            {
                // throw an error and return early
                Debug.LogError($"### SetupStateBehavior: problem getting the setup data");
                return;
            }

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


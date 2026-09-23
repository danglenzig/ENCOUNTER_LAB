using SimpleStateMachine;
using System.Xml.Linq;
using UnityEngine;

namespace Encounter
{
    
    public class SetupStateHandler
    {

        public void SetupEncounter(EncounterManager em)
        {
            // set everything up
            // - get the Current encounter data from the GameData singleton
            // - if no GameData singleton, get placeholder data from TestRig

            EncounterData data = new EncounterData();
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


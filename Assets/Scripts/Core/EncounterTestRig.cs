using Dice;
using UnityEngine;
using System.Collections.Generic;

namespace Encounter
{
    public sealed class EncounterTestRig : MonoBehaviour
    {
        [SerializeField] private string _encounterID = "ABCD_1234";
        [SerializeField] private SO_CombatantConfig _playerConfig;
        [SerializeField] private List<SO_CombatantConfig> _enemyConfigs;
        [SerializeField] private GameObject _environmentPrefab;
        private IResolver _resolver = new BlankResolver();

        public EncounterData GetEncounterData()
        {
            EncounterData d = new EncounterData();

            d.EncounterUUID = _encounterID;
            d.Resolver = _resolver;
            d.EncounterEnvironment = (_environmentPrefab.GetComponent<IEncounterEnvironent>() != null) ? _environmentPrefab.GetComponent<IEncounterEnvironent>() : null;

            // TODOs...
            //d.PlayerData = _playerConfig.GetRuntimeData(); // TODO
            List<EncounterCombatantData> enemyDatas = new List<EncounterCombatantData>();
            foreach (SO_CombatantConfig config in _enemyConfigs)
            {
                //enemyDatas.Add(config.GetRuntimeData()); // TODO
            }

            return d;
        }

    }
}


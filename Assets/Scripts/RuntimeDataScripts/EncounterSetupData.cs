using UnityEngine;
using System.Collections.Generic;
using Dice;

namespace Encounter
{
    public interface IEncounterEnvironent
    {
        // The on-screen environment GameObject will implement this
        // interface
        //...
    }

    public class EncounterData
    {
        private string _encounterUUID = string.Empty;
        // ^^will be unique for every encounter

        private IEncounterEnvironent _encounterEnvironent = null;

        private EncounterCombatantData _playerData = null;

        private List<EncounterCombatantData> _enemyDatas = new List<EncounterCombatantData>();

        private IResolver _resolver = null;

        public string EncounterUUIScript { get {  return _encounterUUID; } set { _encounterUUID = value; } }
        public IEncounterEnvironent EncounterEnvironment {  get { return _encounterEnvironent; } set { _encounterEnvironent = value; } }
        public EncounterCombatantData PlayerData { get { return _playerData; } set { _playerData = value; } }
        public List<EncounterCombatantData> EnemyDatas { get { return _enemyDatas; } set { _enemyDatas = value; } }
        public IResolver Resolver { get { return _resolver; } set { _resolver = value; } }



        // public getters and setters
        //...
    }
}


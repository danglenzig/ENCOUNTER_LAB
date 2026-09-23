using Dice;
using EventChannels;
using MiscTools;
using SimpleStateMachine;
using System.Collections.Generic;
using UnityEngine;


namespace Encounter
{
    [RequireComponent(typeof(EncounterTimer))]

    public class EncounterManager : MonoBehaviour
    {
        // serialized in the inspector
        [SerializeField] private bool _autoStartTimer = true;
        [SerializeField] private SO_SimpleStateMachine _stateMachineData;
        [SerializeField] private SO_EventEncounterOutcomeDataPayload _encounterOutcomeEvent;

        // Components
        private RuntimeSimpleStateMachine _stateMachine;
        public RuntimeSimpleStateMachine StateMachine { get { return _stateMachine; } }
        private EncounterTimer _timer;

        // initialize in Awake
        private SetupStateHandler _setupStateHandler = null;


        // From _setupStateHandler.SetupEncounter...
        public IResolver Resolver { get; set; } = null;
        public IEncounterEnvironent EncounterEnvironent { get; set; } = null;
        public EncounterCombatantData PlayerData { get; set; } = null;
        public List<EncounterCombatantData> EnemyDatas { get; private set; } = new List<EncounterCombatantData>();

        private void Awake()
        {
            _timer = GetComponent<EncounterTimer>();
            _stateMachine = _stateMachineData.GetRuntimeSimpleStateMachine();

            _setupStateHandler = new SetupStateHandler();
        }

        private void OnEnable()
        {
            _timer.CountIncremented += HandleTimerIncremented;
            _stateMachine.StateEntered += HandleStateEntered;
            _stateMachine.StateExited += HandleStateExited;

        }

        private void OnDisable()
        {
            _timer.CountIncremented -= HandleTimerIncremented;
            _stateMachine.StateEntered -= HandleStateEntered;
            _stateMachine.StateExited -= HandleStateExited;
        }

        void Start()
        {
            _setupStateHandler.SetupEncounter(this);

            if (_autoStartTimer)
            {
                _timer.SetTimerActive(true);
            }
        }

        /*
        void Update()
        {

        }
        */

        private void HandleTimerIncremented(int secondsPlayed)
        {
            Debug.Log($"### {name}: Seconds played: {secondsPlayed}");
        }

        private void HandleStateEntered(string enteredState)
        {
            Debug.Log($"### {name}: Current state: {_stateMachine.CurrentStateName}");

            switch (enteredState)
            {
                case EncounterStates.SETUP:
                    return;
                case EncounterStates.DRAWUP:
                    return;
                case EncounterStates.SELECT:
                    return;
                case EncounterStates.ROLLING:
                    return;
                case EncounterStates.RESOLUTION:
                    return;
                case EncounterStates.AFTERMATH:
                    return;
                case EncounterStates.PLAYER_DEAD:
                    return;
                case EncounterStates.PLAYER_WIN:
                    return;

                default:
                    return;
            }
        }

        private void HandleStateExited(string enteredState)
        {
            switch (enteredState)
            {
                case EncounterStates.SETUP:
                    return;
                case EncounterStates.DRAWUP:
                    return;
                case EncounterStates.SELECT:
                    return;
                case EncounterStates.ROLLING:
                    return;
                case EncounterStates.RESOLUTION:
                    return;
                case EncounterStates.AFTERMATH:
                    return;
                case EncounterStates.PLAYER_DEAD:
                    return;
                case EncounterStates.PLAYER_WIN:
                    return;

                default:
                    return;
            }
        }

        

        private void AnnounceOutcome()
        {
            EncounterOutcomeData data = new EncounterOutcomeData();

            // TODO: configure the outcome data

            // finally...
            _encounterOutcomeEvent.TriggerEvent(data);
        }

    }
}


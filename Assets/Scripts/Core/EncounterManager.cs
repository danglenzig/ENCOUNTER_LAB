using Dice;
using EventChannels;
using MiscTools;
using SimpleStateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace Encounter
{
    public interface IEncounterStateBehaviors
    {
        public void DoStateEnteredBehavior(EncounterManager em);
        public void DoStateExitedBehavior(EncounterManager em);
        public void DoUpdateBehavior(EncounterManager em);
    }

    [RequireComponent(typeof(EncounterTimer))]
    public class EncounterManager : MonoBehaviour
    {
        // Serialized in the inspector
        [SerializeField] private bool _autoStartTimer = true;
        [SerializeField] private SO_SimpleStateMachine _stateMachineData;
        [SerializeField] private SO_EventEncounterOutcomeDataPayload _encounterOutcomeEvent;

        // Taken from components
        private RuntimeSimpleStateMachine _stateMachine;
        public RuntimeSimpleStateMachine StateMachine { get { return _stateMachine; } }
        private EncounterTimer _timer;

        // Initialized in Awake
        private IEncounterStateBehaviors _setupStateBehaviors = null;
        private IEncounterStateBehaviors _drawupStateBehaviors = null;
        private IEncounterStateBehaviors _selectStateBehaviors = null;
        private IEncounterStateBehaviors _rollingStateBehaviors = null;
        private IEncounterStateBehaviors _resolutionStateBehaviors = null;
        private IEncounterStateBehaviors _aftermathStateBehaviors = null;
        private IEncounterStateBehaviors _playerWinStateBehaviors = null;
        private IEncounterStateBehaviors _playerDeadStateBehaviors = null;

        //=======================================================
        // anything the state behaviors need should be `public`
        public IResolver Resolver { get; set; } = null;
        public IEncounterEnvironent EncounterEnvironent { get; set; } = null;
        public EncounterCombatantData PlayerData { get; set; } = null;
        public List<EncounterCombatantData> EnemyDatas { get; private set; } = new List<EncounterCombatantData>();

        // and so on...
        //======================================================

        private void Awake()
        {
            _timer = GetComponent<EncounterTimer>();
            _stateMachine = _stateMachineData.GetRuntimeSimpleStateMachine();

            _setupStateBehaviors      = new SetupStateBehaviors();
            _drawupStateBehaviors     = new DrawupStateBehaviors();
            _selectStateBehaviors     = new SelectStateBehaviors();
            _rollingStateBehaviors    = new RollingStateBehaviors();
            _resolutionStateBehaviors = new ResolutionStateBehaviors();
            _aftermathStateBehaviors  = new AftermathStateBehaviors();
            _playerWinStateBehaviors  = new PlayerWinStateBehaviors();
            _playerDeadStateBehaviors = new PlayerDeadStateBehaviors();
        }

        private void OnEnable()
        {
            // Connect signals
            _timer.CountIncremented    += HandleTimerIncremented;
            _stateMachine.StateEntered += HandleStateEntered;
            _stateMachine.StateExited  += HandleStateExited;

        }

        private void OnDisable()
        {
            // Disconnect signals
            _timer.CountIncremented    -= HandleTimerIncremented;
            _stateMachine.StateEntered -= HandleStateEntered;
            _stateMachine.StateExited  -= HandleStateExited;
        }

        void Start()
        {
            _setupStateBehaviors.DoStateEnteredBehavior(this);

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
            //Debug.Log($"### {name}: Seconds played: {secondsPlayed}");
        }

        private void HandleStateEntered(string enteredState)
        {
            Debug.Log($"### {name}: Current state: {_stateMachine.CurrentStateName}");

            switch (enteredState)
            {
                case EncounterStates.SETUP:
                    // nothing here. SETUP is the initial state,
                    // so we execute these behaviors in Start()
                    return;
                case EncounterStates.DRAWUP:
                    _drawupStateBehaviors.DoStateEnteredBehavior(this);
                    return;
                case EncounterStates.SELECT:
                    _selectStateBehaviors.DoStateEnteredBehavior(this);
                    return;
                case EncounterStates.ROLLING:
                    _rollingStateBehaviors.DoStateEnteredBehavior(this);
                    return;
                case EncounterStates.RESOLUTION:
                    _resolutionStateBehaviors.DoStateEnteredBehavior(this);
                    return;
                case EncounterStates.AFTERMATH:
                    _aftermathStateBehaviors.DoStateEnteredBehavior(this);
                    return;
                case EncounterStates.PLAYER_DEAD:
                    _playerDeadStateBehaviors.DoStateEnteredBehavior(this);
                    return;
                case EncounterStates.PLAYER_WIN:
                    _playerWinStateBehaviors.DoStateEnteredBehavior(this);
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
                    _setupStateBehaviors.DoStateExitedBehavior(this);
                    return;
                case EncounterStates.DRAWUP:
                    _drawupStateBehaviors.DoStateExitedBehavior(this);
                    return;
                case EncounterStates.SELECT:
                    _setupStateBehaviors.DoStateExitedBehavior(this);
                    return;
                case EncounterStates.ROLLING:
                    _rollingStateBehaviors.DoStateExitedBehavior(this);
                    return;
                case EncounterStates.RESOLUTION:
                    _resolutionStateBehaviors.DoStateExitedBehavior(this);
                    return;
                case EncounterStates.AFTERMATH:
                    _aftermathStateBehaviors.DoStateExitedBehavior(this);
                    return;
                case EncounterStates.PLAYER_DEAD:
                    _playerDeadStateBehaviors.DoStateExitedBehavior(this);
                    return;
                case EncounterStates.PLAYER_WIN:
                    _playerWinStateBehaviors.DoStateExitedBehavior(this);
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


using Dice;
using EventChannels;
using MiscTools;
using SimpleStateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace Encounter
{
    public interface IStateBehaviors
    {
        public void DoStateEnteredBehavior(EncounterManager em);
        public void DoStateExitedBehavior(EncounterManager em);
        public void DoUpdateBehavior(EncounterManager em);
    }

    [RequireComponent(typeof(EncounterTimer))]
    public class EncounterManager : MonoBehaviour
    {
        //============================
        // Serialized in the inspector
        //============================
        [SerializeField] private bool _autoStartTimer = true;
        [SerializeField] private SO_SimpleStateMachine _stateMachineData;
        [SerializeField] private SO_EventEncounterOutcomeDataPayload _encounterOutcomeEvent;

        //======================
        // Taken from components
        //======================
        private RuntimeSimpleStateMachine _stateMachine;
        private EncounterTimer _timer;
        private EncounterTestRig _testRig;

        //=====================
        // Initialized in Awake
        //=====================
        private IStateBehaviors _setupStateBehaviors      = null;
        private IStateBehaviors _drawupStateBehaviors     = null;
        private IStateBehaviors _selectStateBehaviors     = null;
        private IStateBehaviors _rollingStateBehaviors    = null;
        private IStateBehaviors _resolutionStateBehaviors = null;
        private IStateBehaviors _aftermathStateBehaviors  = null;
        private IStateBehaviors _playerWinStateBehaviors  = null;
        private IStateBehaviors _playerDeadStateBehaviors = null;

        //=======================================================
        // anything the state behaviors need should be `public`
        public IResolver Resolver { get; set; } = null;
        public IEncounterEnvironent EncounterEnvironent { get; set; } = null;
        public EncounterCombatantData PlayerData { get; set; } = null;
        public RuntimeSimpleStateMachine StateMachine { get { return _stateMachine; } }
        public List<EncounterCombatantData> EnemyDatas { get; private set; } = new List<EncounterCombatantData>();
        public EncounterTestRig TestRig { get {  return _testRig; }  }

        public void AnnounceOutcome()
        {
            // WIP...
            EncounterOutcomeData data = new EncounterOutcomeData();
            // TODO: configure the outcome data
            // and finally, pop off the payloaded event...
            _encounterOutcomeEvent.TriggerEvent(data);
        }
        // and so on...
        //======================================================

        private void Awake()
        {
            // grab what we need from the components
            _timer   = GetComponent<EncounterTimer>();
            _testRig = GetComponent<EncounterTestRig>();

            // initialize the state machine
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
    }
}


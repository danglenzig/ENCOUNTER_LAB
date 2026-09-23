using SimpleStateMachine;
using UnityEngine;


namespace Encounter
{
    [RequireComponent(typeof(EncounterTimer))]

    public class EncounterManager : MonoBehaviour
    {
        [SerializeField] private bool _autoStartTimer = true;
        [SerializeField] private SO_SimpleStateMachine _stateMachineData;

        private RuntimeSimpleStateMachine _stateMachine;

        EncounterTimer _timer;

        private void Awake()
        {
            _timer = GetComponent<EncounterTimer>();
            _stateMachine = _stateMachineData.GetRuntimeSimpleStateMachine();
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
            Debug.Log($"### {name}: Initial state: {_stateMachine.CurrentStateName}");

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

    }
}


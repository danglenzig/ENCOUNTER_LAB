using System.Collections.Generic;
using SimpleStateMachine;
using UnityEngine;

namespace Junk
{
    public interface IExampleStateBehaviors
    {
        public void DoStateEnteredBehavior(ExampleMB mb);
        public void DoStateExitedBehavior(ExampleMB mb);
        public void DoUpdateBehavior(ExampleMB mb);
    }

    [RequireComponent(typeof(RuntimeSimpleStateMachine))]
    public class ExampleMB : MonoBehaviour
    {
        RuntimeSimpleStateMachine _sm;
        // ^^A MonoBehavior component

        IExampleStateBehaviors _idleStateBehaviors;
        IExampleStateBehaviors _patrollingStateBehaviors;
        IExampleStateBehaviors _followingStateBehaviors;

        //=================================================================
        // Public properties and methods, which would otherwise be private,
        //   but are public so that the state handlers can access and manipulate
        //   them
        //=================================================================
        public int SomeIntegerProperty;
        public List<string> SomeListOfStrings = new List<string>();
        public void DoSomething()
        {
            // ..
        }
        // and so on...
        //=================================================================

        private void Awake()
        {
            _sm = GetComponent<RuntimeSimpleStateMachine>();

            _idleStateBehaviors = new IdleStateBehaviors();
            _patrollingStateBehaviors = new PatrollingStateBehaviors();
            _followingStateBehaviors = new FollowingStateBehaviors();
        }

        private void OnEnable()
        {
            _sm.StateEntered += HandleStateEntered;
            _sm.StateExited  += HandleStateExited;
        }

        private void OnDisable()
        {
            _sm.StateEntered -= HandleStateEntered;
            _sm.StateExited  -= HandleStateExited;
        }

        private void Update()
        {
            switch (_sm.CurrentStateName)
            {
                case "IDLE":
                    _idleStateBehaviors.DoUpdateBehavior(this);
                    return;
                case "PATROLLING":
                    _patrollingStateBehaviors.DoUpdateBehavior(this);
                    return;
                case "FOLLOWING":
                    _followingStateBehaviors.DoUpdateBehavior(this);
                    return;
                default:
                    return;
            }
        }

        private void HandleStateEntered(string enteredStateName)
        {
            switch (enteredStateName)
            {
                case "IDLE":
                    _idleStateBehaviors.DoStateEnteredBehavior(this);
                    return;
                case "PATROLLING":
                    _patrollingStateBehaviors.DoStateEnteredBehavior(this);
                    return;
                case "FOLLOWING":
                    _followingStateBehaviors.DoStateEnteredBehavior(this);
                    return;
                default:
                    return;
            }
        }

        private void HandleStateExited(string exitedStateName)
        {
            switch (exitedStateName)
            {
                case "IDLE":
                    _idleStateBehaviors.DoStateExitedBehavior(this);
                    return;
                case "PATROLLING":
                    _patrollingStateBehaviors.DoStateExitedBehavior(this);
                    return;
                case "FOLLOWING":
                    _followingStateBehaviors.DoStateExitedBehavior(this);
                    return;
                default:
                    return;
            }
        }
    }


    //===========================
    // State Behavior Definitions
    //===========================
    public class IdleStateBehaviors : IExampleStateBehaviors
    {
        public void DoStateEnteredBehavior(ExampleMB _mb) { /* manipulate public properties of _mb as nedded */ }
        public void DoStateExitedBehavior(ExampleMB mb) { /* ... */ }
        public void DoUpdateBehavior(ExampleMB _mb) { /* ... */ }
    }

    public class PatrollingStateBehaviors : IExampleStateBehaviors
    {
        public void DoStateEnteredBehavior(ExampleMB _mb) { /* ... */ }
        public void DoStateExitedBehavior(ExampleMB mb) { /* ... */ }
        public void DoUpdateBehavior(ExampleMB _mb) { /* ... */ }
    }

    public class FollowingStateBehaviors : IExampleStateBehaviors
    {
        public void DoStateEnteredBehavior(ExampleMB _mb) { /* ... */ }
        public void DoStateExitedBehavior(ExampleMB mb) { /* ... */ }
        public void DoUpdateBehavior(ExampleMB _mb) { /* ... */ }
    }

}



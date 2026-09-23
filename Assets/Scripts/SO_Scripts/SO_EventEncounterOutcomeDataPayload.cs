using UnityEngine;
using Encounter;

namespace EventChannels
{
    [CreateAssetMenu(fileName = "SO_EventEncounterOutcomeDataPayload", menuName = "Event Channels/Encounter Outcome Data Payload")]
    public class SO_EventEncounterOutcomeDataPayload : ScriptableObject
    {
        public event System.Action<EncounterOutcomeData> OnEventTriggered;
        public void TriggerEvent(EncounterOutcomeData payload)
        {
            OnEventTriggered?.Invoke(payload);
        }
    }

}


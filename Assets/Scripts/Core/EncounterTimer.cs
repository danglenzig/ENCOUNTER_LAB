using UnityEngine;

namespace Encounter
{
    public class EncounterTimer : MonoBehaviour
    {
        private int _secondsCounted = 0;
        private float _ta = 0.0f;
        private bool _beCounting = false;


        public event System.Action<int> CountIncremented;

        void Update()
        {
            if (!_beCounting) return;
            _ta += Time.deltaTime;
            if (_ta < 1.0f) return;
            _ta = 0.0f;
            _secondsCounted++;
            CountIncremented?.Invoke(_secondsCounted);
        }

        public void SetTimerActive(bool val)
        {
            _beCounting = val;
        }
    }
}



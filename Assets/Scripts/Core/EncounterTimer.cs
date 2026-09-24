using UnityEngine;

namespace Encounter
{
    public class EncounterTimer : MonoBehaviour
    {
        private int _secondsCounted = 0;
        private float _ta = 0.0f;
        private bool _beCounting = false;

        public int SecoundsCounted { get { return _secondsCounted; } }


        public event System.Action<int> CountIncremented;

        void Update()
        {
            // return early if not activated
            if (!_beCounting) return;

            // throttle counting behavior to 1 second interval
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



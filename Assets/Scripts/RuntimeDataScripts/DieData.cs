using UnityEngine;
using System.Collections.Generic;

namespace Encounter
{
    

    public sealed class DieData
    {
        private DieType _dieType;
        private List<DieFaceData> _faces;
        private string _dieUUID;
        private DieFaceData _currentFace;

        public DieType DieType { get { return _dieType; } }
        public IReadOnlyList<DieFaceData> Faces { get { return _faces; } }
        public string DieUUID { get { return _dieUUID; } }

        public DieData(DieType dieType, List<DieFaceData> faces, string dieUUID)
        {
            _dieType = dieType;
            _faces = faces;
            _dieUUID = dieUUID;
            _currentFace = _faces[0];
        }
    }
}

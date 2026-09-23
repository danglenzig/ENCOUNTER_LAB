using UnityEngine;
using System.Collections.Generic;

namespace Encounter
{
    public sealed class DieFaceData
    {
        private int _integerValue;
        private List<string> _tags;
        private Texture2D _imageTexture;

        public int IntegerValue {  get { return _integerValue; } }
        public IReadOnlyList<string> Tags { get { return _tags; } }
        public Texture2D ImageTexture { get { return _imageTexture; } }
        

        public DieFaceData(int integerValue, List<string> tags, Texture2D imageTexture)
        {
            _integerValue = integerValue;
            _tags = tags;
            _imageTexture = imageTexture;
        }

        public ResolverDieFaceData GetResolverData()
        {
            return new ResolverDieFaceData(_integerValue, _tags);
        }
    }

    public sealed class ResolverDieFaceData
    {
        // the resolver doesn't need the image texture.
        // just the integer value and the tags. So this
        // is just a lightweight version of the above
        private int _integerValue;
        private List<string> _tags;
        
        public int IntegerValue { get { return _integerValue; } }
        public IReadOnlyList<string> Tags { get { return _tags; } }

        public ResolverDieFaceData(int integerValue, List<string> tags)
        {
            _integerValue = integerValue;
            _tags = tags;
        }
    }
}



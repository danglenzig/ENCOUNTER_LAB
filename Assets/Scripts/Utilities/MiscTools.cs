using System;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

namespace MiscTools
{
    public static class IDStringGenerator
    {
        public static string GetNewUUID4AsString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}



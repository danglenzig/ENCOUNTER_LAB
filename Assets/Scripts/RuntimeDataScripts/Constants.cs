using UnityEngine;
namespace Encounter
{
    public static class EncounterStates
    {
        public const string SETUP = "Setup";
        public const string DRAWUP = "Drawup";
        public const string SELECT = "Select";
        public const string ROLLING = "Rolling";
        public const string RESOLUTION = "Resolution";
        public const string AFTERMATH = "Aftermath";
        public const string PLAYER_DEAD = "PlayerDead";
        public const string PLAYER_WIN = "PlayerWin";
    }

    public static class DieFaceTags
    {
        public const string ACTION_ATTACK = "ACTION_ATTACK";
        public const string ACTION_ATTACK_LIGHT = "ACTION_ATTACK_LIGHT";
        public const string ACTION_ATTACK_HEAVY = "ACTION_ATTACK_HEAVY";
        // etc.
        public const string ACTION_HEAL = "ACTION_HEAL";
        public const string ACTION_EVASION = "ACTION_EVASION";

        public const string STATUS_EFFECT = "STATUS_EFFECT";
        public const string STATUS_EFFECT_SLOW = "STATUS_EFFECT_SLOW";
        public const string STATUS_EFFECT_INSPIRED = "STATUS_EFFECT_INSPIRED";
        // etc.

    }
}


using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace InstantActions
{
    internal static class ModInfo
    {
        internal const string Guid = "omegaplatinum.elin.instantactions";
        internal const string Name = "Instant Actions";
        internal const string Version = "1.1.1.0";
    }

    [BepInPlugin(GUID: ModInfo.Guid, Name: ModInfo.Name, Version: ModInfo.Version)]
    internal class InstantActions : BaseUnityPlugin
    {
        internal static InstantActions Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            InstantActionsConfig.LoadConfig(Config);
            var harmony = new Harmony(ModInfo.Guid);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(AIAct), nameof(AIAct.MaxProgress), MethodType.Getter)]
    internal static class AIActMaxProgressPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref int __result)
        {
            if (InstantActionsConfig.EnableInstantActions?.Value == true)
            {
                __result = InstantActionsConfig.MaxProgress?.Value ?? 1;
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(AIProgress), nameof(AIProgress.MaxProgress), MethodType.Getter)]
    internal static class AIProgressMaxProgressPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref int __result)
        {
            if (InstantActionsConfig.EnableInstantActions?.Value == true)
            {
                __result = InstantActionsConfig.MaxProgress?.Value ?? 1;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Progress_Custom), nameof(Progress_Custom.MaxProgress), MethodType.Getter)]
    internal static class ProgressCustomMaxProgressPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref int __result, Progress_Custom __instance)
        {
            if (__instance.owner?.ai is AI_PracticeDummy || __instance.owner?.ai is AI_PlayMusic)
            {
                return true;
            }

            if (InstantActionsConfig.EnableInstantActions?.Value == true)
            {
                __result = InstantActionsConfig.MaxProgress?.Value ?? 1;
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(AI_Fuck), nameof(AI_Fuck.MaxProgress), MethodType.Getter)]
    internal static class AIFuckMaxProgressPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref int __result)
        {
            if (InstantActionsConfig.EnableInstantActions?.Value == true)
            {
                __result = InstantActionsConfig.MaxProgress?.Value ?? 1;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(AI_Fish.ProgressFish), nameof(AI_Fish.ProgressFish.OnProgress))]
    internal static class AIFishOnProgressPatch
    {
        [HarmonyPrefix]
        public static void Prefix(AI_Fish.ProgressFish __instance)
        {
            if (InstantActionsConfig.EnableInstantActions?.Value == true)
            {
                __instance.hit = 100;
            }
        }
    }
}
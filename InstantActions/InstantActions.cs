using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace InstantActions
{
    internal static class ModInfo
    {
        internal const string Guid = "omegaplatinum.elin.instantactions";
        internal const string Name = "Instant Actions";
        internal const string Version = "1.1.2.0";
    }

    [BepInPlugin(GUID: ModInfo.Guid, Name: ModInfo.Name, Version: ModInfo.Version)]
    internal class InstantActions : BaseUnityPlugin
    {
        internal static InstantActions Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            InstantActionsConfig.LoadConfig(config: Config);
            var harmony = new Harmony(id: ModInfo.Guid);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(declaringType: typeof(AIAct), methodName: nameof(AIAct.MaxProgress), methodType: MethodType.Getter)]
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

    [HarmonyPatch(declaringType: typeof(AIProgress), methodName: nameof(AIProgress.MaxProgress), methodType: MethodType.Getter)]
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

    [HarmonyPatch(declaringType: typeof(Progress_Custom), methodName: nameof(Progress_Custom.MaxProgress), methodType: MethodType.Getter)]
    internal static class ProgressCustomMaxProgressPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref int __result, Progress_Custom __instance)
        {
            if (__instance.owner?.ai is AI_PracticeDummy || 
                __instance.owner?.ai is AI_PlayMusic || 
                __instance.owner?.ai is AI_Torture)
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

    [HarmonyPatch(declaringType: typeof(AI_Fuck), methodName: nameof(AI_Fuck.MaxProgress), methodType: MethodType.Getter)]
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

    [HarmonyPatch(declaringType: typeof(AI_Fish.ProgressFish), methodName: nameof(AI_Fish.ProgressFish.OnProgress))]
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
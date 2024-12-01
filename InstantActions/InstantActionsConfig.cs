using BepInEx.Configuration;
using UnityEngine;

namespace InstantActions
{
    internal static class InstantActionsConfig
    {
        internal static ConfigEntry<bool> EnableInstantActions;
        internal static ConfigEntry<int> MaxProgress;

        internal static void LoadConfig(ConfigFile config)
        {
            EnableInstantActions = config.Bind(
                section: ModInfo.Name,
                key: "Enable Instant Actions Mod",
                defaultValue: true,
                description: "Enable or disable the Instant Actions mod.\n" +
                             "Set to 'true' to activate the mod, or 'false' to keep the game unchanged.\n" +
                             "インスタントアクションMODを有効または無効にします。\n" +
                             "'true' に設定するとMODが有効になり、'false' に設定するとゲームのデフォルトのままになります。");

            MaxProgress = config.Bind(
                section: ModInfo.Name,
                key: "Max Progress Value",
                defaultValue: 1,
                description: "Set the max progress value for instant actions.\n" +
                             "A value of '1' makes actions instant.\n" +
                             "インスタントアクションの最大進行値を設定します。\n" +
                             "'1' に設定するとアクションが即座に完了します。");
        }
    }
}
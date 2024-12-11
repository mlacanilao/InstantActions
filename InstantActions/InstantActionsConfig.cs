using BepInEx.Configuration;
using UnityEngine;

namespace InstantActions
{
    internal static class InstantActionsConfig
    {
        internal static ConfigEntry<bool> EnableInstantActions;
        internal static ConfigEntry<int> MaxProgress;
        internal static ConfigEntry<KeyCode> ToggleInstantActionsKey;

        internal static void LoadConfig(ConfigFile config)
        {
            EnableInstantActions = config.Bind(
                section: ModInfo.Name,
                key: "Enable Instant Actions Mod",
                defaultValue: true,
                description: "Enable or disable the Instant Actions mod.\n" +
                             "Set to 'true' to activate the mod, or 'false' to keep the game unchanged.\n" +
                             "インスタントアクションMODを有効または無効にします。\n" +
                             "'true' に設定するとMODが有効になり、'false' に設定するとゲームのデフォルトのままになります。\n" +
                             "启用或禁用即时动作模组。\n" +
                             "设置为 'true' 激活模组，设置为 'false' 保持游戏不变。");

            MaxProgress = config.Bind(
                section: ModInfo.Name,
                key: "Max Progress Value",
                defaultValue: 1,
                description: "Set the max progress value for instant actions.\n" +
                             "A value of '1' makes actions instant.\n" +
                             "インスタントアクションの最大進行値を設定します。\n" +
                             "'1' に設定するとアクションが即座に完了します。\n" +
                             "设置即时动作的最大进度值。\n" +
                             "设置为 '1' 使动作立即完成。");

            ToggleInstantActionsKey = config.Bind(
                section: ModInfo.Name,
                key: "Instant Actions Toggle Key",
                defaultValue: KeyCode.Y,
                description: "Key to toggle Instant Actions on or off in-game.\n" +
                             "Press this key to enable or disable Instant Actions during gameplay.\n" +
                             "ゲーム内でインスタントアクションをオンまたはオフに切り替えるキーを設定します。\n" +
                             "このキーを押して、ゲームプレイ中にインスタントアクションを有効または無効にします。\n" +
                             "在游戏中切换即时动作开关的键。\n" +
                             "按下此键可在游戏过程中启用或禁用即时动作。");
        }
    }
}
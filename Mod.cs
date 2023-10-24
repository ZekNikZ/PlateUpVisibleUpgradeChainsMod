using Kitchen;
using KitchenMods;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace KitchenVisibleUpgradeChainsMod
{
    public class Mod : GenericSystemBase, IModInitializer, IModSystem
    {
        public const string MOD_GUID = "io.zkz.plateup.visibleupgradechains";
        public const string MOD_NAME = "Visible Upgrade Chains";
        public const string MOD_VERSION = "0.2.0";
        public const string MOD_AUTHOR = "ZekNikZ";
        public const string MOD_GAMEVERSION = ">=1.1.3";

        private static Harmony HarmonyInstance;

        protected override void Initialise()
        {
            base.Initialise();

            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        protected override void OnUpdate()
        {
           
        }

        public void PostActivate(KitchenMods.Mod mod)
        {
            HarmonyInstance = new Harmony(MOD_GUID);
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void PreInject()
        {

        }

        public void PostInject()
        {
            
        }

        #region Logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }

        #endregion
    }
}

using HarmonyLib;
using Kitchen;
using KitchenData;
using System.Linq;

namespace KitchenVisibleUpgradeChainsMod
{
    [HarmonyPatch(typeof(ApplianceInfoView), "UpdateData")]
    class UpdateDataPatch {
        internal static int ID;

        static void Prefix(ApplianceInfoView.ViewData data)
        {
            ID = data.ID;
        }
    }

    [HarmonyPatch(typeof(ApplianceInfoView), "AddTag")]
    class AddTagPatch
    {
        static void Postfix(float offset, string tag, ref ApplianceInfoView __instance, ref float __result)
        {
            if (tag != GameData.Main.GlobalLocalisation["Upgradable"] || !GameData.Main.TryGet<Appliance>(UpdateDataPatch.ID, out var appliance) || !appliance.HasUpgrades)
            {
                return;
            }

            // private float AddSection(float offset, Appliance.Section details, bool centre = false)
            var mAddTag = typeof(ApplianceInfoView).GetMethod("AddSection", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            var details = new Appliance.Section
            {
                Title = "Possible Upgrades",
                Description = string.Join(", ", appliance.Upgrades.Select(appliance => appliance.Name))
            };

            var res = (float) mAddTag.Invoke(__instance, new object[] { offset + __result, details, true });

            __result += res;
        }
    }
}

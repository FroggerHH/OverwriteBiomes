using System.Diagnostics;

// The switch expression does not handle all possible values of its input type (it is not exhaustive).
#pragma warning disable CS8509

namespace OverwriteBiomes.Patch;

[HarmonyWrapSafe]
internal static class OverwriteBiomes
{
    private static bool _isInitializingStartTemple;

    [HarmonyPatch(typeof(WorldGenerator), nameof(WorldGenerator.GetBiome), typeof(Vector3))]
    [HarmonyPostfix]
    public static void Patch1(WorldGenerator __instance, ref Biome __result, Vector3 point) =>
        OverwriteBiome(__instance, ref __result);

    [HarmonyPatch(typeof(WorldGenerator), nameof(WorldGenerator.GetBiome), typeof(float), typeof(float), typeof(float), typeof(bool))]
    [HarmonyPostfix]
    public static void Patch2(WorldGenerator __instance, ref Biome __result) =>
        OverwriteBiome(__instance, ref __result);

    [HarmonyPatch(typeof(ZoneSystem), nameof(ZoneSystem.GenerateLocationsTimeSliced), typeof(ZoneLocation), typeof(Stopwatch), typeof(ZPackage))]
    [HarmonyPrefix]
    public static void Patch3(ZoneSystem __instance, ZoneLocation location) =>
        _isInitializingStartTemple = location.m_prefabName == "StartTemple";

    private static void OverwriteBiome(WorldGenerator __instance, ref Biome __result)
    {
        if (__instance.m_world.m_menu) return;
        if (_isInitializingStartTemple) return;


        __result = __result switch
        {
            None => None,
            Meadows => MeadowsToConfig.Value,
            Swamp => SwampToConfig.Value,
            Mountain => MountainToConfig.Value,
            BlackForest => BlackForestToConfig.Value,
            Plains => PlainsToConfig.Value,
            AshLands => AshLandsToConfig.Value,
            DeepNorth => DeepNorthToConfig.Value,
            Ocean => OceanToConfig.Value,
            Mistlands => MistlandsToConfig.Value,
            // _ => __result
        };
    }
}
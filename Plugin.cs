using BepInEx;
using BepInEx.Configuration;

namespace OverwriteBiomes;

[BepInPlugin(ModGuid, ModName, ModVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string
        ModName = "OverwriteBiomes",
        ModVersion = "0.1.0",
        ModAuthor = "Frogger",
        ModGuid = $"com.{ModAuthor}.{ModName}";

    public static ConfigEntry<Biome> MeadowsToConfig;
    public static ConfigEntry<Biome> SwampToConfig;
    public static ConfigEntry<Biome> MountainToConfig;
    public static ConfigEntry<Biome> BlackForestToConfig;
    public static ConfigEntry<Biome> PlainsToConfig;
    public static ConfigEntry<Biome> AshLandsToConfig;
    public static ConfigEntry<Biome> DeepNorthToConfig;
    public static ConfigEntry<Biome> OceanToConfig;
    public static ConfigEntry<Biome> MistlandsToConfig;

    private void Awake()
    {
        CreateMod(this, ModName, ModAuthor, ModVersion, ModGuid);

        MeadowsToConfig = config("General", "Change Meadows to", Meadows, string.Empty);
        SwampToConfig = config("General", "Change Swamp to", Swamp, string.Empty);
        MountainToConfig = config("General", "Change Mountain to", Mountain, string.Empty);
        BlackForestToConfig = config("General", "Change BlackForest to", BlackForest, string.Empty);
        PlainsToConfig = config("General", "Change Plains to", Plains, string.Empty);
        AshLandsToConfig = config("General", "Change AshLands to", AshLands, string.Empty);
        DeepNorthToConfig = config("General", "Change DeepNorth to", DeepNorth, string.Empty);
        OceanToConfig = config("General", "Change Ocean to", Ocean, string.Empty);
        MistlandsToConfig = config("General", "Change Mistlands to", Ocean, string.Empty);
    }
}
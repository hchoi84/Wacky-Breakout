/// <summary>
/// Provides access to the configuration fields
/// </summary>
public static class ConfigurationUtils
{
    private static ConfigurationData configData;

    // how quickly to move the padde
    public static float PaddleMoveUnitsPerSecond { get { return configData.PaddleMoveUnitsPerSecond; } }
    public static float BallImpulseForce { get { return configData.BallImpulseForce; } }
    public static float BallLifetime { get { return configData.BallLifetime; } }
    public static float MinSpawnTime { get { return configData.MinSpawnTime; } }
    public static float MaxSpawnTime { get { return configData.MaxSpawnTime; } }
    public static int StandardBlockPoints { get { return configData.StandardBlockPoints; } }
    public static int BonusBlockPoints { get { return configData.BonusBlockPoints; } }
    public static int PickupBlockPoints { get { return configData.PickupBlockPoints; } }
    public static float StandardBlockSpawnProbability { get { return configData.StandardBlockSpawnProbability; } }
    public static float BonusBlockSpawnProbability { get { return configData.BonusBlockSpawnProbability; } }
    public static float FreezerBlockSpawnProbability { get { return configData.FreezerBlockSpawnProbability; } }
    public static float SpeedupBlockSpawnProbability { get { return configData.SpeedupBlockSpawnProbability; } }
    public static int BallsPerGame { get { return configData.BallsPerGame; } }

    public static void Initialize()
    {
        configData = new ConfigurationData();
    }
}

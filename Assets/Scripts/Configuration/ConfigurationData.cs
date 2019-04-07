using UnityEngine;
using System.IO;
using System;

public class ConfigurationData
{
    private const string ConfigurationDataFileName = "ConfigurationData.csv";

    // create fields and assign a value incase the csv files aren't read
    private float paddleMoveUnitsPerSecond = 15f;
    private float ballImpulseForce = 250f;
    private float ballLifetime = 10f;
    private float minSpawnTime = 5f;
    private float maxSpawnTime = 10f;
    private int standardBlockPoints = 10;
    private int bonusBlockPoints = 20;
    private int pickupBlockPoints = 15;
    private float standardBlockSpawnProbability = 50f;
    private float bonusBlockSpawnProbability = 20f;
    private float freezerBlockSpawnProbability = 15f;
    private float speedupBlockSpawnProbability = 15f;
    private int ballsPerGame = 10;
    
    public float PaddleMoveUnitsPerSecond { get { return paddleMoveUnitsPerSecond; } }
    public float BallImpulseForce { get { return ballImpulseForce; } }
    public float BallLifetime { get { return ballLifetime; } }
    public float MinSpawnTime { get { return minSpawnTime; } }
    public float MaxSpawnTime { get { return maxSpawnTime; } }
    public int StandardBlockPoints { get { return standardBlockPoints; } }
    public int BonusBlockPoints { get { return bonusBlockPoints; } }
    public int PickupBlockPoints { get { return pickupBlockPoints; } }
    public float StandardBlockSpawnProbability { get { return standardBlockSpawnProbability; } }
    public float BonusBlockSpawnProbability { get { return bonusBlockSpawnProbability; } }
    public float FreezerBlockSpawnProbability { get { return freezerBlockSpawnProbability; } }
    public float SpeedupBlockSpawnProbability { get { return speedupBlockSpawnProbability; } }
    public int BallsPerGame { get { return ballsPerGame; } }


    public ConfigurationData()
    {
        // begin reading the csv file
        StreamReader input = null;
        try
        {
            // open and read the csv file
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            // separate reach line to specific string field
            string header = input.ReadLine();
            string value = input.ReadLine();

            // comma separate the values and store it in an array
            ConfigureFields(value);
        }
        catch (Exception e)
        {
        }
        finally
        {
            // close the file once done
            if (input != null)
            {
                input.Close();
            }
        }
    }

    // store the values from CSV to appropriate fields
    private void ConfigureFields(string value)
    {
        string[] values = value.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifetime = float.Parse(values[2]);
        minSpawnTime = float.Parse(values[3]);
        maxSpawnTime = float.Parse(values[4]);
        standardBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);
        standardBlockSpawnProbability = float.Parse(values[8]);
        bonusBlockSpawnProbability = float.Parse(values[9]);
        freezerBlockSpawnProbability = float.Parse(values[10]);
        speedupBlockSpawnProbability = float.Parse(values[11]);
        ballsPerGame = int.Parse(values[12]);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject paddlePrefab = default;
    [SerializeField]
    private GameObject standardBlockPrefab = default;
    [SerializeField]
    private GameObject bonusBlockPrefab = default;
    [SerializeField]
    private GameObject pickupBlockPrefab = default;

    private List<GameObject> blockPrefabs = new List<GameObject>();
    private List<GameObject> randomBlocks = new List<GameObject>();

    private List<PickupEffect> pickupBlocks = new List<PickupEffect>();
    private List<PickupEffect> randomPickupBlocks = new List<PickupEffect>();
    private PickupEffect pickupEffect = default;

    private GameObject randomBlockPrefab = default;
    private Vector2 paddleSpawnPos;
    private float boxSizeX;
    private float boxSizeXRoundedUp;
    private float screenXRounded;
    private float blocksFitHorizontally;
    private float blockRows = 3f;

    private void Start()
    {
        // round the min/max X screen position
        screenXRounded = Mathf.Floor(ScreenUtils.ScreenRight);

        // spawn paddle center of x-pos and little up from bottom
        paddleSpawnPos = new Vector2(
            (ScreenUtils.ScreenRight + ScreenUtils.ScreenLeft) / 2, ScreenUtils.ScreenBottom + 1);
        GameObject paddle = Instantiate(paddlePrefab, paddleSpawnPos, Quaternion.identity);

        // determine the box width for building blocks
        boxSizeX = standardBlockPrefab.GetComponent<BoxCollider2D>().size.x;
        boxSizeXRoundedUp = Mathf.CeilToInt(boxSizeX);

        // begin populating blocks
        BuildBlocks();
    }

    private void BuildBlocks()
    {
        // calculate how mnay blocks fit on the screen
        blocksFitHorizontally = Mathf.Floor(screenXRounded * 2 / boxSizeXRoundedUp);
        float yPos = ScreenUtils.ScreenTop - ((Mathf.Abs(ScreenUtils.ScreenTop) + Mathf.Abs(ScreenUtils.ScreenBottom)) / 5);

        // auto build 3 rows of blocks horizontally with a row of gap
        for (int blockY = 0; blockY < blockRows * 2; blockY += 2)
        {
            for (int blockX = 0; blockX <= blocksFitHorizontally; blockX++)
            {
                PickRandomBlock();
                GameObject block = Instantiate(randomBlockPrefab, 
                    new Vector2(-screenXRounded + (boxSizeXRoundedUp * blockX), yPos - (boxSizeXRoundedUp * blockY)), 
                    Quaternion.identity);

                // check if the block is a pickup block
                PickupBlock pickupBlock = block.GetComponent<PickupBlock>();
                if (pickupBlock != null)
                {
                    pickupBlock.BlockEffect = pickupEffect;
                }
            }
        }
    }

    private void PickRandomBlock()
    {
        for (int i = 0; i < ConfigurationUtils.StandardBlockSpawnProbability; i++)
        {
            blockPrefabs.Add(standardBlockPrefab);
        }

        for (int i = 0; i < ConfigurationUtils.BonusBlockSpawnProbability; i++)
        {
            blockPrefabs.Add(bonusBlockPrefab);
        }

        float totalPickupBlocks = ConfigurationUtils.FreezerBlockSpawnProbability + ConfigurationUtils.SpeedupBlockSpawnProbability;
        for (int i = 0; i < totalPickupBlocks; i++)
        {
            blockPrefabs.Add(pickupBlockPrefab);
            RandomPickupEffect();
        }

        int randomIndex = 0;
        while (blockPrefabs.Count > 0)
        {
            randomIndex = Random.Range(0, blockPrefabs.Count);
            randomBlocks.Add(blockPrefabs[randomIndex]);
            blockPrefabs.RemoveAt(randomIndex);
        }

        randomBlockPrefab = randomBlocks[Random.Range(0, randomBlocks.Count - 1)];
    }

    private void RandomPickupEffect()
    {
        for (int i = 0; i < ConfigurationUtils.FreezerBlockSpawnProbability; i++)
        {
            pickupBlocks.Add(PickupEffect.Freezer);
        }

        for (int i = 0; i < ConfigurationUtils.SpeedupBlockSpawnProbability; i++)
        {
            pickupBlocks.Add(PickupEffect.Speedup);
        }

        int randomIndex = 0;
        while (pickupBlocks.Count > 0)
        {
            randomIndex = Random.Range(0, pickupBlocks.Count);
            randomPickupBlocks.Add(pickupBlocks[randomIndex]);
            pickupBlocks.RemoveAt(randomIndex);
        }

        pickupEffect = randomPickupBlocks[Random.Range(0, randomPickupBlocks.Count)];
    }
}

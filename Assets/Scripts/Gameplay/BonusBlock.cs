using UnityEngine;

public class BonusBlock : Block
{
    private void Start()
    {
        score = ConfigurationUtils.BonusBlockPoints;
    }
}

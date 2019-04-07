using UnityEngine;

public class PickupBlock : Block
{
    [SerializeField]
    private Sprite[] pickupBlockSprites = default;
    private SpriteRenderer spriteRenderer = default;

    private PickupEffect blockEffect;

    public PickupEffect BlockEffect 
    {
        set 
        {
            blockEffect = value;
            if (blockEffect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = pickupBlockSprites[0];
            }
            else
            {
                spriteRenderer.sprite = pickupBlockSprites[1];
            }
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        score = ConfigurationUtils.PickupBlockPoints;
    }
}

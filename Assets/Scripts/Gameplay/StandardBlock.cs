using UnityEngine;
using System.Collections;

public class StandardBlock : Block
{
    [SerializeField]
    private Sprite[] standardBlockSprites = default;
    private SpriteRenderer spriteRenderer = default;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteIndex = Random.Range(0, standardBlockSprites.Length);
        spriteRenderer.sprite = standardBlockSprites[spriteIndex];

        score = ConfigurationUtils.StandardBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

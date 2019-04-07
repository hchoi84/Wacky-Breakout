using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.05f;
    Material myMaterial;
    Vector2 offset;
    
    void Start()
    {
        myMaterial = GetComponent<MeshRenderer>().material;
        offset = new Vector2(0, backgroundScrollSpeed);
    }
    
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}

using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // triggers calculation of screen space
    private void Awake()
    {
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
    }
}

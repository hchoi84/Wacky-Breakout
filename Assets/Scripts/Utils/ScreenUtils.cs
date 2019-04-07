using UnityEngine;
/// <summary>
/// Calculates the screen space in world units
/// Stores min/max for width and height
/// </summary>
public static class ScreenUtils
{
    private static float screenLeft;
    private static float screenRight;
    private static float screenBottom;
    private static float screenTop;

    public static float ScreenLeft {
        get { return screenLeft; }
    }

    public static float ScreenRight {
        get { return screenRight; }
    }

    public static float ScreenBottom {
        get { return screenBottom; }
    }

    public static float ScreenTop {
        get { return screenTop; }
    }

    // calculates the screen in world units
    public static void Initialize()
    {
        float zCoord = -Camera.main.transform.position.z;
        Vector3 minScreenSpace = new Vector3(0, 0, zCoord);
        Vector3 maxScreenSpace = new Vector3(Screen.width, Screen.height, zCoord);
        Vector3 minWorldSpace = Camera.main.ScreenToWorldPoint(minScreenSpace);
        Vector3 maxWorldSpace = Camera.main.ScreenToWorldPoint(maxScreenSpace);
        screenLeft = minWorldSpace.x;
        screenRight = maxWorldSpace.x;
        screenBottom = minWorldSpace.y;
        screenTop = maxWorldSpace.y;
    }
}

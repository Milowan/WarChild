using UnityEngine;

public class UIManager : MonoBehaviour
{
    public delegate void UIEvent();

    public static UIEvent OpenNavigation;
    public static UIEvent CloseNavigation;
    public static UIEvent OpenArsenal;
    public static UIEvent CloseArsenal;

    public static void OpenNav()
    {
        if (OpenNavigation != null)
            OpenNavigation();
    }

    public static void CloseNav()
    {
        if (CloseNavigation != null)
            CloseNavigation();
    }

    public static void ArsenalOpen()
    {
        if (OpenArsenal != null)
            OpenArsenal();
    }

    public static void ArsenalClose()
    {
        if (CloseArsenal != null)
            CloseArsenal();
    }
}


public class NavigationButton : UIButton
{
    private void Awake()
    {
        UIManager.OpenNavigation += OpenNavigation;
        UIManager.CloseNavigation += CloseNavigation;
        UIManager.OpenArsenal += OpenArsenal;
        UIManager.CloseArsenal += CloseArsenal;
    }

    public override void Activate()
    {
        UIManager.OpenNav();
    }

    private void OpenNavigation()
    {
        gameObject.SetActive(false);
    }

    private void CloseNavigation()
    {
        gameObject.SetActive(true);
    }

    private void OpenArsenal()
    {
        gameObject.SetActive(false);
    }

    private void CloseArsenal()
    {
        gameObject.SetActive(true);
    }
}

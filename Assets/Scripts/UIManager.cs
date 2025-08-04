using UnityEngine;
public class DisplaySettingsManager : MonoBehaviour
{
    public void SetResolution(int index)
    {
        Resolution selectedResolution = Screen.resolutions[index];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public bool GetFullScreen()
    {
        return Screen.fullScreen;
    }
}

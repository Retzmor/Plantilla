using UnityEngine;
public class UIManager : MonoBehaviour
{
    public void SetResolution(int index)
    {
        Resolution selectedResolution = Screen.resolutions[index];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }
}

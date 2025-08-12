using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        EventBus.InvokeEvent(GameEvents.GameStarted);
    }

    public void PauseGame()
    {
        EventBus.InvokeEvent(GameEvents.GamePaused);
    }

    public void ReanudarGame()
    {
        EventBus.InvokeEvent(GameEvents.GameResumed);
    }

    public void RestartGame() 
    {
        EventBus.InvokeEvent(GameEvents.GameRestart);
    }

    public void ExitGame()
    {
        EventBus.InvokeEvent(GameEvents.GameFinished);
    }
}

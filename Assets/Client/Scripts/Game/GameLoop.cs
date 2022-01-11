using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] components;
    private SceneSwitcher _sceneSwitcher;
    public static Death DeathPlayer;

    private void Start()
    {
        DeathPlayer = Death;
        _sceneSwitcher = GetComponent<SceneSwitcher>();
        StartGame();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Death(Entity entity)
    {
        StopGame();
    }
    public void RestartGame()
    {
        _sceneSwitcher.LoadSceneWithAnim("game");
    }
    public void StartGame()
    {
        foreach (var component in components)
            component.enabled = true;
    }
    public void StopGame()
    {
        foreach (var component in components)
            component.enabled = false;
    }
}

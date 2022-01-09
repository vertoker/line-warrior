using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour, IDeath
{
    [SerializeField] private MonoBehaviour[] components;
    private SceneSwitcher _sceneSwitcher;
    public static GameLoop Instance;

    private void Start()
    {
        Instance = this;
        _sceneSwitcher = GetComponent<SceneSwitcher>();
        StartGame();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Death()
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

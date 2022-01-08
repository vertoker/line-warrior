using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float timeToFade = 0.5f, timeToAppear = 0.5f;
    private Dictionary<string, int> _scenes = new Dictionary<string, int>()
    {
        { "menu", 0 },
        { "game", 1 }
    };

    private void Start()
    {
        image.gameObject.SetActive(true);
        StartCoroutine(AppearAnim());
    }

    private IEnumerator AppearAnim()
    {
        for (float i = timeToAppear; i > 0; i -= Time.unscaledDeltaTime)
        {
            image.color = new Color(0, 0, 0, i / timeToAppear);
            yield return null;
        }
        image.color = new Color(0, 0, 0, 0);
        image.gameObject.SetActive(false);
    }
    private IEnumerator FateAnim(string key)
    {
        image.gameObject.SetActive(true);
        for (float i = 0; i < timeToFade; i += Time.unscaledDeltaTime)
        {
            image.color = new Color(0, 0, 0, i / timeToFade);
            yield return null;
        }
        image.color = new Color(0, 0, 0, 1);
        image.gameObject.SetActive(true);
        LoadScene(key);
    }
    
    public void LoadSceneWithAnim(string key)
    {
        StartCoroutine(FateAnim(key));
    }
    public void LoadScene(string key)
    {
        SceneManager.LoadScene(_scenes[key]);
    }
}

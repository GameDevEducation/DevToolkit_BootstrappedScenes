using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PerformBootstrap
{
    const string SceneName = "Bootstrapped Scene";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        // traverse the currently loaded scenes
        for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; ++sceneIndex)
        {
            var candidate = SceneManager.GetSceneAt(sceneIndex);

            // early out if already loaded
            if (candidate.name == SceneName)
                return;
        }

        Debug.Log("Loading bootstrap scene: " + SceneName);

        // additively load the bootstrap scene
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }
}

public class BootstrappedData : MonoBehaviour
{
    public static BootstrappedData Instance { get; private set; } = null;

    void Awake()
    {
        // check if an instance already exists
        if (Instance != null)
        {
            Debug.LogError("Found another BootstrappedData on " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Debug.Log("Bootstrap initialised!");
        Instance = this;

        // prevent the data from being unloaded
        DontDestroyOnLoad(gameObject);
    }

    public void Test()
    {
        Debug.Log("Bootstrap is working!");
    }
}

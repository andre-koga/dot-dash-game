using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Eflatun.SceneReference;

public class LoadNextLevel : MonoBehaviour
{
    public static Action OnLoadNextLevel;

    [SerializeField] private SceneReference nextLevel;

    private void OnEnable()
    {
        OnLoadNextLevel += LoadNextLevelHandler;
    }
    private void OnDisable()
    {
        OnLoadNextLevel -= LoadNextLevelHandler;
    }

    /// <summary>
    /// Load next level.
    /// </summary>
    private void LoadNextLevelHandler()
    {
        SceneManager.LoadScene(nextLevel.Path);
    }
}

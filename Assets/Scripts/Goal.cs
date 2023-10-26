using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    /// <summary>
    /// Load next level when player enters the goal.
    /// </summary>
    private void OnTriggerEnter2D()
    {
        LoadNextLevel.OnLoadNextLevel?.Invoke();
    }
}

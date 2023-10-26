using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up, Down, Left, Right };
public class PlayerCollisionDetector : MonoBehaviour
{
    private int collisionCount = 0;
    public bool isColliding { get { return collisionCount > 0; } }
    [SerializeField] private Direction direction;

    void OnTriggerEnter2D()
    {
        collisionCount++;
    }
    void OnTriggerExit2D()
    {
        collisionCount--;
    }
}

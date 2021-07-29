using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public static float secondsToMaxDifficulty = 60;

    public static float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}

// Tihs class is used to control the difficulty, logic moved here from Spawner class
// Difficulty is calculated by the linear interpolation, formula: value = a + (b-a) * p

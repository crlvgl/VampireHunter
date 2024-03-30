using UnityEngine;

public static class __staticInfoClass
{
    // for Loading Scenes
    public static string sceneToLoad = "none";
    public static float timeToLoad = 0;

    // for Dialogue
    public static string dialogueTrigger = "none";
    public static string[] leftDialogue;
    public static string leftDialogueName;
    public static Sprite leftSprite;
    public static string[] rightDialogue;
    public static string rightDialogueName;
    public static Sprite rightSprite;
    public static bool lastDialogue = false;
    public static int randomLength;

    // for single Dialogue
    public static string singleTrigger;
    public static string[] singleDialogue;
    public static string singleName;
    public static Sprite singleSprite;

    // for Player Combat
    public static Vector2 projectileDirection;
    public static float projectileScale = 3;
    public static float projectileAngle;
    public static Vector2 crystalProjectileDirection;
    public static int killed;

    // Epilogue
    public static bool epilogue = false;
}
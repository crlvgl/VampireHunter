using UnityEngine;

public static class __staticInfoClass
{
    // for Loading Scenes
    public static bool loadScene = false;
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

    // for Player Combat
    public static Vector2 projectileDirection;
    public static float projectileAngle;
}
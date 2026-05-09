using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// Скрипт для сборки игры. Помести в папку Editor и используй через меню.
/// </summary>
public class BuildGame
{
    [MenuItem("Build/Build Linux")]
    public static void BuildLinux()
    {
        BuildGameBuild(BuildTarget.StandaloneLinux64, "Build/Linux");
    }

    [MenuItem("Build/Build Windows")]
    public static void BuildWindows()
    {
        BuildGameBuild(BuildTarget.StandaloneWindows64, "Build/Windows");
    }

    [MenuItem("Build/Build macOS")]
    public static void BuildMacOS()
    {
        BuildGameBuild(BuildTarget.StandaloneOSX, "Build/macOS");
    }

    private static void BuildGameBuild(BuildTarget target, string path)
    {
        // Ensure build directory exists
        Directory.CreateDirectory(path);

        // Build player
        string[] scenes = { "Assets/Scenes/SampleScene.unity" };
        BuildPipeline.BuildPlayer(scenes, path, target, BuildOptions.None);

        Debug.Log($"Build complete: {path}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class TextureUtility : MonoBehaviour
{
    public static string userTexturePath = Path.Combine(StaticData.userPath, "Textures");
    public static string userNodesTexturePath = Path.Combine(userTexturePath, "Node");
    public static string userStarlanesTexturePath = Path.Combine(userTexturePath, "Starlane");

    public static Texture2D LoadUserPNG(string path)
    {
        Texture2D loadedTexture = new Texture2D(2, 2);
        loadedTexture.LoadImage(File.ReadAllBytes(Path.Combine(userTexturePath, path)));
        return loadedTexture;
    }
    public static Texture2D LoadInternalPNG(string path)
    {
        Debug.Log(path);
        Texture2D loadedTexture = new Texture2D(2, 2); 
        loadedTexture= Resources.Load<Texture2D>(path); 
        return loadedTexture;
    }
}

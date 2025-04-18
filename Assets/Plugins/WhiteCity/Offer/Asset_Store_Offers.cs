#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class Asset_Store_Offers : EditorWindow
{
    [MenuItem("Window/Asset Store Offers")]
    public static void ShowWindow()
    {
        GetWindow<Asset_Store_Offers>(false, "Asset Store Offers", true);
    }
    public static void DrawUILine(Color color, int thickness = 2, int padding = 10)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
        r.height = thickness;
        r.y += padding / 2;
        r.x -= 2;
        r.width += 6;
        EditorGUI.DrawRect(r, color);
    }

    private const int windowWidth = 525;
    private const int windowHeight = 500;
    Vector2 _scrollPosition;

    void OnEnable()
    {
        titleContent = new GUIContent("Lighting Tools and Assets");
        maxSize = new Vector2(windowWidth, windowHeight);
        minSize = maxSize;

    }

    private void OnGUI()
    {
        
        Texture2D ad1 = EditorGUIUtility.Load("Assets/WhiteCity/Offer/Ads/ad1.psd") as Texture2D;
        Texture2D ad2 = EditorGUIUtility.Load("Assets/WhiteCity/Offer/Ads/ad2.psd") as Texture2D;
        Texture2D ad3 = EditorGUIUtility.Load("Assets/WhiteCity/Offer/Ads/ad3.psd") as Texture2D;

        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Asset Store Offers", MessageType.None);
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition,
                     false,
                     false,
                     GUILayout.Width(windowWidth),
                     GUILayout.Height(windowHeight-20));        //---------Ad 1-------------------------------------------------
                                                                //  GUILayout.BeginVertical("Box");

        //_scrollPosition = EditorGUILayout.BeginScrollView(scrollViewRect, _scrollPosition, new Rect(0, 0, 2000, 2000));
       
        if (GUILayout.Button(ad1, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/slug/107069");
        }

        if (GUILayout.Button(ad2, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/slug/116482");
        }

        if (GUILayout.Button(ad3, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/slug/254384");
        }
        EditorGUILayout.EndScrollView();

    }
}


[InitializeOnLoad]
public class Startup
{
    static Startup()
    {
        EditorPrefs.SetInt("showCounts_WhiteCity", EditorPrefs.GetInt("showCounts_WhiteCity") + 1);       
        if (EditorPrefs.GetInt("showCounts_WhiteCity") == 10)
        { 
            EditorApplication.ExecuteMenuItem("Window/Asset Store Offers");
        }         
    }
}
#endif
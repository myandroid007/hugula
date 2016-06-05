﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEditor;
using UnityEngine;


public class AssetbundlesMenuItems
{

    #region unity5 AssetBundles export

    //[MenuItem("Assets/AssetBundles/Build AssetBundles", false, 2)]
    [MenuItem("AssetBundles/Build AssetBundles &b", false, 2)]
    static public void BuildAssetBundles()
    {
        BuildScript.BuildAssetBundles();
    }


    [MenuItem("Assets/AssetBundles/Set AssetBundle Name", false, 1)]
    static public void SetAssetBundlesName()
    {
        Object[] selection = Selection.objects;

        AssetImporter import = null;
        foreach (Object s in selection)
        {
            import = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(s));
            import.assetBundleName = s.name+"."+Common.ASSETBUNDLE_SUFFIX;
			if(s.name.Contains(" ")) Debug.LogWarning(s.name+" contains space");
            Debug.Log(s.name);
            if (s is GameObject)
            {
                GameObject tar = s as GameObject;
                ReferenceCount refe = LuaHelper.AddComponent(tar, typeof(ReferenceCount)) as ReferenceCount;
                refe.assetBundleName = s.name.ToLower();
            }
        }
    }

    [MenuItem("Assets/AssetBundles/Clear AssetBundle Name", false, 2)]
    static public void ClearAssetBundlesName()
    {
        Object[] selection = Selection.objects;

        AssetImporter import = null;
        foreach (Object s in selection)
        {
            import = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(s));
            import.assetBundleName = null;
            //if (s.name.Contains(" ")) Debug.LogWarning(s.name + " contains space");
            Debug.Log(s.name+" clear");
            if (s is GameObject)
            {
                GameObject tar = s as GameObject;
                ReferenceCount refe = LuaHelper.AddComponent(tar, typeof(ReferenceCount)) as ReferenceCount;
                refe.assetBundleName = string.Empty;
            }
        }
    }
    #endregion

    #region lua language config export
    [MenuItem("Hugula/", false, 11)]
    static void Breaker() { }

    [MenuItem("Hugula/Export Lua [Assets\\Lua] %l", false, 12)]
    public static void exportLua()
    {
        ExportResources.exportLua();
    }

    [MenuItem("Hugula/Export Config [Assets\\Config]", false, 13)]
    public static void exportConfig()
    {
        ExportResources.exportConfig();
    }

    [MenuItem("Hugula/Export Language [Assets\\Lan]", false, 14)]
    public static void exportLanguage()
    {
        ExportResources.exportLanguage();
    }

    [MenuItem("Hugula/", false, 15)]
    static void Breaker1() { }

    [MenuItem("Hugula/build for publish ", false, 16)]
    public static void exportPublish()
    {
        ExportResources.exportPublish();
    }
    #endregion

    #region hugula debug
    const string kDebugLuaAssetBundlesMenu = "Hugula/Debug Lua";

    [MenuItem(kDebugLuaAssetBundlesMenu, false, 1)]
    public static void ToggleSimulateAssetBundle()
    {
        PLua.isDebug = !PLua.isDebug;
    }

    [MenuItem(kDebugLuaAssetBundlesMenu, true,1)]
    public static bool ToggleSimulateAssetBundleValidate()
    {
        Menu.SetChecked(kDebugLuaAssetBundlesMenu, PLua.isDebug);
        return true;
    }
    #endregion

    #region 加密
    //[MenuItem("Hugula/AES/", false, 10)]
    //static void Breaker2() { }

    [MenuItem("Hugula/AES/GenerateKey", false, 12)]
    static void GenerateKey()
    {
        ExportResources.GenerateKey();
    }

    [MenuItem("Hugula/AES/GenerateIV", false, 13)]
    static void GenerateIV()
    {
        ExportResources.GenerateIV();
    }

    #endregion
}

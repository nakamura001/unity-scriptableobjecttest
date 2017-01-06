using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CreateScriptableObjectSample : MonoBehaviour {
    const int ParamCount = 100000;
    [MenuItem("ScriptableObject/Create")]
    public static void CreateAsset()
    {
        CreateSoClass();
        CreateSoStruct();
    }

    public static void CreateSoClass() {
        ScriptableObjectClassSample so = ScriptableObject.CreateInstance<ScriptableObjectClassSample>();
        so.list = new List<ScriptableObjectClassSample.Param>();
        for (int i=0; i<ParamCount; i++) {
            ScriptableObjectClassSample.Param param = new ScriptableObjectClassSample.Param();
            param.Hp = Random.Range(10, 1000);
            param.Mp = Random.Range(10, 1000);
            so.list.Add(param);
        }

        string path = "Assets/Resources/ClassSample.asset";

        AssetDatabase.DeleteAsset (path);
        AssetDatabase.CreateAsset(so, path);
        AssetDatabase.SaveAssets();
    }

    public static void CreateSoStruct() {
        ScriptableObjectStructSample so = ScriptableObject.CreateInstance<ScriptableObjectStructSample>();
        so.list = new List<ScriptableObjectStructSample.Param>();
        for (int i=0; i<ParamCount; i++) {
            ScriptableObjectStructSample.Param param = new ScriptableObjectStructSample.Param();
            param.Hp = Random.Range(10, 1000);
            param.Mp = Random.Range(10, 1000);
            so.list.Add(param);
        }

        string path = "Assets/Resources/StructSample.asset";

        AssetDatabase.DeleteAsset (path);
        AssetDatabase.CreateAsset(so, path);
        AssetDatabase.SaveAssets();
    }
}
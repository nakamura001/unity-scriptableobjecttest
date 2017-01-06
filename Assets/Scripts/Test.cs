using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour {
    // ScriptableObject は初回の Resources.Load で動作するが2回目以降はほぼ0秒で処理が終わる様なので
    // LoadCount と TestCount は 1 に設定
    const int LoadCount = 1;
    const int TestCount = 1;
    public InputField outputIField;
    ScriptableObjectClassSample[] classData = new ScriptableObjectClassSample[TestCount];
    ScriptableObjectStructSample[] structData = new ScriptableObjectStructSample[TestCount];

    public void Execute() {
        float startTime;
        string output = "";
        // Class
        output += "[Class]\n";
        for (int i=0; i<LoadCount; i++) {
            for (int j=0; j<TestCount; j++) {
                startTime = Time.realtimeSinceStartup;
                classData[0] = Resources.Load<ScriptableObjectClassSample>("ClassSample");
                output += string.Format("{0:f3}\n", Time.realtimeSinceStartup - startTime);
            }
        }

        output += "\n";
        // Struct
        output += "[Struct]\n";
        for (int i=0; i<LoadCount; i++) {
            for (int j=0; j<TestCount; j++) {
                startTime = Time.realtimeSinceStartup;
                structData[j] = Resources.Load<ScriptableObjectStructSample>("StructSample");
                output += string.Format("{0:f3}\n", Time.realtimeSinceStartup - startTime);
            }
        }

        outputIField.text += output;
    }
}

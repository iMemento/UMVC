using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateNewUIScriptsEditor : EditorWindow
{

    [MenuItem("Template Script/Create")]
    static void OpenEditor()
    {
        GetWindowWithRect<CreateNewUIScriptsEditor>(new Rect(100, 100, 300, 200), false, "Create");
    }

    private string scriptName = "Xxx";
    private string namespaceName = "";

    private readonly string PATH_TO_PRESENTER_TEMPLATE = "Assets/Scripts/UI/Common/TemplatePresenter.cs";
    private readonly string PATH_TO_CONTROLLER_TEMPLATE = "Assets/Scripts/UI/Common/TemplateController.cs";

    void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.Label("===================================");
        GUILayout.BeginHorizontal();
        GUILayout.Label("script:");
        scriptName = GUILayout.TextField(scriptName, 30);
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
        GUILayout.Label("namespace:");
        namespaceName = GUILayout.TextField(namespaceName, 30);
        GUILayout.EndHorizontal();


        EditorGUILayout.Space();
        GUILayout.Label("===================================");
        var tmpNameSpace = namespaceName == "" ? "" : "." + namespaceName;
        GUI.color = Color.cyan;
        GUILayout.Label(string.Format("namespace: Client.UI{0}", tmpNameSpace));
        GUILayout.Label(string.Format("controller: {0}Controller", scriptName));
        GUILayout.Label(string.Format("presenter: {0}Presenter", scriptName));

        EditorGUILayout.Space();

        if (GUILayout.Button("Create"))
        {
            Create();
        }
    }

    void Create()
    {
        var presenter = string.Format("{0}Presenter", scriptName);
        var controller = string.Format("{0}Controller", scriptName);

        var folderPath = "Assets/Scripts/UI/";
        if (namespaceName != null && namespaceName != "")
        {
            folderPath = string.Format("Assets/Scripts/UI/{0}/", namespaceName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }


        var presenterPath = folderPath + presenter + ".cs";
        var controllerPath = folderPath + controller + ".cs";

        if (!File.Exists(presenterPath))
        {
            File.Copy(PATH_TO_PRESENTER_TEMPLATE, Path.Combine(folderPath, presenter + ".cs"));
            var text = File.ReadAllText(presenterPath);
            text = text.Replace("TemplatePresenter", presenter);
            text = text.Replace("TemplateController", controller);
            if (namespaceName != null && namespaceName != "")
            {
                text = text.Replace("namespace Client.UI", string.Format("namespace Client.UI.{0}", namespaceName));
            }
            File.WriteAllText(presenterPath, text);
        }

        if (!File.Exists(controllerPath))
        {
            File.Copy(PATH_TO_CONTROLLER_TEMPLATE, Path.Combine(folderPath, controller + ".cs"));
            var text = File.ReadAllText(controllerPath);
            text = text.Replace("TemplatePresenter", presenter);
            text = text.Replace("TemplateController", controller);
            if (namespaceName != null && namespaceName != "")
            {
                text = text.Replace("namespace Client.UI", string.Format("namespace Client.UI.{0}", namespaceName));
            }
            File.WriteAllText(controllerPath, text);
        }

        AssetDatabase.Refresh();
    }
}

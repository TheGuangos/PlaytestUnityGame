using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
public class Manager_xml : MonoBehaviour
{
    public GameObject txtScene;
    public GameObject txtOption1;
    public GameObject txtOption2;
    public GameObject txtOption3;
    public GameObject txtOption4;
    public GameObject counterClicks;

    GameObject[] textOptions;

    private static Dictionary<string, List<string>> optionsByScenes;

    void Start ()
    {
        textOptions = new GameObject[] { txtOption1, txtOption2, txtOption3, txtOption4 };

        LoadSceneData();
        PopulateText();
        AddCounterClicks();

	}

    private void LoadSceneData()
    {
        optionsByScenes = new Dictionary<string, List<string>>();

        TextAsset xmlData = (TextAsset)Resources.Load("data");
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xmlData.text);

        foreach (XmlNode scene in xmlDocument["scenes"].ChildNodes)
        {
            string sceneName = scene.Attributes["name"].Value;

            List<string> options = new List<string>();
            foreach (XmlNode option in scene["options"].ChildNodes)
            {
                options.Add(option.InnerText);
            }
            optionsByScenes[sceneName] = options;
        }
    }
	
    private void PopulateText()
    {
        foreach (KeyValuePair<string, List<string>> optionsByScene in optionsByScenes)
        {
            txtScene.GetComponent<Text>().text = optionsByScene.Key;

            for (int i = 0; i<textOptions.Length; i++)
            {
                textOptions[i].GetComponent<Text>().text = optionsByScene.Value[i];
            }
        }
    }

    private void AddCounterClicks()
    {
        
    }

}

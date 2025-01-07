using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class JSONRetrieve : MonoBehaviour
{
    public Text JSON_Name;
    public Slider dat;
    public Text Slider_cond;
    public Text Test_Text;
    public string jsonURL;
    public Jsonclass jsnData;
    // Start is called before the first frame update
    void Start()
    {
        dat.interactable = false;
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        Debug.Log("Loading JSON");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultFile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultFile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            JSON_Name.text = "Error";
        }
        else
        {
            Debug.Log("File saved in " + resultFile);
            jsnData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
            JSON_Name.text = jsnData.Text_Field.ToString();
            dat.value = jsnData.Slider_var;
            Slider_cond.text = jsnData.Slider_var.ToString();
            Test_Text.text = jsnData.Text_Field_2.ToString();
            yield return StartCoroutine(getData());
        }

    }

    [System.Serializable]

    public class Jsonclass
    {
        public string Text_Field;
        public int Slider_var;
        public string Text_Field_2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using Unity.VisualScripting.FullSerializer;

public class CubeColorChange : MonoBehaviour
{
    public int red;
    public int green;
    public int blue;
    public Jsonclass jsnData;
    void Start()
    {
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        jsnData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
        red = jsnData.Red;
        green = jsnData.Green;
        blue = jsnData.Blue;
        yield return StartCoroutine(getData());
    }

    void FixedUpdate()
    {
        this.GetComponent<Renderer>().material.color = new Color32((byte)red, (byte)green, (byte)blue, 1);
    }

    [System.Serializable]
    public class Jsonclass
    {
        public int Red;
        public int Green;
        public int Blue;
    }

}

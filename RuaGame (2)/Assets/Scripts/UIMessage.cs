using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class UIMessage : MonoBehaviour
{
    public static Vector3 vec3, pos;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().bloodvolume <= 0)
            GUI.Window(0, new Rect(200, 100, 100, 100), WindowFunc, "您死了");
    }

    [System.Obsolete]
    private void WindowFunc(int windowid)
    {
        if (GUI.Button(new Rect(36,40,30,30), "草"))
        {
            Application.LoadLevel("Scene01");
        }
        //定义窗体可以活动的范围
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickedBack : Clicked
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Click()
    {
        BackMainMap();
    }
    private void BackMainMap()
    {
        SceneManager.LoadScene("MainMap");
    }
}

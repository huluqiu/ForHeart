using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{

    public static CanvasControl Instance;

    public TextManager textManager;
    public TableButton tableButton;

    // Use this for initialization
    void Start ()
    {
        Instance = this;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowText()
    {
        int index = Random.Range(1, XMLHelper.MAX + 1);
        string content = XMLHelper.Instance.AnswersDictionary[index].Content;
        string subcontent = XMLHelper.Instance.AnswersDictionary[index].SubContent;

        textManager.Show(content, subcontent);
    }

    public void ResetText()
    {
        textManager.Reset();
    }
}

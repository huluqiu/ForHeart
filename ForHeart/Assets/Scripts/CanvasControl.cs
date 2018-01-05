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
        textManager.Show(XMLHelper.Instance.AnswersDictionary[1].Content, XMLHelper.Instance.AnswersDictionary[1].SubContent);
    }

    public void ResetText()
    {
        textManager.Reset();
    }
}

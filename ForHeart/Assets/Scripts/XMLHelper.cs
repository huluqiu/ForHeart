using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class XMLHelper : MonoBehaviour
{

    public static XMLHelper Instance;
    public Dictionary<int, Answer> AnswersDictionary;

    // Use this for initialization
    void Start ()
	{

	    Instance = this;
        AnswersDictionary = new Dictionary<int, Answer>();
	    ReadConfig(ref AnswersDictionary);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void ReadConfig(ref Dictionary<int, Answer> AnswersDictionary)
    {

        string data = Resources.Load("XML/Answers").ToString();
        TextReader tr = new StringReader(data);
        XDocument xDocument = XDocument.Load(tr);

        var answerDic = new Dictionary<int, Answer>();

        foreach (var str in xDocument.Descendants("chapter"))
        {
            var answer = new Answer();

            answer.Id = str.Attribute("id") == null ? -1 : int.Parse(str.Attribute("id").Value);
            answer.Content = str.Attribute("content") == null ? "" : (str.Attribute("content").Value);
            answer.SubContent = str.Attribute("subcontent") == null ? "" : (str.Attribute("subcontent").Value);

            answerDic.Add(answer.Id, answer);
        }

        AnswersDictionary = answerDic;
        Debug.Log("Read XML Successfully ! ! !");
    }
}

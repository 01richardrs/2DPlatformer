using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int m_Score;
    public Text tscore;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreText = GameObject.Find("Score");
        tscore = scoreText.GetComponent<Text>();
        SetText();
    }

    // Update is called once per frame
    void SetText()
    {
        //Fetch the score from the PlayerPrefs (set these Playerprefs in another script). If no Int of this name exists, the default is 0.
        m_Score = PlayerPrefs.GetInt("Score", 0);
        // int iscore = int.Parse(m_Score);
        tscore.text = m_Score.ToString();
    }
}

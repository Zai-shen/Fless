using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreTxt;
    public Text highScoreTxt;
    public Text HSIndicatorTxt;
    public Font HSHighlightFont;
    public ParticleSystem HSParticleSystem;
    [SerializeField]
    private float score = default;
    private bool highlighted;

    // Start is called before the first frame update
    void Start()
    {
        highScoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString("0");

        if (score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            highScoreTxt.text = score.ToString("0");

            HighlightHighScore();
        }
    }

    public void increaseScore(float amount)
    {
        score += amount;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreTxt.text = "0";
    }

    private void HighlightHighScore()
    {
        if (!highlighted)
        {
            HSIndicatorTxt.GetComponent<Text>().text = "NEW HIGHSCORE";
            HSIndicatorTxt.GetComponent<Text>().font = HSHighlightFont;
            HSIndicatorTxt.GetComponent<Text>().fontSize = 30;

            HSParticleSystem.gameObject.SetActive(true);

            highlighted = true;
        }
    }
}

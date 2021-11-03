using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    [SerializeField] private GameObject canvasMain, canvasScore, canvasTime;
    [SerializeField] private Text textTime, textScore;

    private void Start()
    {
        PlayerPrefs.SetFloat("time_needed", 1);
        PlayerPrefs.SetFloat("score_needed", 1);
    }


    public void StartGame(int mode) // Endless=0; TimeMode=1; ScoreMode=2;
    {
        PlayerPrefs.SetInt("modeInt", mode);
        SceneManager.LoadScene(1);
        
    }

    public void TimeModeClick()
    {
        canvasMain.SetActive(false);
        canvasTime.SetActive(true);


    }
    public void ScoreModeClick()
    {
        canvasMain.SetActive(false);
        canvasScore.SetActive(true);

    }
    public void ExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void BackToMain()
    {
        canvasMain.SetActive(true);
        canvasTime.SetActive(false);
        canvasScore.SetActive(false);
    }
    public void SliderTimeChange(Slider sliderT)
    {
        textTime.text = sliderT.value.ToString();
        PlayerPrefs.SetFloat("time_needed", sliderT.value);
    }
    public void SliderScoreChange(Slider sliderS)
    {
        textScore.text = sliderS.value.ToString();
        PlayerPrefs.SetFloat("score_needed", sliderS.value);
    }



}

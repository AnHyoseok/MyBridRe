using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace MyBird
{

    public class GameOverUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI score;
        public TextMeshProUGUI bestScoreText;
        //베스트 스코어 ui
        public TextMeshProUGUI newText;
        #endregion

        private void OnEnable()
        {
            //저장된 데이터 가져오기
            GameManager.Bestscore = PlayerPrefs.GetInt("BestScore", 0);

            if (GameManager.Bestscore < GameManager.Score)
            {
                GameManager.Bestscore = GameManager.Score;
                PlayerPrefs.SetInt("BestScore", GameManager.Score);
                //게임 데이터 저장
                newText.text = "NEW";
            }
            else if (GameManager.Bestscore == GameManager.Score)
            {
                newText.color = Color.blue;
                newText.text = "SAME";
               
            }
            else
            {
                newText.text = " ";
            }


            //UI 연결
            score.text = GameManager.Score.ToString();
            bestScoreText.text = GameManager.Bestscore.ToString();
        }

       

        public void Retry()
        {

            //resultUi.SetActive(false);
            //readyUI.SetActive(true);
            SceneManager.LoadScene(1);

        }

        public void Menu()
        {
            SceneManager.LoadScene(0);
        }
    }

}
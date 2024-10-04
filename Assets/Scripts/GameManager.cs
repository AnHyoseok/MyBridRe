using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyBird
{

    public class GameManager : MonoBehaviour
    {
        #region Variable
        public static bool IsStart { get; set; }

        public static bool IsDeath { get; set; }

        public static int Score { get; set; }

        public static int Bestscore {  get; set; }
        //게임 UI
        public TextMeshProUGUI scoreText;

       
        #endregion


        private void Start()
        {
            

            //초기화
            IsStart = false;
            IsDeath = false;
            Score = 0;
        }

        private void Update()
        {
            //스코어 ui
            scoreText.text = Score.ToString();
        

        }




    }

}
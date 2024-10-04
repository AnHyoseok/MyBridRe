using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyBird
{

    public class TitleUI : MonoBehaviour
    {
        private void Update()
        {
            //치트 - p key
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetGameData();
            }
           
        }

        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        //치트 - 게임데이터 리셋
        void ResetGameData()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
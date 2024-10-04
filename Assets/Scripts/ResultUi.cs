using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyBird
{

    public class ResultUi : MonoBehaviour
    {
        public GameObject resultUi;
        public TextMeshPro scoreText;

        void Start()
        {
            
        }

       public void OnResultUi()
        {
            resultUi.SetActive(true);
            scoreText.text = "2";
        }
    }
}


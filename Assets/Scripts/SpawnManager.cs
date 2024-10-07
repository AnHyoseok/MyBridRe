using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


namespace MyBird
{

    public class SpawnManager : MonoBehaviour
    {
        #region Variables
        //프리팹
        public GameObject pipePrefab;
        //
        public Transform SpawnPoint;
        //스폰 타이머
        [SerializeField] private float spawnTimer = 1.0f;
        private float countdown = 0f;

        [SerializeField] private float maxSpawnTimer = 1.05f;
        [SerializeField] private float minSpawnTimer = 0.9f;
        public static float levelTime = 0f;

        [SerializeField] private float maxSpawnY = -2.7f;
        [SerializeField] private float minSpawnY = 2f;

        private int pipercount;
        
        #endregion

        private void Start()
        {
            //초기화
            countdown = spawnTimer;
            levelTime = 0f;
        }

        void Update()
        {

            if (GameManager.IsStart == false)
                return;

            //스폰타이머
            if (countdown <=0f)
            {
               SpawnPipe();
                countdown = Random.Range(minSpawnTimer, maxSpawnTimer);
            }
            countdown -= Time.deltaTime;

            //if (GameManager.Score % 5 == 0 && GameManager.Score!=0)
            //{
            //    SpawnLevel();
            //    Debug.Log(minSpawnY);
            //    //한번만실행하게해야됨
            //}
        }

        void SpawnPipe()
        {
            if (GameManager.IsStart == false|| GameManager.IsDeath)
                return;
            
            float ran = Random.Range(minSpawnY- levelTime, maxSpawnY);

            Vector3 spawnPosition = new Vector3(SpawnPoint.position.x, ran, SpawnPoint.position.z + 0f);
            SpawnPoint.position = spawnPosition;

            GameObject spawnedPipe= Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
            pipercount++;
            //2~-2.7
            Debug.Log(minSpawnY);
        }
        //private void SpawnLevel()
        //{
        //    minSpawnTimer -= 0.05f;
        //}

    }

}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

namespace MyBird
{

    public class Player : MonoBehaviour
    {
        #region Vairables

        private Rigidbody2D rb2d;

        //점프
        [SerializeField] private float jumpForce = 5f;
        private bool keyJump = false;      //점프키 입력 체크

        //회전
        private Vector3 birdRotion;
        [SerializeField] private float rotateSpeed = 3f;

        //이동
        [SerializeField] private float moveSpeed = 5f;

        //대기
        [SerializeField] private float readyForce = 1f;

        //게임 UI
        public GameObject tItleUI;
        public GameObject readyUI;
        public GameObject resultUi;
        public GameObject playUI;

        
    
        #endregion

        void Start()
        {
            readyUI.SetActive(true);
            rb2d = GetComponent<Rigidbody2D>();

        }
        void Update()
        {
           

            //키입력
            InputBird();

            //정지
            ReadyBird();

            //회전
            RotateBird();

            //이동
            MoveBird();
        }

        private void FixedUpdate()
        {
            //점프
            if (keyJump)
            {
                //Debug.Log("점프");
                JumpBird();
                keyJump = false;
            }
            //Debug.Log(rb2d.velocity.y);
        }

        void InputBird()
        {
            if (GameManager.IsDeath) return;
            //점프 : 스페이스바 또는 마우스 왼클릭
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);

            if (GameManager.IsStart == false && keyJump)
            {
                MoveStartBird();
               
            }
        }

        //버드 점프 
        void JumpBird()
        {
            //힘을 위로
            rb2d.velocity = Vector2.up * jumpForce;
        }

        //버드 회전
        void RotateBird()
        {
            //up +30,down -90;
            float degree = 0;


            //올라갈때
            if (rb2d.velocity.y > 0f)
            {
                degree = rotateSpeed;
                //rb2d.MoveRotation(30f);
            }
            // 내려갈 때
            else if (rb2d.velocity.y < 0f)
            {
                degree = -rotateSpeed;
                //rb2d.MoveRotation(-90f);
            }

            float rotationZ = Mathf.Clamp(birdRotion.z + degree, -90f, 30f);
            birdRotion = new Vector3(0f, 0f, rotationZ);

            transform.eulerAngles = birdRotion;
        }

        //버드 이동
        void MoveBird()
        {
            //
            if (GameManager.IsStart == false || GameManager.IsDeath)
                return;

            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }

        //버드 대기
        public void ReadyBird()
        {
            if (GameManager.IsStart) return;
     
            //위쪽으로 힘을 주어 제자리에 있기
            if (rb2d.velocity.y < 0f)
            {
                rb2d.velocity = Vector2.up * readyForce;
            }

        }

        //버드 죽기
        void DieBird()
        {
            //두번죽음 방지
            if(GameManager.IsDeath) return;

            Debug.Log("죽음 처리");
            
            GameManager.IsDeath = true;
            resultUi.SetActive(true);


        }

        //점수 흭득
        void GetPoint()
        {

            if (GameManager.IsDeath) return;

            GameManager.Score++;
            
           
        }

        //이동시작시
        void MoveStartBird()
        {
            GameManager.IsStart = true;
            readyUI.SetActive(false);
        }


        private void OnTriggerEnter2D(Collider2D Collider)
        {

            if (Collider.tag == "Pipe")
            {
                DieBird();
            
            }
            else if(Collider.tag == "Point")
            {
               
                GetPoint();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                DieBird();
               
            }
        }

        
     
    }

}
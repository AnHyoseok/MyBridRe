using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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

        #endregion

        void Start()
        {
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
                Debug.Log("점프");
                JumpBird();
                keyJump = false;
            }
            //Debug.Log(rb2d.velocity.y);
        }

        void InputBird()
        {
            //점프 : 스페이스바 또는 마우스 왼클릭
            keyJump |= Input.GetKeyDown(KeyCode.Space);
            keyJump |= Input.GetMouseButtonDown(0);

            if (GameManager.IsStart == false && keyJump)
            {
                GameManager.IsStart = true;
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
            if (GameManager.IsStart == false)
            return;
            
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
        }

        //버드 대기
        void ReadyBird()
        {
            if(!GameManager.IsStart) return;

            //위쪽으로 힘을 주어 제자리에 있기
            if (rb2d.velocity.y < 0f)
            {
                rb2d.velocity = Vector2.up * readyForce;
            }

        }
    }

}
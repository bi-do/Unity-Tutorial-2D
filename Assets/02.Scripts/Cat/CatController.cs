using System.Collections;
using Cat;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public SoundManager sound_manager; // 사운드 매니저
    public VideoManager video_manager; // 비디오 매니저

    public GameObject play_UI;
    public GameObject game_over_UI;
    public GameObject fade_UI;

    private Rigidbody2D cat_rb;
    private Animator cat_ani;

    /// <summary> 게임 시작시 배치되는 처음 위치 </summary>
    private Vector2 init_pos;

    /// <summary> 클리어에 필요한 사과 개수 </summary>
    private int clear_count = 10;

    /// <summary> 점프력 </summary>
    public float jump_force = 7f;

    /// <summary> 점프 횟수 상수 ( 매크로 상수 처럼 동작하게끔 만듬 , C#은 매크로가 없냐 왜... ) </summary>
    public int jump_count = 3;

    /// <summary> 실제 로직에서 사용되는 int </summary>
    private int jump_count_real;

    void Awake()
    {
        this.cat_rb = this.GetComponent<Rigidbody2D>();
        this.cat_ani = this.GetComponent<Animator>();
        this.jump_count_real = this.jump_count;

        this.init_pos = this.transform.position;
    }

    void OnEnable()
    {
        this.transform.position = this.init_pos;
        this.GetComponent<CircleCollider2D>().enabled = true;
        this.sound_manager.audio_source.Play();
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump_count_real > 0)
        {
            // (점프 = y축 방향으로 이동) == false
            this.cat_rb.AddForceY(this.jump_force, ForceMode2D.Impulse);

            // 걷는 애니메이션 false
            this.cat_ani.SetBool("isGround", false);

            // 애니메이션 실행
            this.cat_ani.SetTrigger("Jump");

            // 점프 카운트 감소
            this.jump_count_real--;

            // 사운드 재생
            this.sound_manager.OnJumpSound();
        }
        this.Jump_Rotate();
    }

    /// <summary> 점프 했을 시 고양이 각도 전환 ( 진짜 점프 하는 것 처럼 ) </summary>
    private void Jump_Rotate()
    {
        var catRotation = this.transform.eulerAngles;
        catRotation.z = this.cat_rb.linearVelocityY * 3f;
        this.transform.eulerAngles = catRotation;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple")) // 사과 아이템 획득 시
        {
            // 해당 사과 비활성화
            collision.gameObject.SetActive(false);

            // 획득 이펙트 활성화 및 점수 획득
            collision.transform.parent.GetComponent<ItemEvent>().eat_effect.SetActive(true);
            GameManager.score++;

            // 10점 이상 획득 시 화이트 페이드 활성화
            if (GameManager.score >= this.clear_count)
            {
                // 고양이 콜라이더 비활성화
                this.GetComponent<CircleCollider2D>().enabled = false;

                fade_UI.SetActive(true);

                fade_UI.GetComponent<FadeRoutine>().OnFade(3f, Color.white, true);

                StartCoroutine(EndingRoutine(true));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 지면에 닿았을 때
        {
            // 걷는 모션 재 실행
            this.cat_ani.SetBool("isGround", true);

            // 점프 횟수 초기화
            this.jump_count_real = this.jump_count;
        }
        else if (collision.gameObject.CompareTag("Pipe")) // 파이프 충돌 시
        {
            // 고양이 콜라이더 비활성화
            this.GetComponent<CircleCollider2D>().enabled = false;

            // 충돌 사운드 재생
            this.sound_manager.OnColliderSound();

            // 게임 오버 UI 및 페이드 UI ON
            this.game_over_UI.SetActive(true);
            this.fade_UI.SetActive(true);

            // 화면 페이드 ( 게임 오버 )
            this.fade_UI.GetComponent<FadeRoutine>().OnFade(3f, Color.black, true);

            StartCoroutine(EndingRoutine(false));
        }
    }

    IEnumerator EndingRoutine(bool param_isClear)
    {
        this.sound_manager.audio_source.Stop();

        yield return new WaitForSeconds(3.5f);


        this.video_manager.VideoPlay(param_isClear);

        yield return new WaitForSeconds(1f);

        Color new_color = param_isClear ? Color.white : Color.black;
        this.fade_UI.GetComponent<FadeRoutine>().OnFade(3f, new_color, false);
        this.game_over_UI.SetActive(false);

        yield return new WaitForSeconds(3f);

        this.transform.parent.gameObject.SetActive(false);
        this.fade_UI.SetActive(false);
    }
}

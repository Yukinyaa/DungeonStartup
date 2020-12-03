using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{
    [System.Serializable]
    public class SoundEntry
    {
        public string name;
        public AudioClip clip;
    }

    // Declare Component
    Animator anim;                      // Animator
    AudioSource audioSource;            // AudioSource
    Rigidbody2D rigid;                  // RigidBody2D
    public Image hpBar;                 // HP_Bar
    GameManager manager;

    // Declare Variables
    public SoundEntry[] clips;
    bool attacked;
    bool isJump;
    int hitDirection;
    bool isCoolTime;

    // Player Status
    float maxHp;
    float nowHp;
    int attackDamage;
    float attackSpeed = 0.8f;
    float moveSpeed = 10;
    float jumpForce;
    int defense;

    public Transform pos;
    public Vector2 boxSize;
  
    void Awake()
    {
        anim            = GetComponent<Animator>();
        audioSource     = GetComponent<AudioSource>();
        rigid           = GetComponent<Rigidbody2D>();
        hpBar           = GameObject.FindObjectOfType<HpBar>().GetComponent<Image>();
        manager         = GameObject.FindObjectOfType<GameManager>();

        attacked        = false;
        isJump          = false;
        hitDirection    = 0;

        Camera.main.GetComponent<CameraControl>().target = this.gameObject;
        //InitStatus(100, 10, 100f, 5f, 7.5f, 100, 100);     // Init Player Status
    }

    void Update()
    {
        // 플레이어 이동
        if (Input.GetKey(KeyCode.LeftArrow) && !attacked)
        {
            // 레이캐스트를 이용해 벽을 뚫고 가지 못하도록 설정
            Vector2 frontVec = new Vector2(rigid.position.x - 1 * 0.4f, 0);
            RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.left, LayerMask.GetMask("Wall"));

            // 애니메이션 재생
            anim.SetBool("Walking", true);
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
            if (hit.collider.name != "Wall")
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !attacked)
        {
            Vector2 frontVec = new Vector2(rigid.position.x + 1 * 0.4f, 0);
            RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.right, LayerMask.GetMask("Wall"));

            anim.SetBool("Walking", true);
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            if (hit.collider.name != "Wall")
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            }
        }
        else anim.SetBool("Walking", false);

        // 플레이어 공격
        if (Input.GetKey(KeyCode.LeftControl) && !attacked && !isCoolTime)
        {
            anim.SetTrigger("Attack");
            attacked = true;
            isCoolTime = true;
            AttackFalse();
            Invoke("CoolTimeFalse", 1/attackSpeed);
        }

        // 피격 시 날라가는 방향에 벽이 있으면 더 이상 밀려나지 않도록 설정 (좌: -1, 우: 1)
        if (hitDirection == -1)
        {
            Vector2 frontVec = new Vector2(rigid.position.x - 1 * 0.4f, 0);
            RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.left, LayerMask.GetMask("Wall"));

            if (hit.collider.name == "Wall")
            {
                rigid.velocity = Vector3.zero;
            }
        }
        else if (hitDirection == 1)
        {
            Vector2 frontVec = new Vector2(rigid.position.x + 1 * 0.4f, 0);
            RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.right, LayerMask.GetMask("Wall"));

            if (hit.collider.name == "Wall")
            {
                rigid.velocity = Vector3.zero;
            }
        }

        // 플레이어 점프
        if (Input.GetKey(KeyCode.LeftAlt) && !anim.GetBool("isJump"))
        {
            SoundPlayJump();
            anim.SetBool("isJump", true);
            rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Set Player Status
    public void InitStatus(float maxHp, int attackDamage, float attackSpeed, float moveSpeed, float jumpForce, int defense, int attackReach)
    {
        this.maxHp = maxHp;
        this.nowHp = maxHp;
        this.attackDamage = attackDamage;
        this.attackSpeed = this.attackSpeed / (100 / (attackSpeed + 100f));
        this.moveSpeed = this.moveSpeed / (100 / (moveSpeed + 100f));
        this.jumpForce = jumpForce;
        this.defense = defense;
        this.boxSize.x = this.boxSize.x * ((100f + attackReach) / 100f);
        hpBar.fillAmount = (nowHp / maxHp);
    }

    // Damage Effect
    public void TakeDamage(int dmg)
    {
        nowHp -= (100f/(100f+defense))*dmg;
        // HP Bar 설정
        hpBar.fillAmount = (nowHp / maxHp);
        if (nowHp <= 0)
        {
            manager.SetPlayerDie();
            Destroy(gameObject);    //죽음
        }
    }
    public void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 11;  //무적 상태
        hitDirection = transform.position.x - targetPos.x > 0 ? 1 : -1;

        rigid.AddForce(new Vector2(hitDirection, 1) * 3, ForceMode2D.Impulse);
        
        Invoke("OffDamaged", 1);
    }
    public void OffDamaged()
    {
        gameObject.layer = 10;  //무적 상태 해제
    }

    // Animation Trigger
    public void AttackFalse()
    {
        attacked = false;
    }
    public void CoolTimeFalse()
    {
        isCoolTime = false;
    }

    public void Attack()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Monster" && collider.isTrigger == false)
            {
                collider.GetComponent<Monster>().TakeDamage(attackDamage);
            }
        }
    }

    // Collision Event

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isJump", false);
        anim.SetTrigger("Grounding");

        if (collision.gameObject.tag == "Monster")
        {
            TakeDamage(collision.gameObject.GetComponent<Monster>().attackDamage);
            OnDamaged(collision.transform.position);
        }
    }

    // Trigger Event


    // 공격 영역 표시 (에디터 보기)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    // Animation Sounds
    void SoundPlayWalk()
    {
        int n = Random.Range(0, 6);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("Walk_");
        sb.Append(n.ToString());

        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].name == sb.ToString())
            {
                audioSource.clip = clips[i].clip;
                audioSource.Play();
            }
        }
    }

    void SoundPlayAttack()
    {
        for(int i = 0; i < clips.Length; i++)
        {
            if(clips[i].name == "Attack")
            {
                audioSource.clip = clips[i].clip;
                audioSource.Play();
            }
        }
    }

    void SoundPlayJump()
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].name == "Jump")
            {
                audioSource.clip = clips[i].clip;
                audioSource.Play();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    // Declare Component
    public GameObject prfHpBar;
    public RectTransform hpBar;
    Animator anim;
    GameObject traceTarget;
    AudioSource audio;            // AudioSource
    GameManager manager;

    // Declare Variables
    public float height = 1f;   // 체력바 높이
    bool isTracing;
    int movementFlag = 0;       // 0: idle, 1: left, 2: right
    public AudioClip hitSound;
    public AudioClip deathSound;
    Image nowHpBar;

    // Monster Status
    public float maxHp;
    float nowHp;
    public int attackDamage;
    public int attackSpeed;
    public float moveSpeed;
    string dist = "";
    bool die = false;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = Instantiate(prfHpBar, GameObject.FindWithTag("canvasBattle").transform).GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        audio        = GetComponent<AudioSource>();

        manager = FindObjectOfType<GameManager>();

        StartCoroutine("ChangeMovement");

        nowHp = maxHp;
        nowHpBar = hpBar.transform.GetChild(0).GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hpBar != null)
        {
            Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
            hpBar.position = _hpBarPos;
            nowHpBar.fillAmount = nowHp / maxHp;
        }
        
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        // AI
        if (isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if (Mathf.Round(playerPos.x * 10) * 0.1f < Mathf.Round(transform.position.x * 10) * 0.1f) dist = "Left";
            else if (Mathf.Round(playerPos.x * 10) * 0.1f > Mathf.Round(transform.position.x * 10) * 0.1f) dist = "Right";
            else dist = "Stop";
        }
        else
        {
            if (movementFlag == 1) dist = "Left";
            else if (movementFlag == 2) dist = "Right";
            else dist = "Stop";
        }

        // 이동
        if (!die)
        {
            if (dist == "Left")
            {
                Vector2 frontVec = new Vector2(transform.position.x - 1 * 0.4f, 0);
                RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.left, LayerMask.GetMask("Wall"));

                transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);

                if (hit.collider.name == "Wall" || hit.collider.name == "PlatWall")
                {
                    
                }
                else
                {
                    transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                }
            }
            else if (dist == "Right")
            {
                Vector2 frontVec = new Vector2(transform.position.x + 1 * 0.4f, 0);
                RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector3.right, LayerMask.GetMask("Wall"));

                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                

                if (hit.collider.name == "Wall" || hit.collider.name == "PlatWall")
                {
                    
                }
                else
                {
                    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                }
            }
        }
    }

    // 방향 전환 코루틴
    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);

        if (movementFlag == 0) anim.SetBool("isWalking", false);
        else anim.SetBool("isWalking", true);

        yield return new WaitForSeconds(Random.Range(3, 6));

        StartCoroutine("ChangeMovement");
    }

    // 일시 정지 코루틴
    IEnumerator StopMovement()
    {
        anim.SetBool("isWalking", false);

        yield return new WaitForSeconds(0.5f);

        StartCoroutine("ChangeMovement");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "Player")
        {
            traceTarget = col.gameObject;
            StopCoroutine("ChangeMovement");
        }
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            isTracing = true;
            anim.SetBool("isWalking", true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            isTracing = false;
            StartCoroutine("ChangeMovement");
        }
    }
    
    public void TakeDamage(int dmg)
    {
        anim.SetTrigger("hit");
        audio.clip = hitSound;
        audio.Play();

        nowHp -= dmg;
        
        if (nowHp <= 0)
        {
            GameManager.Instance.MobDie(gameObject);
            die = true;
            anim.SetBool("isWalking", false);
            anim.SetTrigger("die");
            audio.clip = deathSound;
            audio.Play();
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<CircleCollider2D>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(hpBar.gameObject);
            Destroy(gameObject, 1.2f);
        }
    }

    public void TakeDamageOn()
    {
        anim.SetBool("isWalking", false);
    }

    public void TakeDamageEnd()
    {
        anim.SetBool("isWalking", true);
    }


    public void Die()
    {
        Destroy(gameObject);
    }
}

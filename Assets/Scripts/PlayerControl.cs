using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private int jumpCount = 0;
    private Animator ani;
    private Rigidbody2D rig;
    public float JumpSpeed = 10;
    public float SecondJumpSpeed = 5f;
    public float ThirdJumpSpeed = 0.001f;
    public float gravityScale = 0.8f;
    public float startTime = 1f;
    public float repeateRate = 180f;
    private float speedIncreaseRate = 1.01f;
    Score score;
    public GameObject shield;
    private bool isShield = true;
    private bool IsSliping = false;
    public KeyCode jumpKey;
    public KeyCode jumpKey0;
    public CollisionSound collisionSound;
    SpriteRenderer spriteRenderer;
    public int playerHealth = 1;
    //EndGameListener endGame;

    public bool isCollision = false;

    public bool stillCollision = false;

    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        rig = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       // endGame = gameObject.GetComponent<EndGameListener>();
        InvokeRepeating("IncreaseSpeed", startTime, repeateRate);
        score = GetComponent<Score>();
        shield.SetActive(false);
        isShield = false;
        IsSliping = false;
        collisionSound = gameObject.GetComponent<CollisionSound>();
    }


    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && !IsSliping) || (Input.GetKeyDown(KeyCode.W) && !IsSliping) || (Input.GetKeyDown(KeyCode.UpArrow) && !IsSliping))
        //if ((Input.GetKeyDown(jumpKey) && !IsSliping) || (Input.GetKeyDown(jumpKey0) && !IsSliping))
        {
            if (0 == jumpCount)
            {
                ani.SetBool("IsJumping_1", true);
                collisionSound.AudioPlay("First_Jump");
                rig.velocity = new Vector2(0, JumpSpeed);
                ++jumpCount;
            }
            else if (1 == jumpCount)
            {
                ani.SetBool("IsJumping_2", true);
                collisionSound.AudioPlay("Second_Jump");
                rig.velocity = new Vector2(0, SecondJumpSpeed);
                ++jumpCount;

            }
            else if (2 == jumpCount)
            {
                ani.SetBool("IsFlying", true);
                collisionSound.AudioPlay("Fly");
                rig.gravityScale = gravityScale;
                rig.velocity = new Vector2(0, ThirdJumpSpeed);
                ++jumpCount;
            }
        }
        else if ((Input.GetKeyDown(KeyCode.S) && !IsSliping) || (Input.GetKeyDown(KeyCode.DownArrow) && !IsSliping))
        {
            IsSliping = true;
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                ani.SetBool("IsSliping", true);
                ani.SetBool("KeepSliping", true);
            }
        }

        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            ani.SetBool("IsSliping", false);
            ani.SetBool("KeepSliping", false);
            IsSliping = false;
        }


        if (playerHealth <= 0)
        {
            StartCoroutine(DieDelay());
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Floor")
        {

            ani.SetBool("IsJumping_1", false);
            ani.SetBool("IsJumping_2", false);
            ani.SetBool("IsFlying", false);
            rig.gravityScale = 6;

            jumpCount = 0;
        }

        if (other.gameObject.tag == "Trap")
        {
            isCollision = true;
            shield.SetActive(false);
            collisionSound.AudioPlay("Shield_Broken");
            isShield = false;
            playerHealth --;
            StartCoroutine(TrapcolliderDelay());
            
        }

        if (other.gameObject.tag == "Monster_Mushroom")
        {
            rig.AddForce(Vector3.up * 100);
            collisionSound.AudioPlay("Monster_Mushroom");
            score.IncreaseScore("MushRoom");
            Destroy(other.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isCollision = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Copper")
        {
            score.IncreaseScore("Copper");
            collisionSound.AudioPlay(other.tag);
        }
        else if (other.gameObject.tag == "Gold")
        {
            score.IncreaseScore("Gold");
            collisionSound.AudioPlay(other.tag);
        }
        else if (other.gameObject.tag == "Star")
        {
            score.IncreaseScore("Star");
            collisionSound.AudioPlay(other.tag);
        }
        else if (other.gameObject.tag == "Shield")
        {
            if (!isShield)
            {
                playerHealth++;
            }
            collisionSound.AudioPlay(other.tag);
            shield.SetActive(true);
            isShield = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "BackTrap")
        {
            //endGame.OpenScene("GameOver");
            //collisionSound.AudioPlay("P");
            //OpenScene("GameOver");
            StartCoroutine(DieDelay());
        }
    }

    void IncreaseSpeed()
    {
        ani.speed = ani.speed * speedIncreaseRate;
    }

    IEnumerator DieDelay()
    {
        collisionSound.AudioPlay("P");
        spriteRenderer.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
        OpenScene("GameOver");
    }

    IEnumerator TrapcolliderDelay()
    {
        yield return new WaitForSeconds(1.0f);
        if (isCollision)
        {
            playerHealth--;
        }

    }

    IEnumerator StillTrapColliderDelay()
    {
        yield return new WaitForSeconds(1.0f);
        if (stillCollision)
        {
            playerHealth--;
        }
    }



    void OpenScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

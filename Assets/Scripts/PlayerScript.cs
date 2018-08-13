using UnityEngine;
using EZCameraShake;

public class PlayerScript : MonoBehaviour {

    Vector2 target;
    public float speed = 1f;
    public GameObject death;
    public GameObject newHigh;
    bool newEffectShowed;

	void Start () {
        target = this.transform.position;
        newEffectShowed = false;
        //SpawnManager.instance.SpawnLoop();
    }
	void Update () {
        if (!GameManager.inGame) return;
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.score++;
            CameraFollow.instance.ColorChange();
            Move();
            SpawnManager.instance.SpawnLoop();
        }
        this.transform.position = Vector2.Lerp(transform.position, target, speed);
    }

    void Move()
    {
        if (GameManager.loopSpeed <= 150)
        {
            GameManager.loopSpeed += 1;
        }
        FindObjectOfType<AudioManager>().Play("Move");
        CameraShaker.Instance.ShakeOnce(2f, 2f, .05f, .05f);
        Vector2 tempTarget = target;
        tempTarget.y += 2;
        target = tempTarget;
        if(!newEffectShowed) HighScoreCheck();

    }

    void HighScoreCheck()
    {
        if(GameManager.score >= PlayerPrefs.GetInt("highScore", 0))
        {
            newEffectShowed = true;
            FindObjectOfType<AudioManager>().Play("Clap");
            Instantiate(newHigh, new Vector2(transform.position.x, transform.position.y + 7), Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.Play("Death");
        Debug.Log("Collision");
        if(collision.gameObject.tag == "Loop")
        {
            Instantiate(death, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.playerDead = true;
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }

    }
    
}

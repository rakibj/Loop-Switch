using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public static int score;
    public static bool inGame;
    public static bool playerDead;
    public static float loopSpeed;

    void Start () {
        MakeSingleton();
        score = 0;
        inGame = false;
        playerDead = false;
        loopSpeed = 80f;
	}
	
	void Update () {
		
	}

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

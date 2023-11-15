using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManagerMultiplayer : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManagerMultiplayer instance;
    public int currentScore;
    public int scorePerNote;
    public Text scoreText;
    public Text scoreText2;
    //public Text multiText;
    public int currentMultiplier;
    public int multiplierTracker, SCORE;
    public int[] multiplierThresholds;
    private float startVolume;
    private float fadeTime;
    public bool started;
    PhotonView PV;
    public GameObject final;

    public int hits;
    public player1anim PERSONAGEM1;
    public List<int> scoresforanim = new List<int>();
    public int score1, score2;
    // Start is called before the first frame update
    void Start()
    {
        PERSONAGEM1 = FindObjectOfType<player1anim>();
        instance = this;
        //scoreText.text = "Score: 0";
        startVolume = theMusic.volume;
        currentMultiplier = 1;
        PV = GetComponent<PhotonView>();
        fadeTime = 1.5f;
        
        //var scoresforanim = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            score1=currentScore;
            scoreText2.text = "Player 2: " + score2;
            scoreText.text = "Player 1: " + score1;
        }
        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            score2 = currentScore;
            scoreText.text = "Player 1: " + score1;
            scoreText2.text = "Player 2: " + score2;
        }*/
        scoreText.text = "Score: " + currentScore;

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            if (started == false)
            {
                start();
                StartCoroutine(MusicControl());
                started = true;
            }
            
            
        }

            // pass in the value to sync
            PV.RPC(nameof(DisplayScore), RpcTarget.Others, SCORE);
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            scoreText2.text = "Player 2: " + SCORE;
            scoreText.text = "Player 1: " + currentScore;
        }
        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            scoreText.text = "Player 1: " + SCORE;
            scoreText2.text = "Player 2: " + currentScore;
        }

    }

    public void start()
    {
        startPlaying = true;
        theBS.start();
    }
    public void NoteHit()
    {
        

        //multiText.text = "Multiplier: x" + currentMultiplier;
        currentScore += scorePerNote * currentMultiplier;
        //scoreText.text = "Score: " + currentScore;
        hits++;
        if (theBS.released > 10)
        {
            
            if (hits >= 9)
            {
                scoresforanim.Add(3);
                currentMultiplier = 3;
                PERSONAGEM1.great();
            } else
            if (hits >= 4 && hits<=8)
            {
                scoresforanim.Add(2);
                currentMultiplier = 2;
                PERSONAGEM1.good();
            }
            else if (hits <= 3)
            {
                scoresforanim.Add(1);
                PERSONAGEM1.fail();
            }
            hits = 0;
            theBS.released = 0;
            currentMultiplier = 1;


        }
    }
    public void NoteMissed()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;
        //multiText.text = "Multiplier: x" + currentMultiplier;
    }

    IEnumerator MusicControl()
    {
        yield return new WaitForSeconds(120f);
        while (theMusic.volume > 0)
        {
            theMusic.volume -= startVolume * Time.deltaTime / fadeTime;
        }
        theBS.stop();
        final.SetActive(true);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }


    [PunRPC]
    void DisplayScore(int currentscore)
    {

            SCORE = currentScore;

    }
    
}

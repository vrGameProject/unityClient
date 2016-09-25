using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockManager : MonoBehaviour {

    public GameObject[] blocks;

    public int maxTimeOut;
    private int timeOut;

    public float maxCounter;
    private float counter;
    private int countIndex;

    private float[] preHeight;
    private float maxHeight;


    private int score;

    public Text txtTime;
    public Text txtScore;
    public Text txtCount;

	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // set game state
        if (this.timeOut <= 0)
        {
            // stop game
            return;
        }
        
        float height = 0;
        for (int i = 0; i < this.blocks.Length; i++)
        {
            height = blocks[i].transform.position.y;

            if (height == this.preHeight[i] && this.maxHeight < height)
            {
                if (countIndex == -1)
                    this.countIndex = i;
                else if (this.countIndex == i)
                    UpdateCount();
            }
            else
            {
                this.preHeight[i] = height;

                if (this.countIndex == i)
                {
                    InitializeCount();
                }
            }
        }

        UpdateTime();
    }

    private void Initialize()
    {
        InitializeCount();
        this.preHeight = new float[blocks.Length];
        this.maxHeight = 0.75f;
        this.score = 0;
        this.timeOut = this.maxTimeOut;
        StartCoroutine(UpdateTime());
    }

    IEnumerator UpdateTime()
    {
        for (int i = 0; i < this.maxTimeOut; i++)
        {
            timeOut -= 1;
            txtTime.text = "TIME : " + timeOut;

            if (timeOut == 0)
            {
                txtTime.text = "GAME OVER";
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateCount()
    {
        if (countIndex == -1)
            return;

        this.counter -= Time.deltaTime;

        if (this.counter < 1)
        {
            UpdateScore(this.preHeight[countIndex]);
            InitializeCount();
        }
        else if (this.counter < 2)
        {
            this.txtCount.text = "1";
        }
        else if (this.counter < 3)
        {
            this.txtCount.text = "2";
        }
        else if (this.counter < 4)
        {
            this.txtCount.text = "3";
        }
        else
        {
            this.txtCount.text = "";
        }
    }

    private void InitializeCount()
    {
        this.countIndex = -1;
        this.counter = this.maxCounter;
        this.txtCount.text = "";
    }

    private void UpdateScore(float maxHeight)
    {
        if (0.75f < maxHeight)
        {
            this.score = 100;
            this.maxHeight = 1.75f;
        }
        else if (1.75f < maxHeight)
        {
            this.score = 200;
            this.maxHeight = 2.75f;
        }
        else if (2.75f < maxHeight)
        {
            this.score = 300;
            this.maxHeight = 3.75f;
        }
        else if (3.75f < maxHeight)
        {
            this.score = 400;
            this.maxHeight = 4.75f;
        }
        else if (4.75f < maxHeight)
        {
            this.score = 500;
            this.maxHeight = 5.75f;
        }

        this.txtScore.text = "SCORE : " + score;
    }
}

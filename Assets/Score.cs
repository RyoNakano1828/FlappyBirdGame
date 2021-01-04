using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text, high;
    //現在のスコア
    public int score;
    //ハイスコアを保存するint
    public static int save, save1, save2, highscore;
    public SceneChange sceneChange;

    //順位ごとにランキングを保存する配列
    public static int[] ranks;

    //ランキングテキストを表示する配列
    public Text[] texts;
    public static bool resetflag = true;

    // Start is called before the first frame update
    void Start()
    {
        //シーン始めにHighScoreをsavehighに代入する
        highscore = PlayerPrefs.GetInt("HighScore", 0);

        text = GetComponent<Text>();

        high = GameObject.Find("HighScore").GetComponent<Text>();
        high.text = "HighScore" + highscore;

        if(sceneChange.scene == Scene.GamePlay)
        {
            save = 0;
        }
        //ゲームが始まって1度だけランキングを初期生成する処理
        if(resetflag)
        {
            ranks = new int[11];
            for (int i = 0; i < 11; i++)
            {
                ranks[i] = 0;
            }
            resetflag = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneChange.scene == Scene.GamePlay)
        {
            text.text = "Score" + score;
            save = score;
            high.text = "HighScore" + highscore;

            //ハイスコアの更新
            if(highscore <= score)
            {
                highscore = score;
                //high.text = "HighScore" + highscore;
                PlayerPrefs.SetInt("HighScore", highscore);
                PlayerPrefs.Save();
            }
            //ランキング外にスコアを常に代入する処理
            //ranks[10] = score;
            PlayerPrefs.SetInt("rank" + 10, score);
            PlayerPrefs.Save();
        }

        else
        {
            //ランキングをソートする処理
            bool isEnd = false;
            int findAjust = 1;
            while (!isEnd)
            {
                bool loopSwap = false;
                for (int i = 0; i < ranks.Length - findAjust; i++)
                {
                    /*
                    if(ranks[i] < ranks[i+1])
                    {
                        save1 = ranks[i];
                        save2 = ranks[i
                    
                    + 1];
                        ranks[i] = save2;
                        ranks[i + 1] = save1;
                        loopSwap = true;
                    }
                    */
                    if(PlayerPrefs.GetInt("rank" + i, 0) < PlayerPrefs.GetInt("rank" + (i+1), 0))
                    {
                        save1 = PlayerPrefs.GetInt("rank" + i, 0);
                        save2 = PlayerPrefs.GetInt("rank" + (i + 1), 0);
                        PlayerPrefs.SetInt("rank" + i, save2);
                        PlayerPrefs.SetInt("rank" + (i + 1), save1);
                        loopSwap = true;
                    }
                }
                //Swapが一度も実行されなかった場合はソート終了
                if (!loopSwap)
                {
                    isEnd = true;
                }
                findAjust++;
            }
            for(int i = 1; i < ranks.Length; i++)
            {
                //texts[i-1].text = i+"位"+ranks[i-1];
                texts[i-1].text = i+"位" + PlayerPrefs.GetInt("rank" + (i-1), 0);
            }
            text.text = "Score" + save;
            high.text = "HighScore" + highscore;
        }
    }
}

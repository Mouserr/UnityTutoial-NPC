using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace Nightmare
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;
        private int levelThreshhold;
        const int LEVEL_INCREASE = 300;

        public static event Action LevelComplete;

        Text sText;

        void Awake ()
        {
            sText = GetComponent <Text> ();

            score = 0;
            levelThreshhold = LEVEL_INCREASE;
        }


        void Update ()
        {
            sText.text = "Score: " + score;
            if (score >= levelThreshhold)
            {
                if (LevelComplete != null)
                {
                    LevelComplete();
                }

                AdvanceLevel();
            }
        }

        private void AdvanceLevel()
        {
            levelThreshhold = score + LEVEL_INCREASE;
            LevelManager lm = FindObjectOfType<LevelManager>();
            lm.AdvanceLevel();
        }
    }
}
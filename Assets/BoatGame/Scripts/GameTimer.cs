using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI output;
        float startTime;
        bool running;

        public void StartTimer()
        {
            ResetTimer();
            running = true;
        }
        public void PauseTimer()
        {
            running = false;
        }
        public void UnpauseTimer()
        {
            running = true;
        }
        public void ResetTimer()
        {
            PauseTimer();
            startTime = Time.time;
        }
        void Start()
        {
            StartTimer();
        }
        void Update()
        {
            if (running)
            {
                float currentTime = Time.time - startTime;
                int minutes = Mathf.FloorToInt(currentTime) / 60;
                float seconds = currentTime % 60;
                seconds = Mathf.Round(seconds * 100) / 100;
                string m = minutes < 10 ? "0" + minutes : minutes.ToString();
                string s = seconds < 10 ? "0" + seconds : seconds.ToString();
                output.text = $"{m}:{s}";
            }
        }
    }
}
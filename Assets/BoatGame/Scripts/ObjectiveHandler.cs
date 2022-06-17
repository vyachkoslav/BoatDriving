using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoatGame
{
    public class ObjectiveHandler : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI output;
        [SerializeField] List<Objective> objectivesToComplete;
        [SerializeField] List<Objective> rules;

        void Start()
        {
            foreach (Objective objective in objectivesToComplete)
            {
                objective.OnDone += () =>
                {
                    objectivesToComplete.Remove(objective);
                    UpdateText();
                };
                objective.OnFailed += Lose;

                objective.Start();
            }
            foreach (Objective objective in rules)
            {
                objective.OnFailed += Lose;
                objective.Start();
            }

            UpdateText();
        }

        void Win()
        {
            print("Win!");
        }
        void Lose()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        bool CheckWin()
        {
            foreach (Objective objective in objectivesToComplete)
            {
                if (!objective.IsDone())
                {
                    return false;
                }
            }
            return true;
        }
        void UpdateText()
        {
            if (output)
            {
                output.text = String.Empty;
                foreach (Objective objective in objectivesToComplete)
                {
                    output.text += objective.Description + "\n";
                }
                foreach (Objective rule in rules)
                {
                    output.text += rule.Description + "\n";
                }
            }
        }
    }
}
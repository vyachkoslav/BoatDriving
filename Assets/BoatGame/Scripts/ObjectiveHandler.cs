using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoatGame
{
    [RequireComponent(typeof(GameState))]
    public class ObjectiveHandler : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI output;
        [SerializeField] List<Objective> objectivesToComplete;
        [SerializeField] List<Objective> rules;

        void Start()
        {
            ResetObjectives();
            foreach (Objective objective in objectivesToComplete)
            {
                objective.OnDone += () =>
                {
                    objectivesToComplete.Remove(objective);
                    UpdateText();
                    if (CheckWin())
                        Win();
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
            GetComponent<GameState>().WinState();
        }
        void Lose()
        {
            GetComponent<GameState>().LoseState();
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
        void ResetObjectives()
        {
            for (int i = 0; i < objectivesToComplete.Count; ++i)
            {
                objectivesToComplete[i] = Instantiate(objectivesToComplete[i]);
            }
            for (int i = 0; i < rules.Count; ++i)
            {
                rules[i] = Instantiate(rules[i]);
            }
        }
    }
}
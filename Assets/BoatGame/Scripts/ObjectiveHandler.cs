using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoatGame
{
    public class ObjectiveHandler : MonoBehaviour
    {
        [SerializeField] List<Objective> objectivesToComplete;
        [SerializeField] List<Objective> rules;
        List<bool> doneObjectives;

        void Start()
        {
            doneObjectives = new List<bool>(objectivesToComplete.Count);
            foreach (Objective objective in objectivesToComplete)
            {
                objective.OnDone += () =>
                {
                    int i = objectivesToComplete.IndexOf(objective);
                    doneObjectives[i] = true;
                };
                objective.OnFailed += Lose;

                objective.Start();
            }
            foreach (Objective objective in rules)
            {
                objective.OnFailed += Lose;
                objective.Start();
            }
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
    }
}
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

        void Start()
        {
            foreach (Objective objective in objectivesToComplete)
            {
                objective.Start();
            }
            foreach (Objective objective in rules)
            {
                objective.Start();
            }
        }
        void Update()
        {
            foreach (Objective objective in rules)
            {
                if (objective.IsFailed())
                {
                    Lose();
                    break;
                }
            }

            bool somethingNotDone = false;
            foreach (Objective objective in objectivesToComplete)
            {
                if (objective.IsFailed())
                {
                    somethingNotDone = true;
                    Lose();
                    break;
                }
                if (!objective.IsDone())
                {
                    somethingNotDone = true;
                }
            }
            if (!somethingNotDone)
            {
                Win();
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
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Game
{
    public class LevelController : MonoBehaviour
    {
        private Monster[] _monsters;

        [SerializeField] private string _nextLevelName;


        private void OnEnable()
        {
            _monsters = FindObjectsOfType<Monster>();
        }

        // Update is called once per frame
        void Update()
        {
            if (MonstersAreAllDead())
            {
                GoToNextLevel();
            }
        }

        private bool MonstersAreAllDead()
        {
            foreach (var monster in _monsters)
            {
                if (monster.gameObject.activeSelf)
                {
                    return false;
                }
            }

            return true;
        }

        private void GoToNextLevel()
        {
            Debug.Log("Go to level " + _nextLevelName);
            SceneManager.LoadScene(_nextLevelName);
        }
    }
}

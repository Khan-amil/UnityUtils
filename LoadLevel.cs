using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class LoadLevel : MonoBehaviour
    {
        public string _levelToLoad;
        public float _delay;
        public LoadSceneMode _loadMode;
        
        // Use this for initialization
        IEnumerator Start()
        {
            if(_delay>0.01f)
            yield return new WaitForSeconds(_delay);
            SceneManager.LoadScene(_levelToLoad,_loadMode);
        }

    }
}

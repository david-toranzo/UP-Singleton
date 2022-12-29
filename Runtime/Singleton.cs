using UnityEngine;

namespace Patterns.Singleton
{
    public abstract class Singleton<TypeSingleton> : MonoBehaviour where TypeSingleton : MonoBehaviour
    {
        protected static TypeSingleton _instance;

        public static TypeSingleton Instance
        {
            get
            {
                if (null == _instance)
                    throw new System.Exception("There isn't a instance of :" + typeof(TypeSingleton) +" in the scene");

                return _instance;
            }
        }

        protected void Awake()
        {
            InitializeSingleton();
            AwakeAfterInitializeSingleton();
        }

        protected void InitializeSingleton()
        {
            if (null == _instance)
                _instance = gameObject.GetComponent<TypeSingleton>();
            else if (_instance != this)
                Destroy(gameObject);
        }

        protected abstract void AwakeAfterInitializeSingleton();

        protected void DontDestroyWhenLoadScene()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
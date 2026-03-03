using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment
{
    public sealed class CoroutinesPerformer : MonoBehaviour, ICoroutinesPerformer
    {
        private void Awake() => DontDestroyOnLoad(this);

        public Coroutine StartPerform(IEnumerator coroutineFunc) => StartCoroutine(coroutineFunc);

        public void StopPerform(Coroutine coroutine) => StopCoroutine(coroutine);
    }
}
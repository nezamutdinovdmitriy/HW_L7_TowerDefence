using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.CoroutinesManagment
{
    public interface ICoroutinesPerformer
    {
        public Coroutine StartPerform(IEnumerator coroutineFunc);
        public void StopPerform(Coroutine coroutine);
    }
}
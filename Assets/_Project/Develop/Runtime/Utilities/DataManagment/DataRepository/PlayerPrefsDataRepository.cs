using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagment.DataRepository
{
    public sealed class PlayerPrefsDataRepository : IDataRepository
    {
        public IEnumerator ExistsAsync(string key, Action<bool> onExistsResult)
        {
            bool exists = PlayerPrefs.HasKey(key);

            onExistsResult?.Invoke(exists);

            yield break;
        }

        public IEnumerator ReadAsync(string key, Action<string> onRead)
        {
            string text = PlayerPrefs.GetString(key);

            onRead?.Invoke(text);

            yield break;
        }

        public IEnumerator RemoveAsync(string key)
        {
            PlayerPrefs.DeleteKey(key);

            yield break;
        }

        public IEnumerator WriteAsync(string key, string serializedData)
        {
            PlayerPrefs.SetString(key, serializedData);

            yield break;
        }
    }
}

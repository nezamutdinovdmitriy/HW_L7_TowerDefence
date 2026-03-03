using System;
using System.Collections;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagment.DataRepository
{
    public interface IDataRepository
    {
        public IEnumerator ReadAsync(string key, Action<string> onRead);
        public IEnumerator WriteAsync(string key, string serializedData);
        public IEnumerator RemoveAsync(string key);
        public IEnumerator ExistsAsync(string key, Action<bool> onExistsResult);
    }
}

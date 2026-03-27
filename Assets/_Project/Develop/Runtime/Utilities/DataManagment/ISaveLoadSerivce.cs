using System;
using System.Collections;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagment
{
    public interface ISaveLoadSerivce
    {
        public IEnumerator LoadAsync<TData>(Action<TData> onLoad) where TData : ISaveData;
        public IEnumerator SaveAsync<TData>(TData data) where TData : ISaveData;
        public IEnumerator RemoveAsync<TData>() where TData : ISaveData;
        public IEnumerator ExistsAsync<TData>(Action<bool> onExistsResult) where TData : ISaveData;
    }
}

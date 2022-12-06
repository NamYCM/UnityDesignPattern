using SaveSystem;
using UnityEngine;

namespace TestSaveSystem
{
    public class SampleData : IDataModel
    {
        public string Message;
    }

    public class SampleSavableObject : BaseSavableObject<SampleData, NormalParser>
    {
        public SampleData Model => _model;
        
        protected override void OnDataLoaded()
        {
            Debug.Log($"Data model loaded {_model.Message}");
        }

        public void SetSampleData (string message)
        {
            _model.Message = message;
        }
    }

    public class SampleSavableAndResetObject : SampleSavableObject, IResetable
    {
        public bool IsDeleteFile => true;

        public void Reset()
        {
            _model.Message = "";
        }
    }
}

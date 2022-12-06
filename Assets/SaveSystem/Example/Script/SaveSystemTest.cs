using UnityEngine;

namespace TestSaveSystem
{
    public class SaveSystemTest : MonoBehaviour
    {
        [SerializeField] private string _setData = "Sample data";

        private SaveSystem.ISaveSystem _saveSystem;


        // Start is called before the first frame update
        void Start()
        {
            _saveSystem = new SaveSystem.SaveSystem();
        }

        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                GetData();
            }   
            if (Input.GetKeyDown(KeyCode.S))
            {
                SetData();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetData();
            }
        }

        private void GetData()
        {
            if (_saveSystem == null) return;

            var savableObject = _saveSystem.Get<SampleSavableAndResetObject>();

            if (savableObject == null)
            {
                Debug.Log("Doesn't have data in database");
            }
            else
            {
                Debug.Log("Data saved " + savableObject.Model.Message);
            }
        }

        private void SetData()
        {
            if (_saveSystem == null) return;

            var savableObject = _saveSystem.Get<SampleSavableAndResetObject>();

            if (savableObject == null)
            {
                savableObject = new SampleSavableAndResetObject();
                _saveSystem.Add<SampleSavableAndResetObject>(savableObject);
            }

            savableObject.SetSampleData(_setData);

            _saveSystem.Save<SampleSavableAndResetObject>();

            Debug.Log("Save successful, saved data: " + savableObject.Model.Message);
        }

        private void ResetData()
        {
            if (_saveSystem == null) return;

            var resetableObject = _saveSystem.Get<SampleSavableAndResetObject>();

            if (resetableObject == null)
            {
                Debug.Log("Doesn't have data in database to reset");
                return;
            }
            
            _saveSystem.Reset(() => Debug.Log("End reset"), typeof(SampleSavableAndResetObject));

            Debug.Log("Reset successfull, reseted data: " + resetableObject.Model.Message);
        }
    }
}

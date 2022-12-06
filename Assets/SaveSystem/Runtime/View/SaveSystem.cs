using System;
using System.Collections.Generic;
using System.Data;
using SaveSystem.FileHandler;

namespace SaveSystem
{
    public class SaveSystem : ISaveSystem
    {
        private Dictionary<Type, ISavable> _saveObjects = new();
        private IFileHandler _fileHandler = new FileHandler.FileHandler();

        public void Add<T>(T savable) where T : ISavable
        {
            var type = typeof(T);

            if (savable == null)
                throw new ArgumentNullException(
                    $"[Save System] - Can't add null to save type {type.FullName}");
            
            if (_saveObjects.ContainsKey(type) || Get<T>() != null)
            {
                throw new DuplicateNameException(
                    $"[Save System] - Save object with type {type.FullName} already exist!!!");
            }
            
            _saveObjects[type] = savable;
        }

        public void Save<T>() where T : ISavable
        {
            var type = typeof(T);

            if (_saveObjects.ContainsKey(type))
            {
                var data = _saveObjects[type].GetSaveData();

                if (data != null)
                    _fileHandler.SaveFile(type.FullName, data);
                else
                    throw new NullReferenceException("[Save System] - Data saved is null");
                return;
            }

            throw new KeyNotFoundException($"[Save System] - Save object with type {type.FullName} didn't exist");
        }

        public T Get<T>() where T : ISavable
        {
            var type = typeof(T);

            if (_saveObjects.ContainsKey(type))
            {
                return (T)_saveObjects[type];
            }

            var data = _fileHandler.LoadFile(type.FullName);
            
            if (data != null)
            {
                var savableObject = (T)Activator.CreateInstance(type);
                savableObject?.Load(data);

                if (savableObject != null) _saveObjects[type] = savableObject;
                
                return savableObject;
            }

            return default;
        }

        public void Reset(Action OnEndReset, params Type[] types)
        {
            foreach (var type in types)
            {
                if (!_saveObjects.ContainsKey(type))
                    throw new KeyNotFoundException($"[Save System] - Save object with type {type.FullName} didn't exist");
                
                if (!typeof(IResetable).IsAssignableFrom(type))
                    throw new InvalidCastException($"[Save System] - Save object with type {type.FullName} isn't a IResetable");
                
                var resetableObject = (IResetable)_saveObjects[type];
                resetableObject.Reset();

                if (resetableObject.IsDeleteFile)
                {
                    _fileHandler.DeleteFile(type.FullName);
                }
                
            }

            OnEndReset?.Invoke();
        }

        public void Reset<T>(Action OnEndReset) where T : IResetable
        {
            var type = typeof(T);

            if (_saveObjects.ContainsKey(type))
            {
                var resetableObject = (IResetable)_saveObjects[type];
                resetableObject.Reset();

                if (resetableObject.IsDeleteFile)
                {
                    _fileHandler.DeleteFile(type.FullName);
                }

                OnEndReset?.Invoke();
                return;
            }

            throw new KeyNotFoundException($"[Save System] - Save object with type {type.FullName} didn't exist");
        }
    }
}
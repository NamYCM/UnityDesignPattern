using System;
using SaveSystem.Parser;
using UnityEngine;

namespace SaveSystem
{
    public abstract class BaseSavableObject<Model, Parser> : ISavable 
        where Model : IDataModel 
        where Parser : IParser
    {
        protected Model _model;
        protected Parser _parser;

        protected BaseSavableObject ()
        {
            _model = (Model)Activator.CreateInstance(typeof(Model));
            _parser = (Parser)Activator.CreateInstance(typeof(Parser));
        }

        public string GetSaveData()
        {
            string dataSaved = _model == null ? null : JsonUtility.ToJson(_model);

            if (dataSaved != null && _parser != null)
            {
                dataSaved = _parser.Encode(dataSaved);
            }

            return dataSaved;
        }

        public void Load(string data)
        {
            if (_parser != null)
            {
                data = _parser.Decode(data);
            }

            JsonUtility.FromJsonOverwrite(data, _model);

            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();
    }
}
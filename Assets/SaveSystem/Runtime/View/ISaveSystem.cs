using System;

namespace SaveSystem
{
    public interface ISaveSystem
    {
        /// <summary>
        /// Save data with type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Save<T>() where T : ISavable;

        /// <summary>
        /// Add savable object by type
        /// </summary>
        /// <param name="savable"></param>
        /// <typeparam name="T"></typeparam>
        void Add<T>(T savable) where T : ISavable;
        
        /// <summary>
        /// Get savable object by type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>() where T : ISavable;
        
        /// <summary>
        /// Reset resetable objects array
        /// </summary>
        /// <param name="OnEndReset"></param>
        /// <param name="types"></param>
        void Reset(Action OnEndReset, params Type[] types);
        
        /// <summary>
        /// Reset resetable object
        /// </summary>
        /// <param name="OnEndReset"></param>
        /// <param name="types"></param>
        void Reset<T>(Action OnEndReset) where T : IResetable;
    }
}
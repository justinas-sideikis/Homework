using System;

namespace Homework.Exceptions
{
    [Serializable]
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException() : base("Entity not found in database")
        {
        }
    }
}

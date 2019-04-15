using System;
using System.Runtime.Serialization;

namespace Generics
{
    [System.Serializable]
    public class DuplicateTreeInfoException : Exception
    {
        public DuplicateTreeInfoException() { }
        public DuplicateTreeInfoException(string message) : base(message) { }
        public DuplicateTreeInfoException(string message, Exception inner) : base(message, inner) { }
        protected DuplicateTreeInfoException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
using System;
namespace Generics
{
[System.Serializable]
public class InformationNotFoundException : Exception
{
    public InformationNotFoundException() { }
    public InformationNotFoundException(string message) : base(message) { }
    public InformationNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    protected InformationNotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
}
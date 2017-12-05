using System.Collections.Generic;
using System.IO;

namespace JustOneProject.VariousStuff
{
    // MemoryStream derives from Stream
    // class MemoryStream : Stream

    internal interface IYokeBase<out TElement>
        where TElement : Stream
    {
        IEnumerable<TElement> Elements { get; }
    }

    class YokeBase<TElement> : IYokeBase<TElement>
        where TElement : Stream
    {
        public IEnumerable<TElement> Elements { get; }
    }

    class Yoke : YokeBase<MemoryStream>
    {
    }

    internal interface ITransformatorBase<out TYoke>
        where TYoke : IYokeBase<Stream>
    {
        IEnumerable<TYoke> Yokes { get; }
    }

    class TransformatorBase<TYoke> : ITransformatorBase<TYoke>
        where TYoke : IYokeBase<Stream>
    {
        public IEnumerable<TYoke> Yokes { get; }
    }

    class Transformator : TransformatorBase<Yoke>
    {

    }
}
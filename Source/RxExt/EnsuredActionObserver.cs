namespace RxExt
{
    using System;

    /// <summary>
    /// Wrapper for the <see cref="RxExtensions.EnsureAction"/> extension result.
    /// </summary>
    public class EnsuredActionObserver<T> : IObserver<T>
    {
        private bool _empty = true;
        private readonly Action _action;

        public EnsuredActionObserver(Action action) { _action = action; }

        public void OnCompleted()
        {
            if (_empty)
                _action();
        }

        public void OnError(Exception error) { _action(); }

        public void OnNext(T value)
        {
            _empty = false;
            _action();
        }
    }
}
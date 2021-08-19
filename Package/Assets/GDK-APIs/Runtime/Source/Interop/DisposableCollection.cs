using System;
using System.Collections.Generic;

namespace XGamingRuntime.Interop
{
    public class DisposableCollection : IDisposable
    {
        public DisposableCollection()
        {
            this.disposables = new List<IDisposable>();
        }

        public void Dispose()
        {
            this.Dispose(isDisposing: true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            foreach (DisposableBuffer disposable in disposables)
            {
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        ~DisposableCollection()
        {
            this.Dispose(isDisposing: false);
        }

        public T Add<T>(T disposable) where T : IDisposable
        {
            this.disposables.Add(disposable);
            return disposable;
        }

        private readonly List<IDisposable> disposables;
    }
}

using Lab.CoolPlayer.Core.Domain;
using Lab.CoolPlayer.Core.View;
using Lab.CoolPlayer.Core.Adapter;
using System.Collections.Generic;
using System;

namespace Lab.CoolPlayer.Core.Factory
{
    public class CoolPlayerFactory
    {        
        private readonly List<IDisposable> disposables = new List<IDisposable>();

        public CoolPlayerFactory()
        {
        }

        public CoolPlayerDomain Create(ICoolPlayerPresenter presenter)
        {
            var domain = new CoolPlayerDomain();
            disposables.Add(domain);
            var view = new CoolPlayerView(domain, presenter);
            disposables.Add(view);
            return domain;
        }

        public void Clear()
        {
            foreach (var disposable in disposables)
            {
                disposable.Dispose();
            }
        }
    }
}

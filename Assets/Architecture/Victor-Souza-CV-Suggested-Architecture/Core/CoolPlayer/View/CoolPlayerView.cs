using System;
using Lab.CoolPlayer.Core.Adapter;
using Lab.CoolPlayer.Core.Domain;

namespace Lab.CoolPlayer.Core.View 
{
    public class CoolPlayerView : IDisposable
    {
        private readonly CoolPlayerDomain domain;
        private readonly ICoolPlayerPresenter presenter;
        
        public CoolPlayerView(CoolPlayerDomain domain, ICoolPlayerPresenter presenter)
        {
            this.domain = domain;
            this.presenter = presenter;
        }

        public void Dispose()
        {
            //Unsubscribe from events
        }
    }
}

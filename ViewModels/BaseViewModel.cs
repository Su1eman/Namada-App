using Namada_Maui.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.ViewModels
{
    public class BaseViewModel
    {
        #region Uri

        private readonly Uri uri = new Uri(string.Format("https://namadexer.palamar.io/block/last", string.Empty));
        private readonly Uri overviewUri = new Uri(string.Format("https://namadexer.palamar.io/block/last", string.Empty));
        private readonly Uri validatorsUri = new Uri(string.Format("https://namada-rpc.palamar.io/dump_consensus_state", string.Empty));
        private readonly Uri blocksUri = new Uri(string.Format("https://namadexer.palamar.io/block/height/46499", string.Empty));

        #endregion

        #region Settings

        private AppConfig appConfig = new AppConfig();

        #endregion

        public BaseViewModel()
        {

        }

        #region Settings

        public AppConfig AppConfig
        {
            get { return appConfig; }
            set { appConfig = value; }
        }

        #endregion
    }
}
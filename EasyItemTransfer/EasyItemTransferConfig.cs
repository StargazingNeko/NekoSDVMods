using Microsoft.Xna.Framework.Input;

namespace EasyItemTransfer
{
    public class EasyItemTransferConfig
    {
        public Keys TransferKey { get; set; }
        public Keys TransferAllKey { get; set; }

        public EasyItemTransferConfig()
        {
            this.TransferKey = Keys.LeftShift;
            this.TransferAllKey = Keys.Space;
        }
    }
}
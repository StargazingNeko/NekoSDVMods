using Microsoft.Xna.Framework.Input;

namespace EasyItemTransfer
{
    public class EasyItemTransferConfig
    {
        public Keys transferKey { get; set; }
        public Keys transferAllKey { get; set; }

        public EasyItemTransferConfig()
        {
            this.transferKey = Keys.LeftShift;
            this.transferAllKey = Keys.Space;
        }
    }
}
using System;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace MyFirstPlugin
{
    [ApiVersion(2, 1)]
    public class Plugin : TerrariaPlugin
    {
        public override string Author => "千亦";

        public override string Description => "杀死那些使用望远镜刷物品的家伙";

        public override string Name => "TalkToNPCWithBinocularsToDie";

        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public Plugin(Main game) : base(game)
        {
        }

        public override void Initialize()
        {
            ServerApi.Hooks.NetGetData.Register(this, a);
        }

        private void a(GetDataEventArgs args)
        {
            if (args.MsgID == PacketTypes.NpcTalk)
            {
                for (var i = 0; i <= 49; i++)
                {
                    var inventoryItemId = TShock.Players[args.Msg.whoAmI].TPlayer.inventory[i].netID;
                    if (inventoryItemId == 1299 | inventoryItemId == 1858 | inventoryItemId == 1300 | inventoryItemId == 4005 | inventoryItemId == 1254)
                    {
                        TSPlayer.All.SendInfoMessage($"玩家{TShock.Players[args.Msg.whoAmI].Name}试图刷物品");
                        TShock.Players[args.Msg.whoAmI].KillPlayer();
                        args.Handled = true;
                    }
                }
                var trashItemId = TShock.Players[args.Msg.whoAmI].TPlayer.trashItem.netID;
                if (trashItemId == 1299 | trashItemId == 1858 | trashItemId == 1300 | trashItemId == 4005 | trashItemId == 1254)
                {
                    TSPlayer.All.SendInfoMessage($"玩家{TShock.Players[args.Msg.whoAmI].Name}试图刷物品");
                    TShock.Players[args.Msg.whoAmI].KillPlayer();
                    args.Handled = true;
                }
                for (var j = 3; j <= 8; j++)
                {
                    var inventoryItemId = TShock.Players[args.Msg.whoAmI].TPlayer.armor[j].netID;
                    if (inventoryItemId == 1299 | inventoryItemId == 1858 | inventoryItemId == 1300 | inventoryItemId == 4005 | inventoryItemId == 1254)
                    {
                        TSPlayer.All.SendInfoMessage($"玩家{TShock.Players[args.Msg.whoAmI].Name}试图刷物品");
                        TShock.Players[args.Msg.whoAmI].KillPlayer();
                        args.Handled = true;
                    }
                }
            }
        }
    }
}
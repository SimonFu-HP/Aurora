using System;
using Aurora.Profiles;

namespace Aurora.Profiles.Fortnite{

    public class GameState_Fortnite : GameState{

        private ProviderNode provider;
        public ProviderNode Provider => provider ?? (provider = new ProviderNode(_ParsedData["provider"]?.ToString() ?? ""));

        private GameNode game;
        public GameNode Game => game ?? (game = new GameNode(_ParsedData["game"]?.ToString() ?? ""));

        public GameState_Fortnite() : base() { }
        public GameState_Fortnite(string JSONstring) : base(JSONstring) { }
    }

    public class ProviderNode : AutoJsonNode<ProviderNode>
    {

        public string Name;
        public int AppID;

        internal ProviderNode(string json) : base(json) {
            Name = GetString("name");
            AppID = GetInt("appid");
        }
    }

    public class GameNode : AutoJsonNode<GameNode> {

        public string Status;

        internal GameNode(string json) : base(json) {
            Status = GetString("status");
        }
    }
}

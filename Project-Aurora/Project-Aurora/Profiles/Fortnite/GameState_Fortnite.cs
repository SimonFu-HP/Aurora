using System;
using Aurora.Profiles;

namespace Aurora.Profiles.Fortnite{

    public class GameState_Fortnite : GameState<GameState_Fortnite> {

        private ProviderNode provider;
        public ProviderNode Provider => provider ?? (provider = new ProviderNode(_ParsedData["provider"]?.ToString() ?? ""));

        private GameNode game;
        public GameNode Game => game ?? (game = new GameNode(_ParsedData["game"]?.ToString() ?? ""));

        public GameState_Fortnite() : base() { }
        public GameState_Fortnite(string JSONstring) : base(JSONstring) { }
        public GameState_Fortnite(IGameState other) : base(other) { }
    }

    public class ProviderNode : Node<ProviderNode> {

        public string Name;
        public int AppID;

        internal ProviderNode(string json) : base(json) {
            Name = GetString("name");
            AppID = GetInt("appid");
        }
    }

    public class GameNode : Node<GameNode> {

        public string Status;

        internal GameNode(string json) : base(json) {
            Status = GetString("status");
        }
    }
}

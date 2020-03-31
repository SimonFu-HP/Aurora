namespace Aurora.Profiles.Postman{

    public class GameState_Postman : GameState<GameState_Postman> {

        private ProviderNode provider;
        public ProviderNode Provider => provider ?? (provider = new ProviderNode(_ParsedData["provider"]?.ToString() ?? ""));

        private GameNode game;
        public GameNode Game => game ?? (game = new GameNode(_ParsedData["game"]?.ToString() ?? ""));

        public GameState_Postman() : base() { }
        public GameState_Postman(string JSONstring) : base(JSONstring) { }
        public GameState_Postman(IGameState other) : base(other) { }
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
        //public float HP;
        //public float Accuracy;
        //public int Combo;
        //public int Count50;
        public int Scene1;
        //public int Count200;
        public int Scene2;
        public int Scene3;
        public int Scene4;
        //public int CountKatu;
        //public int CountGeki;
        //public int CountMiss;

        internal GameNode(string json) : base(json) {
            Status = GetString("status");
            //HP = GetFloat("hp");
            //Accuracy = GetFloat("accuracy");
            //Combo = GetInt("combo");
            //Count50 = GetInt("count50");
            Scene1 = GetInt("scene1");
            //Count200 = GetInt("count200");
            Scene2 = GetInt("scene2");
            Scene3 = GetInt("scene3");
            Scene4 = GetInt("scene4");
            //CountKatu = GetInt("countKatu");
            //CountGeki = GetInt("countGeki");
            //CountMiss = GetInt("countMiss");
        }
    }
}

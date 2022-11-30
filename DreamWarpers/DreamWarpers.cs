using Modding;
using System;
using SFCore.Utils;

namespace DreamWarpers
{
    public class DreamWarpersMod : Mod
    {
        private static DreamWarpersMod? _instance;

        internal static DreamWarpersMod Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException($"An instance of {nameof(DreamWarpersMod)} was never constructed");
                }
                return _instance;
            }
        }

        public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();

        public DreamWarpersMod() : base("DreamWarpers")
        {
            _instance = this;
        }

        public override void Initialize()
        {
            Log("Initializing");

            On.PlayMakerFSM.OnEnable += OnFSMEnable;

            Log("Initialized");
        }
        private void OnFSMEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);

            if (self.gameObject.name == "Ghost Warrior Slug" && self.FsmName == "Movement")
            {
                self.ChangeFsmTransition("Hover", "TOOK DAMAGE", "Set Warp");
            }
            else if (self.gameObject.name == "Ghost Warrior No Eyes" && self.FsmName == "Damage Response")
            {
                self.ChangeFsmTransition("Idle", "TOOK DAMAGE", "Send");
            }
            else if (self.gameObject.name == "Ghost Warrior Hu" && self.FsmName == "Movement")
            {
                self.ChangeFsmTransition("Hover", "TOOK DAMAGE", "Set Warp");
            }
        }
    }
}

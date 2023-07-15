namespace oldCode
{
	public class StartAction : IAction
	{
		public PlayerController PlayerController { get; set; }
		public ActionType Type { get; set; }
		public int Start { get; set; }
		public int End { get; set; }

		public StartAction() { }

		public IAction Initialize(PlayerController playerController, ActionType type, int start)
		{
			PlayerController = playerController;
			Type = type;
			Start = start;
			return this;
		}

		public bool Execute(int currentFixedFrame)
		{
			return true;
		}
	}
}

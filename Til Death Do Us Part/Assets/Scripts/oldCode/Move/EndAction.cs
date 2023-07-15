namespace oldCode
{
	public class EndAction : IAction
	{
		public PlayerController PlayerController { get; set; }
		public ActionType Type { get; set; }
		public int Start { get; set; }
		public int End { get; set; }

		public EndAction() { }

		public IAction Initialize(PlayerController playerController, ActionType type, int start)
		{
			PlayerController = playerController;
			Type = type;
			Start = start;
			return this;
		}

		public bool Execute(int currentFixedFrame)
		{
			//PlayerController
			return true;
		}
	}
}

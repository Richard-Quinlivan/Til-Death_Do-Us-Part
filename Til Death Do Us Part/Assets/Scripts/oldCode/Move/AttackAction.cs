namespace oldCode
{
	public class AttackAction : IAction
	{
		public PlayerController PlayerController { get; set; }
		public ActionType Type { get; set; }
		public int Start { get; set; }
		public int End { get; set; }

		public AttackAction() { }

		public IAction Initialize(PlayerController playerController, ActionType type, int start)
		{
			PlayerController = playerController;
			Type = type;
			Start = start;
			End = start;
			return this;
		}

		public bool Execute(int currentFixedFrame)
		{
			if (currentFixedFrame < Start) return false;
			if (currentFixedFrame > End) return true;

			PlayerController.AttackHelper();
			return false;
		}
	}

}

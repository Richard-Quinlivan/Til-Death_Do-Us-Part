namespace oldCode
{
	using UnityEngine;

	public class RunAction : IAction
	{
		public PlayerController PlayerController { get; set; }
		public ActionType Type { get; set; }
		public int Start { get; set; }
		public int End { get; set; }
		public Vector2 MoveDirection { get; set; }

		public RunAction(Vector2 moveDirection)
		{
			MoveDirection = moveDirection;
		}

		public IAction Initialize(PlayerController playerController, ActionType type, int start)
		{
			PlayerController = playerController;
			Type = type;
			Start = start;
			return this;
		}

		public bool Execute(int currentFixedFrame)
		{
			if (currentFixedFrame < Start) return false;
			if (currentFixedFrame >= End) return true;

			PlayerController.RunHelper(MoveDirection);
			return false;
		}
	}
}


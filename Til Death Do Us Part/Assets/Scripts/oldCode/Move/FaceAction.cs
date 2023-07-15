namespace oldCode
{
	using UnityEngine;

	public class FaceAction : IAction
	{
		public PlayerController PlayerController { get; set; }
		public ActionType Type { get; set; }
		public int Start { get; set; }
		public int End { get; set; }
		public Vector2 FaceDirection { get; set; }

		public FaceAction(Vector2 faceDirection)
		{
			FaceDirection = faceDirection;
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
			if (currentFixedFrame > End) return true;

			//PlayerController.FaceHelper(FaceDirection);
			return false;
		}
	}
}

namespace oldCode
{
	public interface IAction
	{
		PlayerController PlayerController { get; set; }
		ActionType Type { get; set; }
		int Start { get; set; }
		int End { get; set; }

		IAction Initialize(PlayerController playerController, ActionType type, int start);
		bool Execute(int currentFixedFrame);

	}

	public enum ActionType
	{
		Start = 0,
		Run,
		Face,
		Attack,
		End
	}
}
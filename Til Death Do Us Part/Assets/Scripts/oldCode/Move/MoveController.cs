namespace oldCode
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.InputSystem;

	public class MoveController : MonoBehaviour
	{
		[SerializeField]
		private float moveSpeed = 0;

		private InputManager _controls;
		private PlayerController _playerController;

		private List<IAction> _moves;
		private int _firstMoveIndex = 0;
		[SerializeField]
		private bool _isPlayingMove = false;

		private int _fixedFrameCounter = 0;

		private void Awake()
		{
			_controls = new InputManager();
			_moves = new List<IAction>();
			_playerController = GetComponent<PlayerController>();
		}

		private void OnEnable()
		{
			//_controls.Player.Play.performed += OnPlay;
		}
		private void OnDisable()
		{
			ListenOff();
			//_controls.Player.Play.performed -= OnPlay;
		}
		public void ListenOn()
		{
			_controls.Enable();
			_controls.Player.Run.performed += OnRun;
			_controls.Player.Attack.performed += OnAttack;
			_controls.Player.Face.performed += OnFace;
			//_controls.Player.End.performed += OnEnd;
		}
		public void ListenOff()
		{
			_controls.Disable();
			_controls.Player.Run.performed -= OnRun;
			_controls.Player.Attack.performed -= OnAttack;
			_controls.Player.Face.performed -= OnFace;
			//_controls.Player.End.performed -= OnEnd;
		}
		public void OnStart(InputAction.CallbackContext context)
		{
			print("start");
			_moves.Clear();
			_moves.Add(new StartAction().Initialize(_playerController, ActionType.Start, 0));
			_fixedFrameCounter = 0;
		}
		private void OnRun(InputAction.CallbackContext context)
		{
			SetPreviousEndTime(ActionType.Run);
			_moves.Add(new RunAction(context.ReadValue<Vector2>()).Initialize(_playerController, ActionType.Run, _fixedFrameCounter));
		}
		private void OnFace(InputAction.CallbackContext context)
		{
			SetPreviousEndTime(ActionType.Face);
			_moves.Add(new FaceAction(context.ReadValue<Vector2>()).Initialize(_playerController, ActionType.Face, _fixedFrameCounter));
		}
		private void OnAttack(InputAction.CallbackContext context)
		{
			SetPreviousEndTime(ActionType.Attack);
			_moves.Add(new AttackAction().Initialize(_playerController, ActionType.Attack, _fixedFrameCounter));
		}
		private void OnEnd(InputAction.CallbackContext context)
		{
			//End any outstanding Actions that do not have an end time
			SetPreviousEndTime(ActionType.Run);
			SetPreviousEndTime(ActionType.Face);

			print("end");
			_moves.Add(new EndAction().Initialize(_playerController, ActionType.End, _fixedFrameCounter));
			//foreach (Move m in moves)
			//{
			//	print(m);
			//}
		}
		public void OnPlay(InputAction.CallbackContext context)
		{
			print("play");
			_isPlayingMove = true;
			_firstMoveIndex = 0;
			_fixedFrameCounter = 0;
		}
		/// <summary>
		/// Sets the End value for the most recent Iaction of the with the ActionType type
		/// </summary>
		/// <param name="type">the type of the action that needs it's End parameter set</param>
		private void SetPreviousEndTime(ActionType type)
		{
			for (int i = _moves.Count - 1; i > 0; i--) //don't need to check 0 since it is always the start move
			{
				if (_moves[i].Type == type)
				{
					_moves[i].End = _fixedFrameCounter;
				}
			}
		}

		private void FixedUpdate()
		{
			if (_isPlayingMove)
			{
				print("curret move = " + _moves[_firstMoveIndex]);
				print("Next move = " + _moves[_firstMoveIndex + 1]);

				bool moveOver = _moves[_firstMoveIndex].Execute(_fixedFrameCounter);

				if (moveOver) GoToNextMove();
				for (int i = _firstMoveIndex; i < _moves.Count - 1; i++) //-1 since end does not count
				{
					_moves[i].Execute(_fixedFrameCounter);
				}
			}
			++_fixedFrameCounter;
		}

		private void GoToNextMove()
		{
			_firstMoveIndex++;
			if (_firstMoveIndex == _moves.Count - 1)//-1 becaues the start move doesn't count
			{
				_isPlayingMove = false;
			}
		}
	}
}


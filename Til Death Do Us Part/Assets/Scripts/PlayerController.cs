using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour 
{
	private Animator _anim;
	private Rigidbody2D _rb;
	private TakeDamage _takeDamage;

	public float speed = 2f;

	private Vector2 facingDirection;
	private Vector2 lastFacingDirection;
	private bool attack = false;
	private bool face = false;
	private bool dash = false;
	private float pressShift = 0f;

	private InputManager _controls;

	public bool Attack { get; set; }
	public bool Face { get; set; }
	public bool Dash { get; set; }

	private void Awake() 
	{
		_controls = new InputManager();
		_anim = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody2D>();
		_takeDamage = GetComponent<TakeDamage>();

}
private void OnEnable() 
	{
		_controls.Enable();
		_controls.Player.Run.performed += OnRun;
		_controls.Player.Attack.performed += OnAttack;
	}
	private void OnDisable()
	{
		_controls.Disable();
		_controls.Player.Run.performed -= OnRun;
		_controls.Player.Attack.performed -= OnAttack;
	}
	private void OnRun(InputAction.CallbackContext context)
	{
		RunHelper(context.ReadValue<Vector2>());
	}
	public void RunHelper(Vector2 direction) 
	{
		_rb.velocity = direction * speed;
	}
	private void OnAttack(InputAction.CallbackContext context) 
	{
		AttackHelper();
	}
	public void AttackHelper() 
	{
		attack = true;
	}
	
	private void Update() 
	{
		// for going between idle and walking animations
		_anim.SetFloat("Speed", _rb.velocity.sqrMagnitude); 

		// for perfoming/stopping attacks
		_anim.SetBool("Attack", attack);
		attack = false;

		//for performing/stopping dash
		_anim.SetBool("Dash", dash);
	}
}

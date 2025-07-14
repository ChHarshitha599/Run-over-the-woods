using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class womenRunningMovements : MonoBehaviour
{
    [System.Serializable]
    public class MovementSettings
    {
        public float forwardVelocity = 10;
        public float jumpVelocity = 10;
        public float distanceTravelled = 0; // Track distance traveled
    }

    [System.Serializable]
    public class PhysicsSettings
    {
        public float downAccel = 0.50f;
    }

    public MovementSettings movementSettings = new MovementSettings();
    public PhysicsSettings physicsSettings = new PhysicsSettings();
    public Vector3 _velocity;
    public float xSpeed = 10;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private int _jumpInput = 0, _slideInput = 0;
    private bool _onGround = false;
    private float _xMovement = 0;
    public CapsuleCollider playerCollider;
    public float rayDistance = 1.0f;
    public bool isOut = false;

    private Queue<System.Action> inputBuffer = new Queue<System.Action>();

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        InputHandling();
    }

    // FixedUpdate is called once per fixed frame-rate frame
    void FixedUpdate()
    {
        if (isOut)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            return;
        }

        while (inputBuffer.Count > 0)
        {
            inputBuffer.Dequeue().Invoke();
        }

        Run();
        CheckGround();
        Jump();
        MoveX();
        Slide();
        UpdateDistanceTraveled();
        UpdateForwardVelocity();

        _rigidbody.velocity = _velocity;
    }

    void Run()
    {
        _velocity.z = movementSettings.forwardVelocity;
    }

    void Slide()
    {
        if (_slideInput == 1 && _animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            _animator.SetTrigger("slide");
            _slideInput = 0;
            // Disable the collider during the slide
            playerCollider.enabled = false;
            Invoke(nameof(ResetCollider), 1);
        }
    }

    void Jump()
    {
        if (_jumpInput == 1 && _animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            _velocity.y = movementSettings.jumpVelocity;
            _animator.SetTrigger("jump");
            // Disable the collider during the jump
            playerCollider.enabled = false;
            Invoke(nameof(ResetCollider), 1);
        }
        else if (_onGround)
        {
            _velocity.y = 0;
        }
        else
        {
            _velocity.y -= physicsSettings.downAccel;
        }
        _jumpInput = 0;
    }

    void CheckGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance) && !hit.collider.isTrigger)
        {
            _onGround = true;
            _rigidbody.useGravity = false;
            if (_velocity.y <= 0)
            {
                _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Time.deltaTime * 10);
            }
        }
        else
        {
            _onGround = false;
            _rigidbody.useGravity = true;
        }
    }

    void MoveX()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_xMovement, transform.position.y, transform.position.z), Time.deltaTime * xSpeed);
    }

    void InputHandling()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            inputBuffer.Enqueue(() => { _jumpInput = 1; });
            Debug.Log("Jump input detected");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputBuffer.Enqueue(() => { _slideInput = 1; });
            Debug.Log("Slide input detected");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputBuffer.Enqueue(() =>
            {
                if (_xMovement == 0)
                {
                    _xMovement = 3;
                }
                else if (_xMovement == -3)
                {
                    _xMovement = 0;
                }
            });
            Debug.Log("Move right input detected");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputBuffer.Enqueue(() =>
            {
                if (_xMovement == 0)
                {
                    _xMovement = -3;
                }
                else if (_xMovement == 3)
                {
                    _xMovement = 0;
                }
            });
            Debug.Log("Move left input detected");
        }
    }

    void UpdateDistanceTraveled()
    {
        // Calculate distance traveled assuming forward movement along z-axis
        movementSettings.distanceTravelled = transform.position.z;
    }

    void UpdateForwardVelocity()
    {
        // Example: Increase speed linearly based on distance
        movementSettings.forwardVelocity = 10 + movementSettings.distanceTravelled * 0.01f; // Adjust 0.1f based on desired rate
    }

    public void ResetCollider()
    {
        playerCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstracle"))
        {
            _animator.SetTrigger("out");
            isOut = true;
        }
    }
}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningmovements : MonoBehaviour
{
    [System.Serializable]
    public class MovementSettings
    {
        public float forwardVelocity = 10;
        public float jumpVelocity = 10;
        public float distanceTravelled = 0; // Track distance traveled
    }

    [System.Serializable]
    public class PhysicsSettings
    {
        public float downAccel = 0.50f;
    }

    public MovementSettings movementSettings = new MovementSettings();
    public PhysicsSettings physicsSettings = new PhysicsSettings();
    public Vector3 _velocity;
    public float xSpeed = 10;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private int _jumpInput = 0, _slideInput = 0;
    private bool _onGround = false;
    private float _xMovement = 0;
    public CapsuleCollider playerCollider;
    public float rayDistance = 1.0f;
    public bool isOut = false;
    private int heartsUsed = 0;

    private HeartsUI heartsUI; // Reference to the HeartsUI script

    private Queue<System.Action> inputBuffer = new Queue<System.Action>();

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _velocity = Vector3.zero;

        heartsUI = FindObjectOfType<HeartsUI>(); // Find the HeartsUI script in the scene
        if (heartsUI == null)
        {
            Debug.LogError("HeartsUI script not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputHandling();
    }

    // FixedUpdate is called once per fixed frame-rate frame
    void FixedUpdate()
    {
        if (isOut)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            return;
        }

        while (inputBuffer.Count > 0)
        {
            inputBuffer.Dequeue().Invoke();
        }

        Run();
        CheckGround();
        Jump();
        MoveX();
        Slide();
        UpdateDistanceTraveled();
        UpdateForwardVelocity();

        _rigidbody.velocity = _velocity;
    }

    void Run()
    {
        _velocity.z = movementSettings.forwardVelocity;
    }

    void Slide()
    {
        if (_slideInput == 1 && _animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            _animator.SetTrigger("slide");
            _slideInput = 0;
            // Disable the collider during the slide
            playerCollider.enabled = false;
            Invoke(nameof(ResetCollider), 1);
        }
    }

    void Jump()
    {
        if (_jumpInput == 1 && _animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            _velocity.y = movementSettings.jumpVelocity;
            _animator.SetTrigger("jump");
            // Disable the collider during the jump
            playerCollider.enabled = false;
            Invoke(nameof(ResetCollider), 1);
        }
        else if (_onGround)
        {
            _velocity.y = 0;
        }
        else
        {
            _velocity.y -= physicsSettings.downAccel;
        }
        _jumpInput = 0;
    }

    void CheckGround()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance) && !hit.collider.isTrigger)
        {
            _onGround = true;
            _rigidbody.useGravity = false;
            if (_velocity.y <= 0)
            {
                _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z), Time.deltaTime * 10);
            }
        }
        else
        {
            _onGround = false;
            _rigidbody.useGravity = true;
        }
    }

    void MoveX()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_xMovement, transform.position.y, transform.position.z), Time.deltaTime * xSpeed);
    }

    void InputHandling()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            inputBuffer.Enqueue(() => { _jumpInput = 1; });
            Debug.Log("Jump input detected");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputBuffer.Enqueue(() => { _slideInput = 1; });
            Debug.Log("Slide input detected");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputBuffer.Enqueue(() =>
            {
                if (_xMovement == 0)
                {
                    _xMovement = 3;
                }
                else if (_xMovement == -3)
                {
                    _xMovement = 0;
                }
            });
            Debug.Log("Move right input detected");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputBuffer.Enqueue(() =>
            {
                if (_xMovement == 0)
                {
                    _xMovement = -3;
                }
                else if (_xMovement == 3)
                {
                    _xMovement = 0;
                }
            });
            Debug.Log("Move left input detected");
        }
        if (Input.GetKeyDown(KeyCode.Q)) // Use heart when 'Q' key is pressed
        {
            UseHeart();
        }
    }

    void UpdateDistanceTraveled()
    {
        // Calculate distance traveled assuming forward movement along z-axis
        movementSettings.distanceTravelled = transform.position.z;
    }

    void UpdateForwardVelocity()
    {
        // Example: Increase speed linearly based on distance
        movementSettings.forwardVelocity = 10 + movementSettings.distanceTravelled * 0.01f; // Adjust 0.01f based on desired rate
    }

    void UseHeart()
    {
        if (heartsUsed < GameManager.Instance.HeartsCollected)
        {
            // Implement logic here to use a heart (e.g., revive player, continue game)
            Debug.Log("Using heart to continue game...");
            isOut = false; // Example: Resume gameplay
            heartsUsed++;
        }
        else
        {
            Debug.Log("No more hearts left to use!");
        }
    }

    public void ResetCollider()
    {
        playerCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _animator.SetTrigger("out");
            isOut = true;
        }
        else if (other.CompareTag("Heart"))
        {
            // Notify the GameManager that a heart has been collected
            GameManager.Instance.CollectHeart();
            Destroy(other.gameObject); // Destroy the heart object after collection

            // Update hearts UI
            if (heartsUI != null)
            {
                heartsUI.UpdateHearts(GameManager.Instance.HeartsCollected);
            }
        }
    }
}*/

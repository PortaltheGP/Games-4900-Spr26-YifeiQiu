extends CharacterBody3D

@export var move_speed: float = 6.0
@export var accel: float = 20.0
@export var decel: float = 25.0
func _process(delta):
	if Input.is_action_just_pressed("attack"):
		print("Attack!!")
		
func _physics_process(delta: float) -> void:
	var input_2d := Vector2.ZERO
	input_2d.x = Input.get_action_strength("move_right") - Input.get_action_strength("move_left")
	input_2d.y = Input.get_action_strength("move_back") - Input.get_action_strength("move_forward")
	input_2d = input_2d.normalized()

	var move_dir := Vector3(input_2d.x, 0.0, input_2d.y).normalized()

	var gravity: float = ProjectSettings.get_setting("physics/3d/default_gravity")
	if not is_on_floor():
		velocity.y -= gravity * delta
	else:
		velocity.y = 0.0 

	var target_vel := move_dir * move_speed
	var horizontal := Vector3(velocity.x, 0.0, velocity.z)

	var rate := accel if move_dir.length() > 0.0 else decel
	horizontal = horizontal.lerp(target_vel, 1.0 - exp(-rate * delta))

	velocity.x = horizontal.x
	velocity.z = horizontal.z


	move_and_slide()

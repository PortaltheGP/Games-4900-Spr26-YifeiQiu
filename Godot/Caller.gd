extends Node3D

@export var receiver: Node3D 

func _ready():
	print("Hello Friend")
	receiver.OnCalled()

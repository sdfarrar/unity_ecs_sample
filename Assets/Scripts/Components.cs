using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public struct PlayerInput: IComponentData{
	public float Horizontal;
	public float Vertical;
}

public struct Block: IComponentData{}
public struct Fly: IComponentData{}
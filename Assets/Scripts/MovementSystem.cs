//using System.Collections;
//using System.Collections.Generic;
//using Unity.Entities;
//using Unity.Transforms;
//using UnityEngine;
//
//public class MovementSystem : ComponentSystem {
//
//	public struct PlayerGroup{
//		public ComponentDataArray<Position> playerPos;
//		public ComponentDataArray<PlayerInput> playerInput;
//		public int Length;
//	}
//
//	[Inject] PlayerGroup playerGroup;
//	protected override void OnUpdate () {
//		for(int i=0; i<playerGroup.Length; ++i){
//			Position newPos = playerGroup.playerPos[i];
//			Vector2 temp = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
//			newPos.Value.x += temp.x * 10f * Time.deltaTime;
//			newPos.Value.y += temp.y * 10f * Time.deltaTime;
//			playerGroup.playerPos[i] = newPos;
//		}
//	}
//
//}

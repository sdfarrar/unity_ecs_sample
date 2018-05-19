using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class BlockDeleteSystem : ComponentSystem {

	public struct PlayerGroup{
		public ComponentDataArray<Position> playerPos;
		public ComponentDataArray<GridPlayerInput> input; // change to PlayerInput if using free movement system
		public int Length;
	}

	// public SubtractiveComponent<Fly> fly prevents entities that already contain the Fly component
	// from being added to the entitiesArray. Attempting to add multiple of the same component to an 
	// entities results in an error
	public struct BlockGroup{
		public ComponentDataArray<Block> block;
		public ComponentDataArray<Position> blockPos;
		public SubtractiveComponent<Fly> fly;
		public EntityArray entityArray;
		public int Length;
	}

	[Inject] PlayerGroup playerGroup;
	[Inject] BlockGroup blockGroup;

	protected override void OnUpdate() {
		for(int i=0; i<blockGroup.Length; ++i){
			float dist = math.distance(playerGroup.playerPos[0].Value, blockGroup.blockPos[i].Value);
			if(dist<1){ PostUpdateCommands.AddComponent(blockGroup.entityArray[i], new Fly()); }
		}
    }
}

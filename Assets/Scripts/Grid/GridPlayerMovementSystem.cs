using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class GridPlayerMovementSystem : JobComponentSystem {

	public struct GridPlayerMovementJob : IJobProcessComponentData<Position, GridPlayerInput>{
		// Loop through all entities with GridPlayerInput component and store input value
		public void Execute(ref Position position, ref GridPlayerInput input){
			position.Value.x += input.Horizontal;
			position.Value.y += input.Vertical;
		}
	}

	private static int batchSize = 1;

	protected override JobHandle OnUpdate(JobHandle inputDeps) {
		GridPlayerMovementJob job = new GridPlayerMovementJob{};
		
		return job.Schedule(this, batchSize, inputDeps);
	}

}
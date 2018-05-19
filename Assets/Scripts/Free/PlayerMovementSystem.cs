using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class PlayerMovementSystem : JobComponentSystem {

	public struct PlayerMovementJob : IJobProcessComponentData<Position, PlayerInput>{
		public float dt;

		// Loop through all entities with PlayerInput component and store input value
		public void Execute(ref Position position, ref PlayerInput input){
			position.Value.x += input.Horizontal * 10 * dt;
			position.Value.y += input.Vertical * 10 * dt;
		}
	}

	private static int batchSize = 1;

	protected override JobHandle OnUpdate(JobHandle inputDeps) {
		// Prepare data for job
		PlayerMovementJob job = new PlayerMovementJob{
			dt = Time.deltaTime, // cannot access Time.deltaTime within our job
		};
		
		return job.Schedule(this, batchSize, inputDeps);
	}

}
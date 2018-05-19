using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class PlayerInputSystem : JobComponentSystem {

	public struct PlayerInputJob : IJobProcessComponentData<PlayerInput>{
		public float Horizontal;
		public float Vertical;

		// Loop through all entities with PlayerInput component and store input value
		public void Execute(ref PlayerInput input){
			input.Horizontal = Horizontal;
			input.Vertical = Vertical;
		}
	}

	private static int batchSize = 1;

	protected override JobHandle OnUpdate(JobHandle inputDeps) {
		// Prepare data for job
		PlayerInputJob job = new PlayerInputJob{
			Horizontal = Input.GetAxisRaw("Horizontal"),
			Vertical = Input.GetAxisRaw("Vertical")
		};
		
		return job.Schedule(this, batchSize, inputDeps);
	}

}

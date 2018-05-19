
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class GridPlayerInputSystem : JobComponentSystem {

    public struct GridPlayerInputJob : IJobProcessComponentData<GridPlayerInput> {
        public bool Left;
        public bool Right;
        public bool Up;
        public bool Down;

        public bool UpLeft;
        public bool UpRight;
        public bool DownLeft;
        public bool DownRight;

        public void Execute(ref GridPlayerInput input) {
            input.Horizontal = Left || UpLeft || DownLeft ? -1f : Right || UpRight || DownRight ? 1f : 0;
            input.Vertical = Down || DownLeft || DownRight ? -1f : Up || UpRight || UpLeft ? 1f : 0;
        }

    }

    private static int batchSize = 1;

	protected override JobHandle OnUpdate(JobHandle inputDeps) {
		// Prepare data for job
		GridPlayerInputJob job = new GridPlayerInputJob{
			Left = Input.GetKeyDown(KeyCode.A),
			Right = Input.GetKeyDown(KeyCode.D),
			Up = Input.GetKeyDown(KeyCode.W),
			Down = Input.GetKeyDown(KeyCode.S),

			UpLeft = Input.GetKeyDown(KeyCode.Q),
			UpRight = Input.GetKeyDown(KeyCode.E),
			DownLeft = Input.GetKeyDown(KeyCode.Z),
			DownRight = Input.GetKeyDown(KeyCode.C),

		};
		
		return job.Schedule(this, batchSize, inputDeps);
	}

}

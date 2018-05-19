using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class FlySystem : JobComponentSystem {

    private struct FlyJob : IJobProcessComponentData<Position, Fly> {
		public float dt;
		public bool flyAway;

        public void Execute(ref Position position, ref Fly fly) {
			//if(!flyAway){ return; }

			float xMove = Mathf.PerlinNoise(position.Value.x, position.Value.y) - 1.5f;
			float yMove = Mathf.PerlinNoise(position.Value.x, position.Value.y) + 0.5f;
			position.Value += dt * new float3(xMove, yMove, 0);
        }
    }

	protected override JobHandle OnUpdate(JobHandle inputDeps){
		FlyJob job = new FlyJob{
			dt = Time.deltaTime,
			//flyAway = Input.GetKey(KeyCode.F)
		};

		return job.Schedule(this, 1, inputDeps);
	}

}

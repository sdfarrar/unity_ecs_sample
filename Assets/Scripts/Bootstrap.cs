using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Bootstrap : MonoBehaviour {

	public Mesh PlayerMesh;
	public Material PlayerMaterial;

	public Mesh BlockMesh;
	public Material BlockMaterial;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private void Start () {
		EntityManager entityManager = World.Active.GetOrCreateManager<EntityManager>();

		// Setup player
		EntityArchetype playerArchetype = GetGridPlayerArchetype(entityManager);

		Entity player = entityManager.CreateEntity(playerArchetype);
		entityManager.SetSharedComponentData(player, new MeshInstanceRenderer{
			mesh = PlayerMesh,
			material = PlayerMaterial
		});

		// Setup Block
		EntityArchetype blockArchetype = entityManager.CreateArchetype(
			typeof(TransformMatrix),
			typeof(Position),
			typeof(MeshInstanceRenderer),
			typeof(Block)
		);

		// Make 5x5 grid
		for(int x=-3; x<2; ++x){
			for(int y=-3; y<2; ++y){
				Entity block = entityManager.CreateEntity(blockArchetype);
				entityManager.SetSharedComponentData(block, new MeshInstanceRenderer{
					mesh = BlockMesh,
					material = BlockMaterial
				});

				// Set intial position for this block
				Position pos = new Position{Value=new float3(x, y, 0)};
				entityManager.SetComponentData(block, pos);
			}
		} 
	}

	private EntityArchetype GetPlayerArchetype(EntityManager manager){
		return manager.CreateArchetype(
			typeof(TransformMatrix),
			typeof(Position),
			typeof(MeshInstanceRenderer),
			typeof(PlayerInput)
		);
	}

	private EntityArchetype GetGridPlayerArchetype(EntityManager manager){
		return manager.CreateArchetype(
			typeof(TransformMatrix),
			typeof(Position),
			typeof(MeshInstanceRenderer),
			typeof(GridPlayerInput)
		);
	}

}

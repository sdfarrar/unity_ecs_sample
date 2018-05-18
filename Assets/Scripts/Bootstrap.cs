using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Bootstrap : MonoBehaviour {

	public Mesh PlayerMesh;
	public Material PlayerMaterial;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private void Start () {
		EntityManager entityManager = World.Active.GetOrCreateManager<EntityManager>();
		EntityArchetype playerArchetype = entityManager.CreateArchetype(
			typeof(TransformMatrix),
			typeof(Position),
			typeof(MeshInstanceRenderer)
		);

		Entity player = entityManager.CreateEntity(playerArchetype);
		entityManager.SetSharedComponentData(player, new MeshInstanceRenderer{
			mesh = PlayerMesh,
			material = PlayerMaterial
		});
	}

}

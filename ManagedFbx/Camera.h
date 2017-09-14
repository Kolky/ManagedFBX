#pragma once

#include "SceneObject.h"

namespace ManagedFbx
{
	public enum class ProjectionType
	{
		Perspective = FbxCamera::ePerspective,
		Orthogonal = FbxCamera::eOrthogonal
	};

	public ref class Camera : SceneObject
	{
	public:
		property_r(ProjectionType, Projection);
		property_r(Vector3, Position);
	internal:
		Camera(FbxCamera *nativeCamera);
	private:
		FbxCamera *m_nativeCamera;
	};
}
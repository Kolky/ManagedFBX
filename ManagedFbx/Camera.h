#pragma once

namespace ManagedFbx
{
	public enum class ProjectionType
	{
		Perspective = FbxCamera::ePerspective,
		eOrthogonal = FbxCamera::eOrthogonal
	};

	public ref class Camera
	{
	public:
		property_r(ProjectionType, Type);
	internal:
		Camera(FbxCamera *nativeCamera);
	private:
		FbxCamera *m_nativeCamera;
	};
}
#include "stdafx.h"
#include "Camera.h"

using namespace ManagedFbx;

Camera::Camera(FbxCamera *nativeCamera)
	: SceneObject(nativeCamera)
{
	m_nativeCamera = nativeCamera;
}

ProjectionType Camera::Projection::get()
{
	return (ProjectionType)m_nativeCamera->ProjectionType.Get();
}

Vector3 Camera::Position::get()
{
	return Vector3(m_nativeCamera->Position.Get());
}
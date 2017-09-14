#include "stdafx.h"
#include "SceneNode.h"

using namespace ManagedFbx;

SceneNode::SceneNode(FbxNode *nativeNode)
	: SceneObject(nativeNode)
{
	m_nativeNode = nativeNode;

	m_children = gcnew List<SceneNode^>();
	m_attributes = gcnew List<NodeAttribute^>();
	m_materials = gcnew List<Material^>();

	for(int i = 0; i < m_nativeNode->GetChildCount(); i++)
	{
		auto sub = m_nativeNode->GetChild(i);
		m_children->Add(gcnew SceneNode(sub));
	}

	for(int i = 0; i < m_nativeNode->GetNodeAttributeCount(); i++)
	{
		auto attr = m_nativeNode->GetNodeAttributeByIndex(i);
		m_attributes->Add(gcnew NodeAttribute(attr));
	}

	for (int i = 0; i < m_nativeNode->GetMaterialCount(); ++i)
	{
		auto mat = m_nativeNode->GetMaterial(i);
		m_materials->Add(gcnew Material(mat));
	}
}

IEnumerable<SceneNode^>^ SceneNode::ChildNodes::get()
{
	return m_children->AsReadOnly();
}

IEnumerable<NodeAttribute^>^ SceneNode::Attributes::get()
{
	return m_attributes->AsReadOnly();
}

IEnumerable<Material^>^ SceneNode::Materials::get()
{
	return m_materials->AsReadOnly();
}

void SceneNode::AddChild(SceneNode ^node)
{
	m_nativeNode->AddChild(node->m_nativeNode);
	m_children->Add(node);
}

void SceneNode::Position::set(Vector3 value)
{
	m_nativeNode->LclTranslation.Set(value);
}

void SceneNode::Rotation::set(Vector3 value)
{
	m_nativeNode->LclRotation.Set(value);
}

void SceneNode::Scale::set(Vector3 value)
{
	m_nativeNode->LclScaling.Set(value);
}

Vector3 SceneNode::Position::get()
{
	return Vector3(m_nativeNode->LclTranslation.Get());
}

Vector3 SceneNode::Rotation::get()
{
	return Vector3(m_nativeNode->LclRotation.Get());
}

Vector3 SceneNode::Scale::get()
{
	return Vector3(m_nativeNode->LclScaling.Get());
}

Mesh ^SceneNode::Mesh::get()
{
	return gcnew ManagedFbx::Mesh(m_nativeNode->GetMesh());
}

Light ^SceneNode::Light::get()
{
	return gcnew ManagedFbx::Light(m_nativeNode->GetLight());
}

Camera ^SceneNode::Camera::get()
{
	return gcnew ManagedFbx::Camera(m_nativeNode->GetCamera());
}
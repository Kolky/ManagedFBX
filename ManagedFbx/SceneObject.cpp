#include "stdafx.h"
#include "SceneObject.h"

using namespace ManagedFbx;

SceneObject::SceneObject(FbxObject *nativeObject)
{
	m_nativeObject = nativeObject;
	m_properties = gcnew List<NodeProperty^>();

	for (int i = 0; i < m_nativeObject->GetSrcPropertyCount(); i++)
	{
		auto prop = m_nativeObject->GetSrcProperty(i);
		if (prop.IsValid())
		{
			m_properties->Add(gcnew NodeProperty(prop, true, false));
		}
	}

	for (int i = 0; i < m_nativeObject->GetDstPropertyCount(); i++)
	{
		auto prop = m_nativeObject->GetDstProperty(i);
		if (prop.IsValid())
		{
			m_properties->Add(gcnew NodeProperty(prop, false, true));
		}
	}

	auto prop = m_nativeObject->GetFirstProperty();
	while (prop.IsValid())
	{
		m_properties->Add(gcnew NodeProperty(prop, false, false));
		prop = m_nativeObject->GetNextProperty(prop);
	}
}

IEnumerable<NodeProperty^>^ SceneObject::Properties::get()
{
	return m_properties->AsReadOnly();
}

string ^SceneObject::Name::get()
{
	return gcnew string(m_nativeObject->GetName());
}

ObjectFlag SceneObject::Flags::get()
{
	return (ObjectFlag)m_nativeObject->GetAllObjectFlags();
}

void SceneObject::Name::set(string ^value)
{
	m_nativeObject->SetName(StringHelper::ToNative(value));
}
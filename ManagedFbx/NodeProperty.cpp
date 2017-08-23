#include "stdafx.h"
#include "NodeProperty.h"

using namespace ManagedFbx;

NodeProperty::NodeProperty(FbxProperty prop, bool source, bool destination)
{
	m_Name = gcnew string(prop.GetName());
	auto dataType = prop.GetPropertyDataType();
	switch (dataType.GetType())
	{
	case EFbxType::eFbxString:
		m_Value = gcnew string(prop.Get<FbxString>());
		break;
	case EFbxType::eFbxInt:
		m_Value = gcnew string(prop.Get<FbxInt>().ToString());
		break;
	}
	m_DataType = gcnew string(dataType.GetName());
	m_isSource = source;
	m_isDestination = destination;
}

bool NodeProperty::IsSource::get()
{
	return m_isSource;
}

bool NodeProperty::IsDestination::get()
{
	return m_isDestination;
}

string ^NodeProperty::Name::get()
{
	return m_Name;
}

string ^NodeProperty::DataType::get()
{
	return m_DataType;
}

string ^NodeProperty::Value::get()
{
	return m_Value;
}
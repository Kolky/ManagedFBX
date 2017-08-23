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
	case EFbxType::eFbxFloat:
		m_Value = gcnew string(prop.Get<FbxFloat>().ToString());
		break;
	case EFbxType::eFbxDouble:
		m_Value = gcnew string(prop.Get<FbxDouble>().ToString());
		break;
	case EFbxType::eFbxEnum:
		m_Value = gcnew string(prop.Get<FbxEnum>().ToString());
		break;
	case EFbxType::eFbxBool:
		m_Value = gcnew string(prop.Get<FbxBool>().ToString());
		break;
	case EFbxType::eFbxDouble2:
		{
			FbxDouble2 double2 = prop.Get<FbxDouble2>();
			m_Value = gcnew string(Vector2(double2).ToString());
		}
		break;
	case EFbxType::eFbxDouble3:
		{
			FbxDouble3 double3 = prop.Get<FbxDouble3>();
			m_Value = gcnew string(Vector3(double3).ToString());
		}
		break;
	case EFbxType::eFbxDouble4:
		{
			FbxDouble4 double4 = prop.Get<FbxDouble4>();
			m_Value = gcnew string(Vector3(double4).ToString());
		}
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
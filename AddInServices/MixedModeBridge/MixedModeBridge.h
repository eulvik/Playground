// MixedModeBridge.h
#include <MyFunctions.h>
#include <msclr\marshal_cppstd.h>

#pragma once

using namespace System;
using namespace msclr::interop;

namespace MixedModeBridge {

	public ref class Class1
	{
		
	public:
		String^ GetHello()
		{
			MyFunctions* funcs = new MyFunctions();
			std::string hello = funcs->getHello();
			String^ result;
			result = marshal_as<String^>(hello);

			return result;
		}
		// TODO: Add your methods for this class here.
	};
}

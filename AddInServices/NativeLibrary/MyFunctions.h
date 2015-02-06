#pragma once
#include <string>

__declspec(dllexport)
class MyFunctions
{
public:
	MyFunctions();
	~MyFunctions();

	std::string getHello();
};


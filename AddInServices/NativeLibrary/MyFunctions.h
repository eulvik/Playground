#pragma once
#include <string>

class __declspec(dllexport) MyFunctions
{
public:
	MyFunctions();
	~MyFunctions();

	std::string getHello();
};


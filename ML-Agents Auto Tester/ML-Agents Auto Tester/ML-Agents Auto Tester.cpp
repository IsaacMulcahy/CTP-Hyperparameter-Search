// ML-Agents Auto Tester.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <Windows.h>
#include <string>


std::wstring unity_path = L"\"C:\\Program Files\\Unity\\Hub\\Editor\\2019.1.3f1\\Editor\\Unity.exe\"";
std::wstring project_path = L"C:\\Users\\isaac\\Documents\\GitHub\\ML-Agents CTP";

void sleep(unsigned milliseconds)
{
	Sleep(milliseconds);
}

bool runTest(int num);
bool runMLAgents(std::wstring value);
bool runUnity(std::wstring value);

void main()
{
    std::cout << "Auto Test\n"; 
	
	for (int i = 0; i < 27; i++)
	{
		std::string text = "Test " + std::to_string(i) + "\n";

		std::cout << text;

		runTest(i);
	}

		

}

bool runTest(int num)
{
	// Run Test
	if (runMLAgents(std::to_wstring(num)))
	{
		if (runUnity(std::to_wstring(num)))
		{
			std::string text = " \n Started Annoconda ML Agents for " + std::to_string(num) + "\n";

			std::cout << text;

			std::cout << "  Unity Started - 30mins runtime \n";

			sleep(1.8e+6); // 1.8e+6 30mins

			std::cout << " Clearing Down & Saving \n";

			system("Taskkill /IM Unity.exe /F");

			// Give time for Ml Agents to save
			sleep(120000);

			std::cout << " Saved & finshed test \n";

			return true;
		}

		return false;
	}

	return false;
}

bool runMLAgents(std::wstring value)
{
	std::cout << "Starting Annoconda ML Agents...\n";

	// Setup ML-Agents
	std::wstring anaconda = L"C:\\Users\\isaac\\Anaconda3\\Scripts\\activate.bat";
	std::wstring ml_agent_setup = L"activate ml-agents";
	std::wstring ml_agent_address = L"cd C:\\Users\\isaac\\Documents\\GitHub\\ml-agents-0.14.0";
	std::wstring training = L"mlagents-learn config/trainer_config.yaml --curriculum config/curricula/Auto" + value;
	std::wstring training2 = L".yaml --run-id Auto" + value;
	std::wstring training3 = L" --train";

	std::wstring cmd_string = anaconda + L" & " + ml_agent_setup + L" & " + ml_agent_address + L" & " + training + training2 + training3;


	// Make Process
	STARTUPINFO process_startup_info{ 0 };
	process_startup_info.cb = sizeof(process_startup_info);
	PROCESS_INFORMATION pi{0};

	LPWSTR result = const_cast<LPWSTR>(cmd_string.c_str());


	if (!CreateProcess(NULL,   // No module name (use command line)
		result,         // Command line
		NULL,           // Process handle not inheritable
		NULL,           // Thread handle not inheritable
		TRUE,          // Set handle inheritance to FALSE
		0,              // No creation flags
		NULL,           // Use parent's environment block
		NULL,           // Use parent's starting directory 
		&process_startup_info,            // Pointer to STARTUPINFO structure
		&pi)           // Pointer to PROCESS_INFORMATION structure
		)
	{
		return false;
	}

	WaitForSingleObject(pi.hProcess, 1000);

	return true;
}

bool runUnity(std::wstring value)
{
	std::cout << "Starting Unity Project...\n";
	
	std::wstring  cmd_string = unity_path + L" -window-mode -projectPath \"" + project_path + L"\" -executeMethod AutoTestingSystem.AutoTest.Test" + value;

	// Make Process
	STARTUPINFO process_startup_info{ 0 };
	process_startup_info.cb = sizeof(process_startup_info);
	PROCESS_INFORMATION pi{ 0 };

	LPWSTR result = const_cast<LPWSTR>(cmd_string.c_str());


	if (!CreateProcess(NULL,   // No module name (use command line)
		result,         // Command line
		NULL,           // Process handle not inheritable
		NULL,           // Thread handle not inheritable
		TRUE,          // Set handle inheritance to FALSE
		0,              // No creation flags
		NULL,           // Use parent's environment block
		NULL,           // Use parent's starting directory 
		&process_startup_info,            // Pointer to STARTUPINFO structure
		&pi)           // Pointer to PROCESS_INFORMATION structure
		)
	{
		return false;
	}

	WaitForSingleObject(pi.hProcess, 10000);

	return true;

	std::cout << "Project Running\n";
}


// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file

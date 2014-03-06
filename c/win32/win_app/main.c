#include <Windows.h>

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PWSTR szCmdLine, int cmdShow) {
    MessageBoxW(NULL, szCmdLine, L"Title", MB_OK);

    return EXIT_SUCCESS;
}
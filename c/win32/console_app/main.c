#define _UNICODE
#define UNICODE

#include <Windows.h>
#include <tchar.h>

int _tmain(int argc, TCHAR *argv[]) {
    PDWORD chars = NULL;
    HANDLE outputHandle = GetStdHandle(STD_OUTPUT_HANDLE);

    if (outputHandle == INVALID_HANDLE_VALUE) {
        _tprintf(L"Cannot retrieve standard output handle\n (%d)", GetLastError());
    }

    WriteConsoleW(outputHandle, argv[1], _tcslen(argv[1]), chars, NULL);

    return EXIT_SUCCESS;
}
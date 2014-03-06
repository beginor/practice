#include <Windows.h>
#include <wchar.h>

#define STR_EQUAL 0

int wmain(int argc, WCHAR *argv[]) {
    SYSTEMTIME lt;
    GetLocalTime(&lt);

    wprintf(L"The local time is: %02d:%02d:%02d\n", lt.wHour, lt.wMinute, lt.wSecond);

    return EXIT_SUCCESS;
}
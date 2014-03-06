#include <Windows.h>
#include <wchar.h>

int wmain(int argc, WCHAR *argv[]) {
    wchar_t str[] = L"Europa";

    CharLowerW(str);
    wprintf(L"%ls\n", str);

    CharUpperW(str);
    wprintf(L"%ls\n", str);
    return EXIT_SUCCESS;
}
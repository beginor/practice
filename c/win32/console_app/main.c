#include <Windows.h>
#include <wchar.h>

int wmain(int argc, WCHAR *argv[]) {
    char *name = "Jane";
    wchar_t *town = L"Bratislava";

    wprintf(L"The length of the name string is %d\n", lstrlenA(name));
    wprintf(L"The town string length is %d\n", lstrlenW(town));

    return EXIT_SUCCESS;
}
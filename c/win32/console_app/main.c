#include <Windows.h>
#include <wchar.h>

int wmain(int argc, WCHAR *argv[]) {
    wchar_t *s1 = L"Zetcode, ";
    wchar_t *s2 = L"tutorials ";
    wchar_t *s3 = L"for ";
    wchar_t *s4 = L"programmers.\n";

    int len = lstrlenW(s1) + lstrlenW(s2) + lstrlenW(s3) + lstrlenW(s4);
    wchar_t *buff = malloc(sizeof(wchar_t) * (len + 1));
    lstrcpyW(buff, s1);
    lstrcatW(buff, s2);
    lstrcatW(buff, s3);
    lstrcatW(buff, s4);

    wprintf(buff);

    free(buff);
    return EXIT_SUCCESS;
}
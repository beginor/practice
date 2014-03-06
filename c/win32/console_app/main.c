#include <Windows.h>
#include <wchar.h>

#define STR_EQUAL 0

int wmain(int argc, WCHAR *argv[]) {
    SYSTEMTIME st;
    wchar_t buff[50];

    GetLocalTime(&st);

    wsprintfW(buff, L"Today is %d-%d-%d\n", st.wYear, st.wMonth, st.wDay);

    wprintf(buff);

    //free(buff);

    return EXIT_SUCCESS;
}
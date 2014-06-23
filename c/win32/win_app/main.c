#include <Windows.h>
#include <stdio.h>
#include <stdlib.h>

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PWSTR szCmdLine, int cmdShow) {
    MessageBoxW(NULL, szCmdLine, L"Title", MB_OK);

    int ** off = malloc(sizeof(int *) * 10);
    for (int i = 0; i < 10; i++) {
        off[i] = malloc(sizeof(int) * 10);
        for (int j = 0; j < 10; j++) {
            off[i][j] = rand();
        }
    }

    

    return EXIT_SUCCESS;
}
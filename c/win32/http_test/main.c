#include <stdio.h>
#include <Windows.h>
#include <winhttp.h>

void doSyncRequest();

void doAsyncRequest();

void httpCallback(HINTERNET hInternet, DWORD_PTR dwContext, DWORD dwInternetStatus, LPVOID lpvStatusInformation, DWORD dwStatusInformationLength);

int main(int argc, char **argv) {
    printf("Start sync request...\n");
    doSyncRequest();
    printf("End asyc request.\n");

    printf("Start async request...\n");
    doAsyncRequest();
    printf("End async request.");

    return EXIT_SUCCESS;
}

void doSyncRequest() {
    DWORD size = 0;
    DWORD downloaded = 0;
    LPSTR outBuffer;
    BOOL result = FALSE;
    HINTERNET session = NULL;
    HINTERNET connect = NULL;
    HINTERNET request = NULL;

    // use WinHttpOpen
    session = WinHttpOpen(L"WinHttp Example/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0);

    // Specify an Http Server
    if (session) {
        connect = WinHttpConnect(session, L"www.microsoft.com", INTERNET_DEFAULT_HTTPS_PORT, 0);
    }

    // create an http handle
    if (connect) {
        request = WinHttpOpenRequest(connect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_SECURE);
    }

    // Send a request;
    if (request) {
        result = WinHttpSendRequest(request, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0);
    }

    // end the request
    if (result) {
        result = WinHttpReceiveResponse(request, NULL);
    }

    // keep checking for data until there is nothing left.
    if (result) {
        do {
            size = 0;
            if (!WinHttpQueryDataAvailable(request, &size)) {
                printf("Error %u in WinHttpQueryDataAvilable.\n", GetLastError());
            }

            // allocate space for the buffer.
            outBuffer = (LPSTR)malloc(sizeof(CHAR)* (size + 1));
            if (!outBuffer) {
                printf("Out of memory\n");
                size = 0;
            }
            else {
                memset(outBuffer, 0, size + 1);

                if (!WinHttpReadData(request, (LPVOID)outBuffer, size, &downloaded)) {
                    printf("Error %u in WinHttpReadData.\n", GetLastError());
                }
                else {
                    printf("%s", outBuffer);
                }
                free(outBuffer);
            }
        } while (size > 0);
    }

    // report any errors
    if (!result) {
        printf("Error %d has occurred.\n", GetLastError());
    }

    if (request) {
        WinHttpCloseHandle(request);
    }
    if (connect) {
        WinHttpCloseHandle(connect);
    }
    if (session) {
        WinHttpCloseHandle(session);
    }
}

int theRequest = 0;

void doAsyncRequest() {
    HINTERNET session = NULL;
    HINTERNET connect = NULL;
    HINTERNET request = NULL;

    session = WinHttpOpen(L"WinHttp Async Example/1.0", WINHTTP_ACCESS_TYPE_NO_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, WINHTTP_FLAG_ASYNC);
    WINHTTP_STATUS_CALLBACK theCallback = WinHttpSetStatusCallback(session, (WINHTTP_STATUS_CALLBACK)httpCallback, WINHTTP_CALLBACK_FLAG_ALL_NOTIFICATIONS, 0);
    connect = WinHttpConnect(session, L"www.microsoft.com", INTERNET_DEFAULT_HTTPS_PORT, 0);
    
    BOOL allDone = FALSE;
    theRequest = 1;

    DWORD size = 0;
    DWORD downloaded = 0;
    LPSTR outBuffer;
    BOOL result = FALSE;

    while (!allDone) {
        if (theRequest == 1) {
            request = WinHttpOpenRequest(connect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_SECURE);
            WinHttpSendRequest(request, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REFERER, 0, 0, 0);
        }
        else if (theRequest == 2) {
            WinHttpReceiveResponse(request, NULL);
        }
        else if (theRequest == 3) {
            result = WinHttpQueryDataAvailable(request, &size);
            if (result) {
                do {
                    size = 0;
                    if (!WinHttpQueryDataAvailable(request, &size)) {
                        printf("Error %u in WinHttpQueryDataAvilable.\n", GetLastError());
                    }

                    // allocate space for the buffer.
                    outBuffer = (LPSTR)malloc(sizeof(CHAR)* (size + 1));
                    if (!outBuffer) {
                        printf("Out of memory\n");
                        size = 0;
                    }
                    else {
                        memset(outBuffer, 0, size + 1);

                        if (!WinHttpReadData(request, (LPVOID)outBuffer, size, &downloaded)) {
                            printf("Error %u in WinHttpReadData.\n", GetLastError());
                        }
                        else {
                            printf("%s", outBuffer);
                        }
                        free(outBuffer);
                    }
                } while (size > 0);
            }
            break;
        }
    }

    // report any errors
    if (!result) {
        printf("Error %d has occurred.\n", GetLastError());
    }

    if (request) {
        WinHttpCloseHandle(request);
    }
    if (connect) {
        WinHttpCloseHandle(connect);
    }
    if (session) {
        WinHttpCloseHandle(session);
    }
}

void httpCallback(HINTERNET hInternet, DWORD_PTR dwContext, DWORD dwInternetStatus, LPVOID lpvStatusInformation, DWORD dwStatusInformationLength) {
    switch (dwInternetStatus) {
    default:
        printf("http status is %u \n", dwInternetStatus);
        break;
    case WINHTTP_CALLBACK_STATUS_HANDLE_CREATED:
        printf("handle created.\n");
        theRequest = 1;
        break;
    case WINHTTP_CALLBACK_STATUS_REQUEST_SENT:
        printf("request sent.\n");
        theRequest = 2;
        break;
    case WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED:
        printf("response receivec.\n");
        theRequest = 3;
        break;
    }

}

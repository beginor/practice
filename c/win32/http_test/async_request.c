#include "async_request.h"

void http_callback(HINTERNET hInternet, DWORD_PTR dwContext, DWORD dwInternetStatus, LPVOID lpvStatusInformation, DWORD dwStatusInformationLength);

DWORD internetStatus = 0;

void do_async_request() {
    HINTERNET session = NULL;
    HINTERNET connect = NULL;
    HINTERNET request = NULL;

    session = WinHttpOpen(
        L"WinHttp Async Example/1.0",
        WINHTTP_ACCESS_TYPE_NO_PROXY,
        WINHTTP_NO_PROXY_NAME,
        WINHTTP_NO_PROXY_BYPASS,
        WINHTTP_FLAG_ASYNC
    );
    if (session) {
        WinHttpSetStatusCallback(session, (WINHTTP_STATUS_CALLBACK)http_callback, WINHTTP_CALLBACK_FLAG_ALL_NOTIFICATIONS, 0);

        //connect = WinHttpConnect(session, L"www.microsoft.com", INTERNET_DEFAULT_HTTPS_PORT, 0);
        connect = WinHttpConnect(session, L"www.microsoft.com", INTERNET_DEFAULT_HTTPS_PORT, 0);
        request = WinHttpOpenRequest(connect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_SECURE);

        DWORD size = 0;
        DWORD downloaded = 0;
        LPSTR outBuffer;
        BOOL result = FALSE;

        while (TRUE) {
            switch (internetStatus) {
            case WINHTTP_CALLBACK_STATUS_CONNECTED_TO_SERVER:
                
                break;
            }
            Sleep(10);
            /*
            if (theRequest == 1) {
            request = WinHttpOpenRequest(connect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_SECURE);
            //WinHttpSendRequest(request, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REFERER, 0, 0, 0);
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
            }*/
        }
    }
    else { // report any errors
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

void http_callback(HINTERNET hInternet, DWORD_PTR dwContext, DWORD dwInternetStatus, LPVOID lpvStatusInformation, DWORD dwStatusInformationLength) {
    switch (dwInternetStatus) {
    case WINHTTP_CALLBACK_STATUS_RESOLVING_NAME:
        printf("WINHTTP_CALLBACK_STATUS_RESOLVING_NAME\n");
        break;
    case WINHTTP_CALLBACK_STATUS_NAME_RESOLVED:
        printf("WINHTTP_CALLBACK_STATUS_NAME_RESOLVED\n");
        break;
    case WINHTTP_CALLBACK_STATUS_CONNECTING_TO_SERVER:
        printf("WINHTTP_CALLBACK_STATUS_CONNECTING_TO_SERVER\n");
        break;
    case WINHTTP_CALLBACK_STATUS_CONNECTED_TO_SERVER:
        printf("WINHTTP_CALLBACK_STATUS_CONNECTED_TO_SERVER\n");
        break;
    case WINHTTP_CALLBACK_STATUS_SENDING_REQUEST:
        printf("WINHTTP_CALLBACK_STATUS_SENDING_REQUEST\n");
        break;
    case WINHTTP_CALLBACK_STATUS_REQUEST_SENT:
        printf("WINHTTP_CALLBACK_STATUS_REQUEST_SENT\n");
        break;
    case WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE:
        printf("WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED:
        printf("WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED\n");
        break;
    case WINHTTP_CALLBACK_STATUS_CLOSING_CONNECTION:
        printf("WINHTTP_CALLBACK_STATUS_CLOSING_CONNECTION\n");
        break;
    case WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED:
        printf("WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED\n");
        break;
    case WINHTTP_CALLBACK_STATUS_HANDLE_CREATED:
        printf("WINHTTP_CALLBACK_STATUS_HANDLE_CREATED\n");
        break;
    case WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING:
        printf("WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING\n");
        break;
    case WINHTTP_CALLBACK_STATUS_DETECTING_PROXY:
        printf("WINHTTP_CALLBACK_STATUS_DETECTING_PROXY\n");
        break;
    case WINHTTP_CALLBACK_STATUS_REDIRECT:
        printf("WINHTTP_CALLBACK_STATUS_REDIRECT\n");
        break;
    case WINHTTP_CALLBACK_STATUS_INTERMEDIATE_RESPONSE:
        printf("WINHTTP_CALLBACK_STATUS_INTERMEDIATE_RESPONSE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_SECURE_FAILURE:
        printf("WINHTTP_CALLBACK_STATUS_SECURE_FAILURE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_HEADERS_AVAILABLE:
        printf("WINHTTP_CALLBACK_STATUS_HEADERS_AVAILABLE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_DATA_AVAILABLE:
        printf("WINHTTP_CALLBACK_STATUS_DATA_AVAILABLE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_READ_COMPLETE:
        printf("WINHTTP_CALLBACK_STATUS_READ_COMPLETE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE:
        printf("WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_REQUEST_ERROR:
        printf("WINHTTP_CALLBACK_STATUS_REQUEST_ERROR\n");
        break;
    case WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE:
        printf("WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_GETPROXYFORURL_COMPLETE:
        printf("WINHTTP_CALLBACK_STATUS_GETPROXYFORURL_COMPLETE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_CLOSE_COMPLETE:
        printf("WINHTTP_CALLBACK_STATUS_CLOSE_COMPLETE\n");
        break;
    case WINHTTP_CALLBACK_STATUS_SHUTDOWN_COMPLETE:
        printf("WINHTTP_CALLBACK_STATUS_SHUTDOWN_COMPLETE\n");
        break;
    default:
        printf("Internet status is %u\n", dwInternetStatus);
        break;
    }
    internetStatus = dwInternetStatus;
    Sleep(10);
}
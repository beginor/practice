#include "sync_request.h"
#include "async_request.h"

int main(int argc, char **argv) {
    /*printf("Start sync request...\n");
    do_sync_request();
    printf("End asyc request.\n");*/
    
    printf("Start async request...\n");
    do_async_request();
    printf("End async request.");
    
    printf("Press enter key to exit.");
    getchar();
    return EXIT_SUCCESS;
}

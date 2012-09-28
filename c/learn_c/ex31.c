#include <unistd.h>

int main(int argc, char *argv[])
{
	int i = 0;
	
	while (i < 100) {
		usleep(3000);
		i += 1;
	}
	
	return 0;
}
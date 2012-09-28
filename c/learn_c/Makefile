CFLAGS=-Wall -g

all: ex14 ex15 ex16 ex17 ex18 ex19 ex20 ex22_main ex23 ex24 ex25 ex27 ex29 ex31

ex19: object.o

ex22_main: ex22.o

ex29:
	cc -c libex29.c -o libex29.o 
	cc -shared -o libex29.so libex29.o
	cc -Wall -g    ex29.c   -o ex29
clean:
	rm -f *.o
	rm -f *.so
	rm -f -R *.dSYM
	rm -f ex14
	rm -f ex15
	rm -f ex16
	rm -f ex17
	rm -f ex18
	rm -f ex19
	rm -f ex20
	rm -f ex22_main
	rm -f ex23
	rm -f ex24
	rm -f ex25
	rm -f ex27
	rm -f ex29
	rm -f ex31
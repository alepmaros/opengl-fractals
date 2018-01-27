CC=g++
CFLAGS=-lglfw -lGL -lX11 -lpthread -lXrandr -lXi -ldl -I $(IDIR)

IDIR = include
ODIR = obj
SDIR = src

_DEPS = glad.h khrplatform.h Shader.h stb_image.h
DEPS = $(patsubst %,$(IDIR)/%,$(_DEPS))

_OBJ = glad.o Shader.o stb_image.o
OBJ = $(patsubst %,$(ODIR)/%,$(_OBJ))

$(ODIR)/%.o: $(SDIR)/%.cpp $(DEPS)
	$(CC) -c -o $@ $< $(CFLAGS)

all: $(OBJ)
	$(CC) -o main $(SDIR)/main.cpp $^ $(CFLAGS)

.PHONY: clean

clean:
	rm -f $(ODIR)/*.o

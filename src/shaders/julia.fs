#version 410
out vec4 FragColor;

in vec3 FragPos;
in vec2 TexturePos;

uniform float screen_ratio;
uniform vec2 screen_size;
uniform vec2 center;
uniform vec2 cj;
uniform float zoom;
uniform int iter;

vec4 map_to_color(float t) {
    float r = 9.0 * (1.0 - t) * t * t * t;
    float g = 15.0 * (1.0 - t) * (1.0 - t) * t * t;
    float b = 8.5 * (1.0 - t) * (1.0 - t) * (1.0 - t) * t;

    return vec4(r, g, b, 1.0);
}

void main()
{
    dvec2 z, c;

    z.x = 1.0 * TexturePos.x - 0.5;
    z.y = 1.0 * TexturePos.y - 0.5;

    z.x += center.x;
    z.y += center.y;

    z.x /= zoom;
    z.y /= zoom;
    
    int i;
    for (i = 0; i < iter; i++) {
        double x = (z.x * z.x - z.y * z.y) + cj.x;
        double y = (z.y * z.x + z.x * z.y) + cj.y;

        if ((x * x + y * y) > 2.0) break;
        z.x = x;
        z.y = y;
    }

    double t = double(i) / double(iter);

    FragColor = map_to_color(float(t));
}

#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec2 aTexture;

out vec3 FragPos;
out vec2 TexturePos;

void main()
{
    gl_Position = vec4(aPos, 1.0f);
    FragPos = aPos;
    TexturePos = aTexture;
}

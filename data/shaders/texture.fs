
varying vec3 v_position;
varying vec3 v_world_position;
varying vec3 v_normal;
varying vec2 v_uv;
varying vec4 v_color;

uniform vec4 u_color;
uniform vec3 u_light_direction;
uniform vec3 u_camera_position;
uniform sampler2D u_texture;
uniform float u_time;

void main()
{
	vec2 uv = v_uv;
	vec4 color = u_color * texture2D( u_texture, uv );
	gl_FragColor = color;
}

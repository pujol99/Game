
varying vec3 v_position;
varying vec3 v_world_position;
varying vec3 v_normal;
varying vec2 v_uv;
varying vec4 v_color;

uniform vec4 u_color;
uniform vec3 u_light_direction;
uniform vec3 u_camera_position;
uniform vec3 u_player_pos;
uniform sampler2D u_texture;
uniform float u_time;

void main()
{
	vec2 uv = v_uv;
	vec4 color = u_color * texture2D( u_texture, uv );
	vec2 vertex_pos = v_world_position.xz;
	vec2 player_pos = u_player_pos.xz;
	float dist = length(vertex_pos - player_pos);
	if(dist > 100){discard;}
	gl_FragColor = color;
}
